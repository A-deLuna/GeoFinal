using System;

namespace ProyectoFinal
{
	
	public partial class PuntosWindow : Gtk.Window
	{
		private Gtk.NodeStore store;
		public PuntosWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void OnNodeViewRealized (object sender, EventArgs e)
		{
			
		}

		protected void onNodeViewExposed (object o, Gtk.ExposeEventArgs args)
		{
			Gtk.NodeView nodeView = (Gtk.NodeView)o;
			nodeView.AppendColumn ("Nombre", new Gtk.CellRendererText (), "text", 0);
			nodeView.AppendColumn ("X", new Gtk.CellRendererText (), "text", 1);
			nodeView.AppendColumn ("Y", new Gtk.CellRendererText (), "text", 2);
			nodeView.NodeStore.AddNode(
			nodeView.ShowAll ();
		}
	}
}

