using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Prj
{
    class Paddle:PictureBox
    {
        /// <summary>
        /// Your Paddle class must have following attributes 
        /// Add more attributes if required 
        /// </summary>
/*        private PictureBox _picPaddle;
*/        private int _paddleSpeed;

        public Paddle(int iPaddleSpeed)
        {
/*            this._picPaddle = picPaddle;
*/            this._paddleSpeed = iPaddleSpeed;
        }
    }
}
