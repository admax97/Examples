using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CursorPosition
{
    public partial class frmMain : Form
    {
        // We need to use unmanaged code
        [DllImport("user32.dll")]
        // GetCursorPos() makes everything possible
        static extern bool GetCursorPos(ref Point lpPoint);
        // Variable we will need to count the traveled pixels
        static protected long totalPixels = 0;
        static protected int currX;
        static protected int currY;
        static protected int diffX;
        static protected int diffY;

        public frmMain()
        {
            InitializeComponent();
        }

        private void tmrDef_Tick(object sender, EventArgs e)
        {
            // New point that will be updated by the function with the current coordinates
            Point defPnt = new Point();
            // Call the function and pass the Point, defPnt
            GetCursorPos(ref defPnt);
            // Now after calling the function, defPnt contains the coordinates which we can read
            lblCoordX.Text = "X = " + defPnt.X.ToString();
            lblCoordY.Text = "Y = " + defPnt.Y.ToString();
            // If the cursor has moved at all
            if (diffX != defPnt.X | diffY != defPnt.Y)
            {
                // Calculate the distance of movement (in both vertical and horizontal movement)
                diffX = (defPnt.X - currX);
                diffY = (defPnt.Y - currY);
                // The difference will be negative if the cursor was moved left or up
                // and if it is so, make the number positive
                if (diffX < 0)
                {
                    diffX *= -1;
                }
                if (diffY < 0)
                {
                    diffY *= -1;
                }
                // Add to the "pixels traveled" counter
                totalPixels += diffX + diffY;
                // And display inside a label
                lblTravel.Text = "You have traveled " + totalPixels + " pixels";
            }
            // We need this to see the difference of pixels between two mouse movements
            currX = defPnt.X;
            currY = defPnt.Y;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            totalPixels = 0;
        }
    }
}