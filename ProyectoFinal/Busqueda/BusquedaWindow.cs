using System;
using System.Data;
using System.Collections.Generic;
using Cairo;
namespace ProyectoFinal
{
	public partial class BusquedaWindow : Gtk.Window
	{
		Dictionary<string,int> nomToId = new Dictionary<string,int> ();
		Dictionary<int,Tuple<int,int> >idToCoord = new Dictionary<int, Tuple<int, int> >();
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
				idToCoord.Add (id, new Tuple<int,int> (x, y));
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
			
			Cairo.Context context = Gdk.CairoHelper.Create (drawingarea1.GdkWindow);

			context.SetSourceColor (new Color (0, 0, 0));
			PointD p1, p2;
			p1 = new PointD ();
			p2 = new PointD ();

			foreach( var <int, Tuple<int,int> > entry in idToCoord){
				context.Arc (entry.Value.Item1  , entry.Value.Item2 , 5, 0, 2 * Math.PI);

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
			}
			context.FillPreserve ();	

			context.Dispose ();
			context = null;
		}

		protected void OnCalis (object sender, EventArgs e)
		{
			int inicia = nomToId [comboboxentry1.ActiveText];
			int termina = nomToId [comboboxentry2.ActiveText];
			List<Tuple<int,int> > newPath;
			newPath = ShortestPath.Dijkstra(inicia, termina, AdjMatDistancia);
			if (newPath != null)
				path = newPath;
			drawingarea1.QueueDraw ();

		}

		protected void OnAlternaButtonClick (object sender, EventArgs e)
		{
			int inicia = nomToId [comboboxentry1.ActiveText];
			int termina = nomToId [comboboxentry2.ActiveText];
			List<Tuple<int,int> > newPath;
			newPath = ShortestPath.OtherPath(inicia, termina, AdjMatDistancia);
			if (newPath != null)
				path = newPath;
			drawingarea1.QueueDraw ();
		}
	}
}

