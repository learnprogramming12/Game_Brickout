using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Prj
{
    class Ball : PictureBox
    {
        /// <summary>
        /// Your Ball class must have following attributes 
        /// Add more attributes if required 
        /// </summary>
        private int _iVerticalSpeed, _iHorizontalSpeed;
        private bool _bBouncedOffBrick;
        private int _iXLastPos;
        private int _iYLastPos;
/*        public Ball(int verticalSpeed, int horizontalSpeed)
        {
            //this.picBall = picBall;
            this._iVerticalSpeed = verticalSpeed;
            this._iHorizontalSpeed = horizontalSpeed;

        }*/
        public Ball()
        {
            _bBouncedOffBrick = false;
        }

        public int HoriSpeed
        {
            get { return _iHorizontalSpeed; }
            set { _iHorizontalSpeed = value; }
        }
        public int VertSpeed
        {
            get { return _iVerticalSpeed; }
            set { _iVerticalSpeed = value; }
        }
        public int LastPosX
        {
            get { return _iXLastPos; }
            set { _iXLastPos = value; }
        }
        public int LastPosY
        {
            get { return _iYLastPos; }
            set { _iYLastPos = value; }
        }
        public bool BouncedOffBrick
        {
            get { return _bBouncedOffBrick; }
            set { _bBouncedOffBrick= value; }
        }
        //Add methods

    }
}
