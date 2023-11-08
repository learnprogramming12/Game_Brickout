using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment2Prj.Properties;

using static Assignment2Prj.CollisionDetection;

namespace Assignment2Prj
{
    class Manager
    {
        /// <summary>
        /// Your Manager class must have following attributes 
        /// Add more attributes if required 
        /// </summary>
        private BrickMatrix _brickMatrix;
        private Ball _ball;
        private Paddle _paddle;
        private GameLevel _gameLevel;
        private Control _canvas;

        private double _dMaxLaunchAngle;
        private  double _dMinLaunchAngle;       

        
        public Manager(Control Canvas, BrickMatrix bricks, Ball ball, Paddle paddle, GameLevel level)
        {
            _canvas = Canvas;
            this._brickMatrix = bricks;
            this._ball = ball;
            this._paddle = paddle;
            _gameLevel = level;
        }
        public void NewGame(GameLevel level, double dMinLaunchAngle, double dMaxLaunchAngle)
        {
            _gameLevel = level;
            _dMinLaunchAngle = dMinLaunchAngle / 180 * Math.PI;
            _dMaxLaunchAngle = dMaxLaunchAngle / 180 * Math.PI;
            InitGame();
        }
        private void InitGame()
        {
            InitBall();
            InitPaddle();
            _brickMatrix.InitMatrix(_gameLevel);
        }
        private void InitBall()
        {
            _ball.Visible = true;
            _ball.Left = 1;
            _ball.Top = _canvas.Height / 3;
            int iSpeed = GetBallSpeed(_gameLevel);
            _ball.HoriSpeed = Convert.ToInt32(iSpeed * Math.Cos(Math.PI / 4));
            _ball.VertSpeed = Convert.ToInt32(iSpeed * Math.Sin(Math.PI / 4));
           // MessageBox.Show((iSpeed * Math.Cos(Math.PI / 4)).ToString() + "\n" + _ball.HoriSpeed.ToString() + "\n" + _ball.VertSpeed.ToString() );
        }
        private void InitPaddle()
        {
            _paddle.Visible = true;
            _paddle.Top = _canvas.Height - 100;
            _paddle.Left = (_canvas.Width - _paddle.Width) / 2;
        }

        public void ResponseToPaddleMove(int iDistance)
        {
            if (_paddle.Left + iDistance <= 0)
                _paddle.Left = 0;
            else if (_paddle.Left + iDistance + _paddle.Width >= _canvas.Width)
                _paddle.Left = _canvas.Width - _paddle.Width;
            else
                _paddle.Left += iDistance;

            DetectBallAndPaddleCollision();
        }
        public void ResponseToBallMove()
        {
            _ball.LastPosX = _ball.Left;
            _ball.LastPosY = _ball.Top;
            _ball.Left += _ball.HoriSpeed;
            _ball.Top += _ball.VertSpeed;
            
            //If collision happens,propably don't need to check every one, so use OR operator.Better to put the detection function of ball
            //and wall front because it can have several collision with wall in a loop. And they are mutual
            if (DetectBallAndWallCollision() || DetectBallAndPaddleCollision())
                ;
            DetectBallAndBricksCollision();
        }
        private bool DetectBallAndPaddleCollision()
        {
            /*            MessageBox.Show(_paddle.Bounds.ToString() + "\n Paddle.Top: " + _paddle.Top.ToString() + "\n Canvas.height: " + _canvas.Height.ToString() +
                "\nCanvas.width: " + _canvas.Width.ToString() + "\nForm.Height: " + _paddle.Parent.Height.ToString());*/
            bool bCollision = CollisionDetection.DetectBallVSPaddle(CollisionDetection.GetCircleFromSquare(_ball.Bounds), _paddle.Bounds);
          
            if (bCollision)
            {
                int iGap = _ball.Left - (_paddle.Left + _paddle.Width / 2 - _ball.Width / 2);
                int iGap2 = iGap < 0 ? -iGap : iGap;
                double dAngle = (1 - Math.Min(Convert.ToDouble(iGap2) / (_paddle.Width / 2), 1)) * (_dMaxLaunchAngle - _dMinLaunchAngle) + _dMinLaunchAngle;               
                //Need to get the ball speed based on GameLevel rather than from ball becasue the hori-speed and vert-speed continuously change based on
                //the angle bounced off the paddle. If get from ball, the convertion from double to int can result in a little lower speed.              
                int iSpeed = GetBallSpeed(_gameLevel);
                int iHoriSpeed = Convert.ToInt32(iSpeed * Math.Cos(dAngle));
                int iVertSpeed = Convert.ToInt32(iSpeed * Math.Sin(dAngle));
                _ball.VertSpeed = -iVertSpeed;
                _ball.HoriSpeed = iGap < 0 ? -iHoriSpeed : iHoriSpeed;
                _ball.BouncedOffBrick = false;
            }
            else
            {
                if(_ball.Bottom >= _paddle.Bottom)
                {
                    //Game Over
                    if (GameOver != null)
                    {
                        Music.play(MusicType.Lost);
                        GameOverEventArgs args = new GameOverEventArgs(false);
                        this.GameOver(this, args);
                    }
                }
            }
            return bCollision;
        }
        private bool DetectBallAndWallCollision()
        {
            //1.Both two conditions can be meet at same time in some situation, For example, jump out the corner of the canvas when next movement
            //2.If the ball enters outside, it should be reset the position also, not only the direction. For example, the left position of the ball is -20, and the horizontal
            //speed is -12 and it is detected collision. Even though the speed is changed to 12 from -12, -20 + 12 < 0. So the next movement will still result in a minus position.
            //but because the position is detected < 0. This time the speed is changed to -12 from 12 which means it will be a infinite loop in horizontal position.
            bool bCollision = false;
            if(_ball.Left <= 0 || _ball.Right >= _canvas.Width)
            {
                bCollision = true;
                _ball.HoriSpeed = -_ball.HoriSpeed;
                if(_ball.Left <= 0)
                    _ball.Left = 0;
                else
                    _ball.Left = _canvas.Width - _ball.Width;
            }
            if(_ball.Top <= 0)
            {
                bCollision = true;
                _ball.VertSpeed = -_ball.VertSpeed;
                _ball.Top = 0;
            }
            return bCollision;
        }
        private bool DetectBallAndBricksCollision()
        {
            //each time the ball is bounced off brick for only once, it should omit the collision with other bricks.
            if (_ball.BouncedOffBrick == true)
                return false;
            Circle circle = CollisionDetection.GetCircleFromSquare(_ball.Bounds);
            Brick[,]bricks = _brickMatrix.Bricks;
            for(int i = bricks.GetLength(0) - 1; i >= 0; i--)
            {
                for(int j = bricks.GetLength(1) - 1; j >= 0; j-- )
                {
                    if (bricks[i, j].Visible == false)
                        continue;
                    CollisionInfo info = CollisionDetection.CheckCircleRectangleIntersection(bricks[i, j].Bounds, new Point(circle.iXCenter, circle.iYCenter), circle.iR);
                    if(info.bCollision)
                    {
                        Music.play(MusicType.BallAgainstBrick);

                        bricks[i, j].Firmness--;
                        int iScore = ScoringSystem.GetScoring(bricks[i, j]);
                        if (UpdateScore != null)
                        {
                            UpdateScoreEventArgs args = new UpdateScoreEventArgs(iScore);
                            this.UpdateScore(this, args);
                        }
                        if (bricks[i, j].DamageLevel != DamageLevel.Self)
                        {
                            BombDamage.ResponseToBomb(bricks[i, j], _brickMatrix);
                            if (GameOver != null)
                            {
                                Music.play(MusicType.Bomb);
                                GameOverEventArgs args = new GameOverEventArgs(true);
                                this.GameOver(this, args);
                            }
                        }
                        else
                        {
                            if (bricks[i, j].Firmness <= 0)
                            {
                                bricks[i, j].Visible = false;
                                if (IsAllBricksDisappear())
                                {
                                    if (GameOver != null)
                                    {
                                        Music.play(MusicType.Win);
                                        GameOverEventArgs args = new GameOverEventArgs(true);
                                        this.GameOver(this, args);
                                    }
                                }
                            }
                        }
                        if (ShouldBounceHorizontal(info, bricks[i, j].Bounds))
                        {
                            _ball.VertSpeed = -_ball.VertSpeed;
                        }
                        else
                        {
                            _ball.HoriSpeed = -_ball.HoriSpeed;
                        }
                        _ball.BouncedOffBrick = true;
                        return true;
                    }
                }
            }
            return false;
        }
        private int GetBallSpeed(GameLevel level)
        {
            int iSpeed = 0;
            switch (level)
            {
                case GameLevel.Easy:
                    iSpeed = 15;
                    break;
                case GameLevel.Normal:
                    iSpeed = 20;
                    break;
                case GameLevel.Hard:
                case GameLevel.Master:
                    iSpeed = 25;
                    break;
            }
            return iSpeed;
        }
        private bool ShouldBounceHorizontal(CollisionInfo collisionInfo, Rectangle rectBrick)
        {

            //if the above 2 conditions do not meet, then the reference point is circle center. And need to check which one side(line segment of brick
            //has an intersection point with the line segment(previous center point and current center point)to decide the bounce direction
            Circle ballCurrentPos = GetCircleFromSquare(_ball.Bounds);
            Circle ballLastPos = GetCircleFromSquare(new Rectangle(_ball.LastPosX, _ball.LastPosY, _ball.Width, _ball.Height));
            if (ballCurrentPos.iXCenter == ballLastPos.iXCenter)
                return true;
            if (ballCurrentPos.iYCenter == ballLastPos.iYCenter)
                return false;
            float xIntersection;
            if (CollisionDetection.CalculateXIntersection(new PointF(ballLastPos.iXCenter, ballLastPos.iYCenter), new PointF(collisionInfo.iXReferencePoint, collisionInfo.iYReferencePoint)
                    , new PointF(rectBrick.Left, rectBrick.Bottom), new PointF(rectBrick.Right, rectBrick.Bottom), out xIntersection))
            {
                //deal with 2 end point of the bottom line of brick.
                if ((collisionInfo.iXReferencePoint == rectBrick.Left || collisionInfo.iXReferencePoint == rectBrick.Right) && collisionInfo.iYReferencePoint == rectBrick.Bottom &&
                    ballCurrentPos.iYCenter > ballLastPos.iYCenter)
                    return false;
                return true;
            }
            if (CollisionDetection.CalculateXIntersection(new PointF(ballLastPos.iXCenter, ballLastPos.iYCenter), new PointF(collisionInfo.iXReferencePoint, collisionInfo.iYReferencePoint)
                    , new PointF(rectBrick.Left, rectBrick.Top), new PointF(rectBrick.Right, rectBrick.Top), out xIntersection))
            {
                //deal with 2 end points of the top line of brick
                if ((collisionInfo.iXReferencePoint == rectBrick.Left || collisionInfo.iXReferencePoint == rectBrick.Right) && collisionInfo.iYReferencePoint == rectBrick.Top &&
                    ballCurrentPos.iYCenter < ballLastPos.iYCenter)
                    return false;
                return true;
            }          
            return false;
        }
        private bool IsAllBricksDisappear()
        {
            for(int i = 0; i < _brickMatrix.Bricks.GetLength(0); i++)
            {
                for(int j = 0; j < _brickMatrix.Bricks.GetLength(1); j++)
                {
                    if (_brickMatrix.Bricks[i, j].Visible == true)
                        return false;
                }
            }
            return true;
        }
        public class UpdateScoreEventArgs : EventArgs
        {
            public int Score;
            public UpdateScoreEventArgs(int iScore)
            {
                Score = iScore;
            }
        }
        public delegate void UpdateScoreEventHandler(object sender, UpdateScoreEventArgs e);
        public event UpdateScoreEventHandler UpdateScore;

        public class GameOverEventArgs : EventArgs
        {
            public bool Win;
            public GameOverEventArgs(bool bWin)
            {
                Win = bWin;
            }
        }
        public delegate void GameOverEventHandler(object sender, GameOverEventArgs e);
        public event GameOverEventHandler GameOver;
    }
}
