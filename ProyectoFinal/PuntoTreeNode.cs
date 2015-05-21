using System;

namespace ProyectoFinal
{
	[Gtk.TreeNode (ListOnly = true)]
	public class PuntoTreeNode : Gtk.TreeNode{
		int id;


		public PuntoTreeNode (int id, string nombre, int x, int y){
			this.id = id;
			this.nombre = nombre;
			this.x = x;
			this.y = y;
		}
		[Gtk.TreeNodeValue (Column=0)]
		public string nombre;

		[Gtk.TreeNodeValue (Column=1)]
		public int x;

		[Gtk.TreeNodeValue (Column=2)]
		public int y;



	}

}

