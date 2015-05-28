using System;
using Npgsql;
using System.Data;

namespace ProyectoFinal
{
	public partial class RutasWindow : Gtk.Window
	{
		public RutasWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			nodeview1.NodeStore = Store;
			nodeview1.AppendColumn ("Nombre", new Gtk.CellRendererText (), "text", 0);
			nodeview1.AppendColumn ("Inicia", new Gtk.CellRendererText (), "text", 1);
			nodeview1.AppendColumn ("Termina", new Gtk.CellRendererText (), "text", 2);
			nodeview1.AppendColumn ("Distancia", new Gtk.CellRendererText (), "text", 3);
			nodeview1.AppendColumn ("Tiempo", new Gtk.CellRendererText (), "text", 4);
			nodeview1.ShowAll ();

		}

		Gtk.NodeStore store;
		Gtk.NodeStore Store{
			get{
				if (store == null) {
					store = new Gtk.NodeStore (typeof(RutaTreeNode));

					string sql = 
						"SELECT id, nombre, inicia_nombre, inicia_id, termina_nombre, termina_id, distancia, tiempo " +
						"FROM rutas";

					IDataReader reader = SingletonDB.Instance.query (sql);
					while (reader.Read ()) {
						int id = reader.GetInt32 (reader.GetOrdinal ("id"));
						string nombre = reader.GetString (reader.GetOrdinal ("nombre"));
						string inicia_nombre = reader.GetString (reader.GetOrdinal ("inicia_nombre"));
						int inicia_id = reader.GetInt32 (reader.GetOrdinal ("inicia_id"));
						string termina_nombre = reader.GetString (reader.GetOrdinal ("termina_nombre"));
						int termina_id = reader.GetInt32 (reader.GetOrdinal ("termina_id"));
						int distancia = reader.GetInt32 (reader.GetOrdinal ("distancia"));
						int tiempo = reader.GetInt32 (reader.GetOrdinal ("tiempo"));

						store.AddNode (new RutaTreeNode(id,nombre,inicia_id,inicia_nombre, termina_id,
							termina_nombre,distancia,tiempo));
					}

					reader.Close ();
					reader = null;


				}
				return store;
			}
		}

		protected void OnAgregarButtonClick (object sender, EventArgs e)
		{
			RutaDialog rd = new RutaDialog ("new");
			this.Destroy ();
		}

		protected void OnEditarButtonClick (object sender, EventArgs e)
		{
			RutaTreeNode tn = (RutaTreeNode)nodeview1.NodeSelection.SelectedNode;
			if (tn != null) {
				RutaDialog rd = new RutaDialog ("edit", tn.id, tn.nombre, tn.inicio_id, tn.termina_id, tn.distancia, tn.tiempo);
				this.Destroy ();
			}
		}

		protected void OnEliminarButtonClick (object sender, EventArgs e)
		{
			RutaTreeNode tn = (RutaTreeNode)nodeview1.NodeSelection.SelectedNode;
			if (tn != null) {
				string sql = "DELETE FROM rutas WHERE id = " + tn.id + ";";
				SingletonDB.Instance.execute (sql);
				this.Destroy ();
				RutasWindow rw = new RutasWindow ();
				rw.Show ();
			}
		}
	}
}

