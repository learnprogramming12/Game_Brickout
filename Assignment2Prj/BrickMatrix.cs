using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2Prj
{
    class BrickMatrix
    {
        /// <summary>
        /// Your Brick class must have following attributes 
        /// Add more attributes if required 
        /// </summary>
        private Control _canvas;
        private Brick[,] _bricks;
        private int _rows;
        private int _cols;
        private int _space;
        private static int _firmestLevel = 4;

        public Brick[,] Bricks
        {
            get { return _bricks; }
        }
        public BrickMatrix(Control form, int iRows, int iCols, int iSpace = 0)
        {
            this._canvas = form;
            this._rows = iRows;
            this._cols = iCols;
            this._space = iSpace;
            this._bricks = new Brick[iRows, iCols];
            CreateBricks();
        }
        private void CreateBricks()
        {
            if (_rows == 0 || _cols == 0)
                return;
            double dHoriSpan = Convert.ToDouble(_canvas.Right) / _cols;
            double dBrickWidth = Convert.ToInt32(dHoriSpan - _space);
            double dBrickHeight = dBrickWidth / 3;
            double dVertSpan = dBrickHeight + _space;

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _bricks[i, j] = new Brick(1);
                    _bricks[i, j].Left = Convert.ToInt32(dHoriSpan * j);
                    _bricks[i, j].Top = Convert.ToInt32(dVertSpan * i);
                    _bricks[i, j].Width = Convert.ToInt32(dBrickWidth);
                    _bricks[i, j].Height = Convert.ToInt32(dBrickHeight);
                    _bricks[i, j].Visible = false;
                    _canvas.Controls.Add(_bricks[i, j]);
                }
            }
        }
        public void InitMatrix(GameLevel level)
        {
            ResetMetrix();//if it's the first time to run game, in fact no need to call the function.
            int iTotal = _rows * _cols;
            int iNumOfChangeFirmness = Convert.ToInt32(0.4 * iTotal);//2-4 firmness account for about 40%
            switch (level)
            {
                //2-4 firmness account for about 10%
                case GameLevel.Easy:
                    iNumOfChangeFirmness = Convert.ToInt32(0.1 * iTotal);
                    break;
                //2-4 firmness account for about 60%
                case GameLevel.Hard:
                    iNumOfChangeFirmness = Convert.ToInt32(0.6 * iTotal);
                    break;
                //2-4 firmness account for about 90%
                case GameLevel.Master:
                    iNumOfChangeFirmness = Convert.ToInt32(0.9 * iTotal);
                    break;
                default:
                    break;
            }

            Random random = new Random();
            int[] iArray = MyTool.ProduceNonrepetitiveNumber(0, iTotal - 1, iNumOfChangeFirmness);
            for (int i = 0; i < iArray.Length; i++)
            {
                int iRow = iArray[i] / _cols;
                int iCol = iArray[i] % _cols;
                int iRandom = random.Next(2, _firmestLevel + 1);
                _bricks[iRow, iCol].Firmness = iRandom;
            }
            if(level == GameLevel.Easy || level == GameLevel.Normal)
                GenerateBomb(iTotal); 
            SetBackground();
        }

        private void ResetMetrix()
        {
            for(int i = 0; i< _rows; i++)
            {
                for(int j = 0; j< _cols; j++)
                {
                    _bricks[i, j].Firmness = 1;
                    _bricks[i, j].DamageLevel = DamageLevel.Self;
                    _bricks[i,j].Visible = true;
                    _bricks[i, j].BackgroundImage = null;
                }    

            }
        }
        private void GenerateBomb(int iTotal)
        {
            int[] iArray = MyTool.ProduceNonrepetitiveNumber(0, iTotal - 1, 2);
            for (int i = 0; i < 2; i++)
            {
                int iRow = iArray[i] / _cols;
                int iCol = iArray[i] % _cols;
                _bricks[iRow, iCol].DamageLevel = DamageLevel.All;
                _bricks[iRow, iCol].Firmness = 1;
            }
        }
        private void SetBackground()
        {
            for(int i = 0; i < _rows; i++)
            {
                for(int j = 0; j < _cols; j++)
                {
                    switch(_bricks[i, j].Firmness)
                    { 
                        case 1:
                            if (_bricks[i, j].DamageLevel != DamageLevel.Self)
                            {
                                _bricks[i, j].BackColor = Color.White;
                                _bricks[i, j].BackgroundImage = (Image)Properties.Resources.bomb;
                                _bricks[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                            }
                            else
                                _bricks[i, j].BackColor = Color.Green;
                            break;
                        case 2:
                            _bricks[i, j].BackColor = Color.Yellow;
                            break;
                        case 3:
                            _bricks[i, j].BackColor = Color.Orange;
                            break;
                        case 4:
                            _bricks[i, j].BackColor = Color.Red;
                            break;
                    }
                }
            }
        }
    }
}
