using System;
using Gtk;
using System.IO;
using System.Text;

//string Msg = "File exists!";
//MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, Msg);
//md.Run();
//md.Destroy();

public partial class MainWindow : Gtk.Window

{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		if (File.Exists("NoteFile.jnf"))
		{

			string loadText = System.IO.File.ReadAllText("NoteFile.jnf");
			textview1.Buffer.Text = loadText;
		}
		else
		{
			StreamWriter writenotexists = new StreamWriter("NoteFile.jnf", false, Encoding.UTF8);
			writenotexists.Write("Empty note file!");
			writenotexists.Close();
			string loadText = System.IO.File.ReadAllText("NoteFile.jnf");
			textview1.Buffer.Text = loadText;
		}

	}
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}

	protected void OnClickPressed(object sender, EventArgs e)
	{
		string text = textview1.Buffer.Text;
		StreamWriter writer = new StreamWriter("NoteFile.jnf", false, Encoding.UTF8);
		writer.Write(text);
		writer.Close();
	}
}
