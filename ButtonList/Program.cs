namespace ButtonList;

public partial class TestButtonList : Form1
{
    private ButtonList buttonList;

    public TestButtonList()
    {
        InitializeComponent();
        // Set the form to fullscreen
        this.WindowState = FormWindowState.Maximized;

        // Initialize ButtonList
        buttonList = new ButtonList(Orientation.Horizontal, 100, 50);

        // Add buttons to ButtonList
        buttonList.AddButtons(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" },
                              Color.Blue, new Size(80, 60), ClickButton);

        // Add buttons to the form
        buttonList.AddButtonsToForm(this);
    }

    private void ClickButton(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        MessageBox.Show("You clicked character [" + btn.Text + "]");

        // Example: Remove the clicked button
        buttonList.RemoveButton(btn);
    }

    private void InitializeComponent()
    {
        this.Text = "Button List Example";
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TestButtonList());
    }
}
