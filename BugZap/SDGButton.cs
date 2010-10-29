using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sdgt.Widgets
{
    #region Event Delegates
    // This handler returns the sender and the ID of the mouse that generated the click
    public delegate void buttonClickHandler(object sender, int userID);
    #endregion

    /*
	 *  SDG Button Class coded by Saul Greenberg
	 */

    public class SDGButton : Sdgt.SdgUserControl
    {
        private System.ComponentModel.IContainer components = null;
        // An array that indicates if a mouse matching the array index is pressed (up to 30 mice).
        private bool[] pressed = new bool[30];
        private string text;	// local counterpart of the Text property
        private bool useLock;

        public SDGButton()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true); // for smooth redraws
            this.Text = "SDG Button";  // need a better way to generate the default button name
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #region Properties
        /// <summary>
        /// Property to get and set the Text that is displayed in the button.
        /// </summary>
        [Description("Property to get and set the Text that is displayed in the button.")]
        public override string Text
        {
            set
            {
                text = value;
            }
            get
            {
                return text;
            }
        }

        /// <summary>
        /// Property to get and set UseLock for how users are allowed to use the mouse.
        /// </summary>
        [Description("If true, only one person can use the button at a time. If false, both can use it.")]
        public bool UseLock
        {
            set
            {
                useLock = value;
            }
            get
            {
                return useLock;
            }
        }
        #endregion

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // SDGButton
            // 
            this.Name = "SDGButton";
            this.Size = new System.Drawing.Size(152, 72);
            this.SdgMouseDown += new Sdgt.SdgMouseEventHandler(this.SDGButton_SdgMouseDown);
            this.SdgMouseUp += new Sdgt.SdgMouseEventHandler(this.SDGButton_SdgMouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SDGButton_Paint);

        }
        #endregion

        #region Event Declarations
        /// <summary>
        /// Event fired when the button is clicked for a particular user.
        /// </summary>
        [Description("Event fired when the Button is clicked.")]
        public event buttonClickHandler sdgClick;
        #endregion

        #region Event Handlers

        // On a paint event, redraw the graphics for the entire control
        private void SDGButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            drawControl();
        }

        // On a mouse down, record that that mouse is in a pressed state and force a repaint
        private void SDGButton_SdgMouseDown(object sender, Sdgt.SdgMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.UseLock == false) //simultaneous use allowed
                {
                    pressed[e.ID] = true;
                    this.Invalidate();
                }
                else // Only allow this person to press it if no one else has.
                {
                    bool none_pressed = true;
                    foreach (bool b in pressed)
                    {
                        if (b == true) none_pressed = false;
                    }
                    if (none_pressed)
                    {
                        pressed[e.ID] = true;
                        this.Invalidate();
                    }
                }
            }
        }

        // On a mouse up, record that that mouse is in an unpressed state and force a repaint
        // Also check to see if any all other mice are unpressed. If so, then generate a click event.
        private void SDGButton_SdgMouseUp(object sender, Sdgt.SdgMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.UseLock == false || (this.UseLock == true && pressed[e.ID] == true))
                {
                    pressed[e.ID] = false;
                    this.Invalidate();

                    bool none_pressed = true;
                    foreach (bool b in pressed)
                    {
                        if (b == true) none_pressed = false;
                    }

                    if (none_pressed && sdgClick != null) sdgClick(this, e.ID);
                }
            }
        }
        #endregion

        #region Drawing

        private void drawControl()
        {
            // Check to see if any mice are pressed.
            bool no_mice_pressed = true;
            foreach (bool b in pressed)
            {
                if (true == b)
                    no_mice_pressed = false;
            }

            // If no mice are pressed, then draw the button with unpressed visuals
            // otherwsie with pressed visuals
            if (no_mice_pressed)
            {
                drawUnpressedButton();
            }
            else
            {
                drawPressedButton();
            }
        }


        // Brute force drawing of the visuals - unpressed state
        private void drawUnpressedButton()
        {
            Graphics gfx = this.CreateGraphics();
            Pen p;
            gfx.Clear(this.BackColor);

            Point ptl = new Point(0, 0);
            Point ptr = new Point(this.Width - 1, 0);
            Point pbl = new Point(0, this.Height - 1);
            Point pbr = new Point(this.Width - 1, this.Height - 1);

            //White lines on inside left side and top
            p = new Pen(SystemBrushes.ControlLightLight, 4);
            gfx.DrawLine(p, ptl, ptr);
            gfx.DrawLine(p, ptl, pbl);

            //Grey lines on inside right side and bottom
            p = new Pen(SystemBrushes.ControlDark, 3);
            gfx.DrawLine(p, pbl, pbr);
            gfx.DrawLine(p, pbr, ptr);

            //Dark lines surround entire button
            p = new Pen(SystemBrushes.ControlDarkDark, 1);
            gfx.DrawLine(p, ptl, ptr);
            gfx.DrawLine(p, ptl, pbl);
            gfx.DrawLine(p, pbl, pbr);
            gfx.DrawLine(p, pbr, ptr);

            drawCenteredText(new Point((this.Width - 1) / 2, (this.Height - 1) / 2));
        }


        // Brute force drawing of the visuals - pressed state
        private void drawPressedButton()
        {
            Graphics gfx = this.CreateGraphics();
            Pen p;
            gfx.Clear(this.BackColor);

            Point ptl = new Point(0, 0);
            Point ptr = new Point(this.Width - 1, 0);
            Point pbl = new Point(0, this.Height - 1);
            Point pbr = new Point(this.Width - 1, this.Height - 1);

            //Dark lines on inside left side and top
            p = new Pen(SystemBrushes.ControlDarkDark, 4);
            gfx.DrawLine(p, ptl, ptr);
            gfx.DrawLine(p, ptl, pbl);

            //Dark lines surround entire button
            p = new Pen(SystemBrushes.ControlDarkDark, 1);
            gfx.DrawLine(p, ptl, ptr);
            gfx.DrawLine(p, ptl, pbl);
            gfx.DrawLine(p, pbl, pbr);
            gfx.DrawLine(p, pbr, ptr);

            // Shift the text over a bit to give it that 3d click feel
            drawCenteredText(new Point((this.Width + 2) / 2, (this.Height + 2) / 2));
        }



        // Drawing the text in the Button
        private void drawCenteredText(Point centerpt)
        {
            Graphics gfx = this.CreateGraphics();

            StringFormat strfmt = new StringFormat();
            strfmt.Alignment = StringAlignment.Center;
            strfmt.LineAlignment = StringAlignment.Center;
            gfx.DrawString(this.Text, this.Font, SystemBrushes.WindowText, centerpt, strfmt);
        }
        #endregion



    }
}

