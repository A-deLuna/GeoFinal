using System;
using Npgsql;
using System.Data;
namespace ProyectoFinal
{
	public partial class PuntoDialog : Gtk.Dialog
	{
		bool isNew;
		int id;
		public PuntoDialog (string type, int id = 0, string nombre = "", int x = 0, int y = 0)
		{
			this.Build ();
			isNew = type.Equals ("new");
			entry4.Text = nombre;
			entry5.Text = ""+x;
			entry6.Text = ""+y;
			this.id = id;
		}
		protected void OnCancelButtonClick (object sender, EventArgs e)
		{
			PuntosWindow pw = new PuntosWindow ();
			pw.Show ();
			this.Destroy ();
		}


		protected void onOKButtonClick (object sender, EventArgs e)
		{
			string nombre = entry4.Text;


			string x = entry5.Text;
			string y = entry6.Text;
			string sql = isNew?
				"INSERT INTO puntos (nombre, x, y) VALUES ('"+nombre+"',"+x+","+y+");":
				"UPDATE puntos SET nombre = '"+nombre+"', x = "+x+", y = "+y+" WHERE id = "+id+";"  ;


			SingletonDB.Instance.execute (sql);

			PuntosWindow pw = new PuntosWindow ();
			pw.Show ();
			this.Destroy ();
		}
	}
}

