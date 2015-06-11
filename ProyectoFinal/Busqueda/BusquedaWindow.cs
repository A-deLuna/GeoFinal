using System;
using System.Data;
using System.Collections.Generic;
using Cairo;
namespace ProyectoFinal
{
	public partial class BusquedaWindow : Gtk.Window
	{
		Dictionary<string,int> nomToId = new Dictionary<string,int> ();
		Dictionary<int,Tuple<int,int, string> >idToCoord = new Dictionary<int, Tuple<int, int,string> >();
		List<Tuple<int,int> >path = new List<Tuple<int,int>>();
		List<Tuple<int,int,int,int> > rutas;
		int maxid = -1;
		int[,] AdjMatDistancia;
		int [,] AdjMatTiempo;
		public BusquedaWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			populateComboBox ();
			saveRoutes ();
			drawingarea1.QueueDraw ();
		}
		private void saveRoutes(){
			int INF = 1000000;
			AdjMatDistancia = new int [maxid+1, maxid+1];
			AdjMatTiempo = new int [maxid+1, maxid+1];
			for (int i = 0; i <= maxid; i++) {
				for (int j = 0; j <= maxid; j++) {
					if (i != j) {
						AdjMatDistancia[i,j] = INF;
						AdjMatTiempo[i,j] = INF;
					}
				}
			}
			string sql = "SELECT inicia_id, termina_id, distancia, tiempo FROM rutas";
			IDataReader reader = SingletonDB.Instance.query (sql);
			while (reader.Read ()) {
				int inicia_id = reader.GetInt32 (reader.GetOrdinal ("inicia_id"));
				int termina_id = reader.GetInt32 (reader.GetOrdinal ("termina_id"));
				int distancia = reader.GetInt32 (reader.GetOrdinal ("distancia"));
				int tiempo = reader.GetInt32 (reader.GetOrdinal ("tiempo"));
				AdjMatDistancia [inicia_id, termina_id] = distancia;
				AdjMatTiempo [inicia_id, termina_id] = tiempo;
			}
		}
		private void populateComboBox(){
			string sql = "SELECT id, nombre, x, y FROM puntos";
			IDataReader reader = SingletonDB.Instance.query (sql);
			while (reader.Read ()) {
				int id = reader.GetInt32 (reader.GetOrdinal ("id"));
				string nombre = reader.GetString (reader.GetOrdinal ("nombre"));
				int x = reader.GetInt32 (reader.GetOrdinal ("x"));
				int y = reader.GetInt32 (reader.GetOrdinal ("y"));
				nomToId.Add (nombre, id);
				idToCoord.Add (id, new Tuple<int,int,string> (x, y,nombre));
				comboboxentry1.AppendText (nombre);
				comboboxentry2.AppendText (nombre);
				maxid = Math.Max (maxid, id);
			}
			Console.WriteLine (maxid);
			reader.Dispose ();
			reader = null;
		}

		protected void onExpose (object o, Gtk.ExposeEventArgs args)
		{
		//	Gdk.Pixbuf pixbuff = Gdk.Pixbuf.LoadFromResource("aaa");
			Cairo.Context context = Gdk.CairoHelper.Create (drawingarea1.GdkWindow);
	//		Gdk.CairoHelper.SetSourcePixbuf (context, pixbuff, 0, 0);
//			context.SetSourceColor (new Color (0, 0, 0));
			PointD p1, p2;
			p1 = new PointD ();
			p2 = new PointD ();

			foreach( var <int, Tuple<int,int,string> > entry in idToCoord){
				context.Arc (entry.Value.Item1  , entry.Value.Item2 , 5, 0, 2 * Math.PI);
				context.MoveTo (entry.Value.Item1-5, entry.Value.Item2 - 15);
				context.ShowText (entry.Value.Item3);
				context.ClosePath ();
				context.Fill ();

			}
			foreach (Tuple<int, int> coords in path) {
				Console.WriteLine (coords.Item1 + " " + coords.Item2);
				p1.X = idToCoord [coords.Item1].Item1;
				p1.Y = idToCoord [coords.Item1].Item2;
				p2.X = idToCoord [coords.Item2].Item1;
				p2.Y = idToCoord [coords.Item2].Item2;

				context.MoveTo (p1);
				context.LineTo (p2);
				context.ClosePath ();
				context.Stroke ();
				double x1, y1, x2, y2;
				Tuple<double, double> a = calc (p1.X, p1.Y,  p2.X,  p2.Y, out x1, out y1, out x2, out y2);
				p1.X = x1;
				p1.Y = y1;
				p2.X = a.Item1;
				p2.Y = a.Item2;
				context.MoveTo (p1);
				context.LineTo (p2);
				context.ClosePath ();
				context.Stroke ();
				p1.X = x2;
				p1.Y = y2;
				context.MoveTo (p1);
				context.LineTo (p2);
				context.ClosePath ();
				context.Stroke ();

			}
			context.FillPreserve ();	

			context.Dispose ();
			context = null;
		}
		Tuple<double,double> calc(double start_x, double start_y,  double end_x,  double end_y, 
			out double x1, out double y1, out double x2, out double y2){
			double length = 12.0;
			double arrow_degrees = 0.5;
			double angle = Math.Atan2 (end_y - start_y, end_x - start_x) + Math.PI;
			end_x = end_x + 5.0 * Math.Cos (angle);
			end_y = end_y + 5.0 * Math.Sin (angle);
			x1 = end_x + length * Math.Cos (angle - arrow_degrees);  
			y1 = end_y + length * Math.Sin (angle - arrow_degrees);
			x2 = end_x + length * Math.Cos (angle + arrow_degrees);
			y2 = end_y + length * Math.Sin (angle + arrow_degrees);

			return new Tuple<double,double> (end_x, end_y);
		}
		private void updateTextBoxes(){
			textview5.Buffer.Text = "";
			textview6.Buffer.Text = "";
			textview7.Buffer.Text = "";
			textview9.Buffer.Text = "";
			int distsum = 0;
			int timesum = 0;

			foreach (Tuple<int, int> edge in path) {
				textview5.Buffer.Text += idToCoord [edge.Item1].Item3 + "\n"; 
				textview6.Buffer.Text += idToCoord [edge.Item2].Item3 + "\n";
				textview7.Buffer.Text += AdjMatDistancia [edge.Item1,edge.Item2] + "\n";
				textview9.Buffer.Text += AdjMatTiempo [edge.Item1,edge.Item2] + "\n";
				distsum += AdjMatDistancia [edge.Item1, edge.Item2];
				timesum += AdjMatTiempo [edge.Item1, edge.Item2];  

			}
			entry1.Text = distsum + "";
			entry2.Text = timesum + "";
			entry3.Text = path.Count + 1+"";
		}
		protected void OnCalis (object sender, EventArgs e)
		{
			string s = comboboxentry1.ActiveText;
			string f = comboboxentry2.ActiveText;
			if(s == "" || f == "") return;
			int inicia = nomToId [s];
			int termina = nomToId [f];
			List<Tuple<int,int> > newPath;
			if(radiobutton1.Active)
				newPath = ShortestPath.Dijkstra(inicia, termina, AdjMatDistancia);
			else
				newPath = ShortestPath.Dijkstra(inicia, termina, AdjMatTiempo);

			if (newPath != null) {
				path = newPath;
				updateTextBoxes ();
			}
			drawingarea1.QueueDraw ();

		}

		protected void OnAlternaButtonClick (object sender, EventArgs e)
		{
			string s = comboboxentry1.ActiveText;
			string f = comboboxentry2.ActiveText;
			if(s == "" || f == "") return;
			int inicia = nomToId [s];
			int termina = nomToId [f];
			List<Tuple<int,int> > newPath;
			if(radiobutton1.Active)
				newPath = ShortestPath.OtherPath(inicia, termina, AdjMatDistancia);
			else
				newPath = ShortestPath.OtherPath(inicia, termina, AdjMatTiempo);
			
			if (newPath != null) {
				path = newPath;
				updateTextBoxes ();
			}
			drawingarea1.QueueDraw ();
		}
	}
}

