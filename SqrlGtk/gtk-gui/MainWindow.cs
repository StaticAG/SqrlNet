
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action FileAction;
	private global::Gtk.Action ImportAction;
	private global::Gtk.Action ExportAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar27;
	private global::Gtk.Label domainLabel;
	private global::Gtk.HBox hbox2;
	private global::Gtk.Label identityLabel;
	private global::Gtk.ComboBox identityCombo;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TextView dataView;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Button cancelButton;
	private global::Gtk.Button loginButton;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
		this.ImportAction = new global::Gtk.Action ("ImportAction", global::Mono.Unix.Catalog.GetString ("Import..."), null, null);
		this.ImportAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Import...");
		w1.Add (this.ImportAction, null);
		this.ExportAction = new global::Gtk.Action ("ExportAction", global::Mono.Unix.Catalog.GetString ("Export..."), null, null);
		this.ExportAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Export...");
		w1.Add (this.ExportAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("SQRL Authentication");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar27'><menu name='FileAction' action='FileAction'><menuitem name='ImportAction' action='ImportAction'/><menuitem name='ExportAction' action='ExportAction'/></menu></menubar></ui>");
		this.menubar27 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar27")));
		this.menubar27.Name = "menubar27";
		this.vbox1.Add (this.menubar27);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar27]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.domainLabel = new global::Gtk.Label ();
		this.domainLabel.Name = "domainLabel";
		this.domainLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Do you want to log in to this domain?");
		this.vbox1.Add (this.domainLabel);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.domainLabel]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.identityLabel = new global::Gtk.Label ();
		this.identityLabel.Name = "identityLabel";
		this.identityLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Identity");
		this.hbox2.Add (this.identityLabel);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.identityLabel]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.identityCombo = global::Gtk.ComboBox.NewText ();
		this.identityCombo.Name = "identityCombo";
		this.hbox2.Add (this.identityCombo);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.identityCombo]));
		w5.Position = 1;
		this.vbox1.Add (this.hbox2);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
		w6.Position = 2;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.dataView = new global::Gtk.TextView ();
		this.dataView.CanFocus = true;
		this.dataView.Name = "dataView";
		this.dataView.Editable = false;
		this.dataView.CursorVisible = false;
		this.GtkScrolledWindow.Add (this.dataView);
		this.vbox1.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
		w8.Position = 3;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Homogeneous = true;
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.cancelButton = new global::Gtk.Button ();
		this.cancelButton.CanFocus = true;
		this.cancelButton.Name = "cancelButton";
		this.cancelButton.UseStock = true;
		this.cancelButton.UseUnderline = true;
		this.cancelButton.Label = "gtk-no";
		this.hbox1.Add (this.cancelButton);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.cancelButton]));
		w9.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.loginButton = new global::Gtk.Button ();
		this.loginButton.CanFocus = true;
		this.loginButton.Name = "loginButton";
		this.loginButton.UseStock = true;
		this.loginButton.UseUnderline = true;
		this.loginButton.Label = "gtk-yes";
		this.hbox1.Add (this.loginButton);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.loginButton]));
		w10.Position = 1;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w11.Position = 4;
		w11.Expand = false;
		w11.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 294;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.cancelButton.Clicked += new global::System.EventHandler (this.OnCancelButtonClicked);
		this.loginButton.Clicked += new global::System.EventHandler (this.OnLoginButtonClicked);
	}
}
