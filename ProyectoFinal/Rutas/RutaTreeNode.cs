using System;

namespace ProyectoFinal
{
	[Gtk.TreeNode (ListOnly = true)]
	public class RutaTreeNode : Gtk.TreeNode
	{
		public int id;
		public int inicio_id;
		public int termina_id;
		public RutaTreeNode (int id, string nombre, int inicio_id, string inicio_nombre, 
			int termina_id, string termina_nombre, int distancia, int tiempo)
		{
			this.id = id;
			this.nombre = nombre;
			this.inicio_id = inicio_id;
			this.inicio_nombre = inicio_nombre;
			this.termina_id = termina_id;
			this.termina_nombre = termina_nombre;
			this.distancia = distancia;
			this.tiempo = tiempo;

		}
		[Gtk.TreeNodeValue (Column=0)]
		public string nombre;

		[Gtk.TreeNodeValue (Column=1)]
		public string inicio_nombre;

		[Gtk.TreeNodeValue (Column=2)]
		public string termina_nombre;

		[Gtk.TreeNodeValue (Column=3)]
		public int distancia;

		[Gtk.TreeNodeValue (Column=4)]
		public int tiempo;

	}
}

