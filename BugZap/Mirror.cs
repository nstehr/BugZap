//rotation code based on example from: http://www.codeproject.com/csharp/rotateimage.asp

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace BugZap
{
    public partial class Mirror : Sdgt.SdgForm
    {
        private int currentAngle;
        Image img = Image.FromFile("mirror.png");
        public Mirror()
        {
            InitializeComponent();
        }
        public Image getPicture()
        {
            return this.pictureBox.Image;
        }
        public void setPicture(Image i)
        {
           // if (i.Height > this.Height)
           // {

           //     Bitmap b = new Bitmap(i.Width, this.Height);
           //     Graphics g = Graphics.FromImage((Image)b);
           //     g.InterpolationMode = InterpolationMode.HighQualityBicubic;

           //     g.DrawImage(i, 0, 0, i.Width, this.Height);
           //     g.Dispose();
           //     i = b;
        //    }
            this.pictureBox.Image = i;
            
        }
        public int rotate(int degrees)
        {
            if (degrees > 359.9m)
            {
                degrees = 0;
                return degrees;
            }

            if (degrees < 0.0m)
            {
                degrees = 359;
                return degrees;
            }

            Image oldImage = pictureBox.Image;
            pictureBox.Image = Utilities.RotateImage(img, (float)degrees);

            if (oldImage != null)
            {
                oldImage.Dispose();
            }
           

            currentAngle = degrees;

            return degrees;
        }
        /**
         * Calculates the normal of the mirror.
         * rightOfSun - indicates which normal to calculate (lh or rh)
         * length - length to draw the normal line
         * */
        public Point calculateNormal(bool rightOfSun,int length)
        {
            int hypot = length;
            double normal_x;
            double normal_y;

            double rads = (currentAngle) * (Math.PI/180);
            double x = hypot*Math.Sin(rads);
            double y = hypot*Math.Cos(rads);

            

            if (rightOfSun)
            {
                //right of sun
                normal_x = -y;
                normal_y = x;
                if (currentAngle > 90 && currentAngle < 294)
                {
                    normal_x = y;
                    normal_y = -x;
                }
            }
            else
            {
                normal_x = y;
                normal_y = -x;
                if (currentAngle > 90 && currentAngle < 294)
                {
                    normal_x = -y;
                    normal_y = x;
                }

            }
            

           

            return new Point((int)normal_x, (int)normal_y);
        }
       
    }
     
}

