using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//magnifying glass image from: http://www.wpclipart.com/office/supplies/index.html
namespace BugZap
{
    public partial class MagGlass : Sdgt.SdgForm
    {
        public MagGlass()
        {
            InitializeComponent();
        }
        public PictureBox getPicture()
        {
            return pictureBox1;
        }
        public void setPicture(Image i)
        {
            pictureBox1.Image = i;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    
}
}

