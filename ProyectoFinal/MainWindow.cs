using System;
using Gtk;
using ProyectoFinal;
public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		SingletonDB.Instance.close ();
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnPuntosButtonClick (object sender, EventArgs e)
	{
		PuntosWindow pw = new PuntosWindow ();
		pw.Show ();
	}

	protected void OnRutasButtonClick (object sender, EventArgs e)
	{
		RutasWindow rw = new RutasWindow ();
		rw.Show ();
	}
}
