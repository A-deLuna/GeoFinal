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
						"User ID=postgres;" +
						"Password=amelia;";






				}
				return store;
			}
		}
	}
}

