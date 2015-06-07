using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnOpen (object sender, EventArgs e)
	{
		int width, height;
		this.GetDefaultSize (out width, out height);

		this.Resize (width, height);

		logTextView.Buffer.Text = "";

		FileChooserDialog chooser = new FileChooserDialog (
			"Please select a log file to view...",
			this,
			FileChooserAction.Open,
			"Cancel", ResponseType.Cancel,
			"Open", ResponseType.Accept);

		if (chooser.Run () == (int)ResponseType.Accept) {
		
			System.IO.StreamReader file1 = System.IO.File.OpenText(chooser.Filename);

			logTextView.Buffer.Text = file1.ReadToEnd();

			this.Title = "Log viewer -- " + chooser.Filename.ToString();

			this.Resize(640, 480);
				file1.Close();
		}

		chooser.Destroy();
	}
	protected void OnClose (object sender, EventArgs e)
	{
		int width, height;
		this.GetDefaultSize (out width, out height);
		this.Resize(width, height);

		logTextView.Buffer.Text = "";

		this.Title = "Log Viewer";

	}


		protected void OnAbout (object sender, EventArgs e)
	{

		AboutDialog about = new AboutDialog();

		about.Name = "Log Viewer";
		about.Version = "1.0.0";
		about.Run();
		about.Destroy();
	
	}



	protected void OnExit (object sender, EventArgs e)
	{
		Application.Quit();
	}

}	
