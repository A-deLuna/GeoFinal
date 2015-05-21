using System;
using Npgsql;
using System.Data;
namespace ProyectoFinal
{
	
	public partial class PuntosWindow : Gtk.Window
	{
		
		public PuntosWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			nodeview1.NodeStore = Store;
			nodeview1.AppendColumn ("Nombre", new Gtk.CellRendererText (), "text", 0);
			nodeview1.AppendColumn ("X", new Gtk.CellRendererText (), "text", 1);
			nodeview1.AppendColumn ("Y", new Gtk.CellRendererText (), "text", 2);
			nodeview1.ShowAll ();

		}

		protected void OnNodeViewRealized (object sender, EventArgs e)
		{
			
		}


		Gtk.NodeStore store;
		Gtk.NodeStore Store {
			get{
				if (store == null) {
					store = new Gtk.NodeStore (typeof(PuntoTreeNode));

					string connectionString = 
						"Server=localhost;" +
						"Database=ProyectoFinal;" +
						"Port=5433;"+
						"User ID=postgres;" +
						"Password=amelia;";


					IDbConnection dbcon;
					dbcon = new NpgsqlConnection (connectionString);
					dbcon.Open ();
					IDbCommand dbcmd = dbcon.CreateCommand ();
					string sql = 
						"SELECT id, nombre, x, y " +
						"FROM puntos";
					
					dbcmd.CommandText = sql;
					IDataReader reader = dbcmd.ExecuteReader ();
					while (reader.Read ()) {
						int id = reader.GetInt32 (reader.GetOrdinal ("id"));
						string nombre = reader.GetString (reader.GetOrdinal ("nombre"));
						int x = reader.GetInt32 (reader.GetOrdinal ("x"));
						int y = reader.GetInt32 (reader.GetOrdinal ("y"));

						store.AddNode (new PuntoTreeNode (id, nombre, x, y));
					}


				}
				return store;
			}
		}
	}
}

