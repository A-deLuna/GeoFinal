
// This file has been generated by the GUI designer. Do not modify.
namespace ProyectoFinal
{
	public partial class PuntoDialog
	{
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Entry entry4;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Entry entry5;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Entry entry6;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget ProyectoFinal.PuntoDialog
			this.Name = "ProyectoFinal.PuntoDialog";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child ProyectoFinal.PuntoDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("nombre");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entry4 = new global::Gtk.Entry ();
			this.entry4.CanFocus = true;
			this.entry4.Name = "entry4";
			this.entry4.IsEditable = true;
			this.entry4.InvisibleChar = '●';
			this.hbox1.Add (this.entry4);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entry4]));
			w3.Position = 1;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 47;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("x");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.entry5 = new global::Gtk.Entry ();
			this.entry5.CanFocus = true;
			this.entry5.Name = "entry5";
			this.entry5.IsEditable = true;
			this.entry5.InvisibleChar = '●';
			this.hbox2.Add (this.entry5);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.entry5]));
			w6.Position = 1;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox2]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 46;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("y");
			this.hbox3.Add (this.label3);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label3]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.entry6 = new global::Gtk.Entry ();
			this.entry6.CanFocus = true;
			this.entry6.Name = "entry6";
			this.entry6.IsEditable = true;
			this.entry6.InvisibleChar = '●';
			this.hbox3.Add (this.entry6);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.entry6]));
			w9.Position = 1;
			this.vbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox3]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Internal child ProyectoFinal.PuntoDialog.ActionArea
			global::Gtk.HButtonBox w12 = this.ActionArea;
			w12.Name = "dialog1_ActionArea";
			w12.Spacing = 10;
			w12.BorderWidth = ((uint)(5));
			w12.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w13 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w12 [this.buttonCancel]));
			w13.Expand = false;
			w13.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w14 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w12 [this.buttonOk]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnCancelButtonClick);
			this.buttonOk.Clicked += new global::System.EventHandler (this.onOKButtonClick);
		}
	}
}
