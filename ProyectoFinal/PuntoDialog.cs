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
			if (type.Equals ("new"))
				isNew = true;
			textview1.Buffer.Text = nombre;
			textview2.Buffer.Text = ""+x;
			textview3.Buffer.Text = ""+y;
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
			string nombre = textview1.Buffer.Text;
			string x = textview2.Buffer.Text;
			string y = textview3.Buffer.Text;
			string sql = isNew?
				"INSERT INTO puntos (nombre, x, y) VALUES ('"+nombre+"',"+x+","+y+");":
				"UPDATE puntos SET nombre = '"+nombre+"', x = "+x+", y = "+y+" WHERE id = "+id+";"  ;


			dbcmd.CommandText = sql;
			dbcmd.ExecuteNonQuery ();

			PuntosWindow pw = new PuntosWindow ();
			pw.Show ();
			this.Destroy ();
		}
	}
}

