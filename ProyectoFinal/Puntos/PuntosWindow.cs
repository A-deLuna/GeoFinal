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



		Gtk.NodeStore store;
		Gtk.NodeStore Store {
			get{
				if (store == null) {
					store = new Gtk.NodeStore (typeof(PuntoTreeNode));

					string sql = 
						"SELECT id, nombre, x, y " +
						"FROM puntos";
					
					IDataReader reader = SingletonDB.Instance.query (sql);
					while (reader.Read ()) {
						int id = reader.GetInt32 (reader.GetOrdinal ("id"));
						string nombre = reader.GetString (reader.GetOrdinal ("nombre"));
						int x = reader.GetInt32 (reader.GetOrdinal ("x"));
						int y = reader.GetInt32 (reader.GetOrdinal ("y"));

						store.AddNode (new PuntoTreeNode (id, nombre, x, y));
					}

					reader.Close ();
					reader = null;


				}
				return store;
			}
		}

		protected void onAgregarButtonClick (object sender, EventArgs e)
		{
			PuntoDialog pd = new PuntoDialog ("new");
			this.Destroy ();
		}

		protected void OnEditarButtonClick (object sender, EventArgs e)
		{
			PuntoTreeNode tn = (PuntoTreeNode)nodeview1.NodeSelection.SelectedNode;
			if (tn != null) {
				PuntoDialog pd = new PuntoDialog ("edit", tn.db_id, tn.nombre, tn.x, tn.y);
				this.Destroy ();
			}

		}

		protected void OnEliminarButtonClick (object sender, EventArgs e)
		{
			PuntoTreeNode tn = (PuntoTreeNode)nodeview1.NodeSelection.SelectedNode;
			if (tn != null) {
				string sql = "DELETE FROM puntos WHERE id = "+tn.db_id+";";
				SingletonDB.Instance.execute (sql);
				this.Destroy ();
				PuntosWindow pw = new PuntosWindow ();
				pw.Show ();
			}
		}
	}
}

