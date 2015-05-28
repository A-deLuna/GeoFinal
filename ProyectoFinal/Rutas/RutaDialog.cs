using System;
using System.Data;
using System.Collections.Generic;
namespace ProyectoFinal
{
	public partial class RutaDialog : Gtk.Dialog
	{
		bool isNew;
		int id;
		string s1;
		string s2;
		Dictionary<string,int> points = new Dictionary<string,int>();
		List<string> values = new List<string>();
		public RutaDialog (string type, int id = 0, string nombre = "", int inicia_id=-1, int termina_id=-1, int distancia = 0, int tiempo = 0)
		{
			this.Build ();
			isNew = type.Equals("new");
			entry1.Text = nombre;
			entry7.Text = "" + distancia;
			entry8.Text = "" + tiempo;
			this.id = id;

			string sql = "SELECT id, nombre " +
			             "FROM puntos";
			
			IDataReader reader = SingletonDB.Instance.query (sql);
			while (reader.Read ()) {
				int punto_id = reader.GetInt32(reader.GetOrdinal("id"));
				string punto_nombre = reader.GetString(reader.GetOrdinal("nombre"));
				comboboxentry1.AppendText (punto_nombre);
				comboboxentry2.AppendText (punto_nombre);
				points.Add (punto_nombre, punto_id);
				values.Add (punto_nombre);
				if (punto_id == inicia_id) {
					s1 = punto_nombre;
				}
				if (punto_id == termina_id) {
					s2 = punto_nombre;
				}

			}
			reader.Close ();
			reader = null;

			if( s1 != null && s2 != null){
				int row1 = values.IndexOf (s1);
				int row2 = values.IndexOf (s2);

				Gtk.TreeIter iter1;
				Gtk.TreeIter iter2;
				comboboxentry1.Model.IterNthChild (out iter1, row1);
				comboboxentry1.SetActiveIter (iter1);

				comboboxentry2.Model.IterNthChild (out iter2, row2);
				comboboxentry2.SetActiveIter (iter2);
			}
		}

		protected void OnCancelButtonClick (object sender, EventArgs e)
		{
			RutasWindow rw = new RutasWindow ();
			rw.Show ();
			this.Destroy ();
		}

		protected void OnOKButtonClick (object sender, EventArgs e)
		{
			string nombre = entry1.Text;
			string inicia = comboboxentry1.ActiveText;
			int inicia_id = points [inicia];
			string termina = comboboxentry2.ActiveText;
			int termina_id = points [termina];
			string distancia = entry7.Text;
			string tiempo = entry8.Text;

			string sql = isNew ?
				"INSERT INTO rutas (nombre, inicia_nombre, inicia_id, termina_nombre, termina_id, distancia, tiempo) " +
			             "VALUES ('" + nombre + "','" + inicia + "'," + inicia_id + ",'" + termina + "'," + termina_id + "," + distancia + "," + tiempo + ");" :
				"UPDATE rutas SET nombre = '" + nombre + "', inicia_nombre='" + inicia + "', inicia_id=" + inicia_id + ", termina_nombre='" + termina + "' , termina_id = " + termina_id + "," +
			             " distancia = " + distancia + ", tiempo = " + tiempo + " WHERE id = " + id + ";";
		
			SingletonDB.Instance.execute (sql);
			RutasWindow rw = new RutasWindow ();
			rw.Show ();
			this.Destroy ();
		}
		
	}
}

