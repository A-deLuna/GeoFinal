
// This file has been generated by the GUI designer. Do not modify.
namespace ProyectoFinal
{
	public partial class RutasWindow
	{
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button button53;
		
		private global::Gtk.Button button54;
		
		private global::Gtk.Button button55;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.NodeView nodeview1;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget ProyectoFinal.RutasWindow
			this.Name = "ProyectoFinal.RutasWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Window");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child ProyectoFinal.RutasWindow.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.button53 = new global::Gtk.Button ();
			this.button53.CanFocus = true;
			this.button53.Name = "button53";
			this.button53.UseUnderline = true;
			this.button53.Label = global::Mono.Unix.Catalog.GetString ("Agregar");
			this.hbox1.Add (this.button53);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button53]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.button54 = new global::Gtk.Button ();
			this.button54.CanFocus = true;
			this.button54.Name = "button54";
			this.button54.UseUnderline = true;
			this.button54.Label = global::Mono.Unix.Catalog.GetString ("Editar");
			this.hbox1.Add (this.button54);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button54]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.button55 = new global::Gtk.Button ();
			this.button55.CanFocus = true;
			this.button55.Name = "button55";
			this.button55.UseUnderline = true;
			this.button55.Label = global::Mono.Unix.Catalog.GetString ("Eliminar");
			this.hbox1.Add (this.button55);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button55]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.nodeview1 = new global::Gtk.NodeView ();
			this.nodeview1.CanFocus = true;
			this.nodeview1.Name = "nodeview1";
			this.GtkScrolledWindow.Add (this.nodeview1);
			this.vbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow]));
			w6.Position = 1;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 389;
			this.DefaultHeight = 300;
			this.Show ();
			this.button53.Clicked += new global::System.EventHandler (this.OnAgregarButtonClick);
			this.button54.Clicked += new global::System.EventHandler (this.OnEditarButtonClick);
			this.button55.Clicked += new global::System.EventHandler (this.OnEliminarButtonClick);
		}
	}
}
