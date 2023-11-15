namespace ButtonList;

// ButtonList.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


public class ButtonList
{
    private List<Button> buttons;
    private Orientation orientation;

    public Orientation Orientation
    {
        get { return orientation; }
        set { orientation = value; }
    }

    public ButtonList(Orientation orientation = Orientation.Horizontal, int startX = 50, int startY = 50)
    {
        buttons = new List<Button>();
        this.orientation = orientation;
        this.StartX = startX;
        this.StartY = startY;
    }

    public int StartX { get; set; }
    public int StartY { get; set; }

    public void AddButtons(string[] buttonTexts, Color buttonColor, Size buttonSize, EventHandler clickHandler = null)
    {
        foreach (string buttonText in buttonTexts)
        {
            Button button = new Button();
            button.Text = buttonText;
            button.Size = buttonSize;
            button.BackColor = buttonColor;
            buttons.Add(button);

            if (clickHandler != null)
            {
                button.Click += clickHandler;
            }
        }
    }

    public void AddButtonsToForm(Form form)
    {
        int x = StartX;
        int y = StartY;

        foreach (Button button in buttons)
        {
            button.Location = new Point(x, y);

            if (orientation == Orientation.Vertical)
            {
                y += button.Size.Height + 10; // Add some spacing between vertical buttons
            }
            else // Orientation.Horizontal
            {
                x += button.Size.Width + 10; // Add some spacing between horizontal buttons
            }

            form.Controls.Add(button);
        }
    }

    public void RemoveButton(Button button)
    {
        if (buttons.Contains(button))
        {
            buttons.Remove(button);
            button.Parent.Controls.Remove(button);
        }
    }
}

