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


				public BusquedaWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			populateComboBox ();
			drawPoints ();
			drawingarea1.QueueDraw ();
		}
		private void drawPoints(){
			

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
			}
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
			path.Add (new Tuple<int,int> (1, 3));
			path.Add (new Tuple<int,int> (3, 4));
			path.Add (new Tuple<int,int> (4, 5));
			drawingarea1.QueueDraw ();

		}
	}
}

