using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Prj
{
    public partial class Welcome : Form
    {
        int _fontSize = 4;
        public Welcome()
        {
            InitializeComponent();
            this.pictureBoxWelcome.BackgroundImage = (Image)Properties.Resources.welcomeBgImage;
            this.pictureBoxWelcome.BackgroundImageLayout = ImageLayout.Stretch;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_fontSize > 30)
            {
                timer.Stop();
                Close();
            }
            else
            {
                this.pictureBoxWelcome.Invalidate();
            }
        }

        private void Welcome_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void Welcome_Paint(object sender, PaintEventArgs e)
        {
 
        }

        private void pictureBoxWelcome_Paint(object sender, PaintEventArgs e)
        {
            _fontSize += 2;
            string strText1 = "Adapted from Breakout";
            string strText2 = "in 1976";
            Font font = new Font("Serif", _fontSize, FontStyle.Bold);
            Size size1 = e.Graphics.MeasureString(strText1, font).ToSize();
            Size size2 = e.Graphics.MeasureString(strText2, font).ToSize();
            e.Graphics.DrawString(strText1, font, new SolidBrush(Color.White), (this.pictureBoxWelcome.Width - size1.Width) / 2, this.pictureBoxWelcome.Height / 2);
            e.Graphics.DrawString(strText2, font, new SolidBrush(Color.White), (this.pictureBoxWelcome.Width - size2.Width) / 2, this.pictureBoxWelcome.Height / 2 + size1.Height);

        }
    }
}
