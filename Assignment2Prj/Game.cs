using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Assignment2Prj.Manager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Assignment2Prj
{
    public enum GameLevel
    {
        Easy = 0,
        Normal,
        Hard,
        Master
    }
    public enum GameStatus
    {
        InProgress,
        Paused,
        Stopped
    }
    public partial class Game : Form
    {
        private PictureBox picboxCanvas;
        private Ball picboxBall;
        private Paddle picboxPaddle;
        private BrickMatrix _brickMatrix;
        private Manager _manager;

        private static GameLevel _enumGameLevel;
        private GameStatus _enumGameStatus;

        public Game()
        {
            InitializeComponent();
   //         this.FormBorderStyle = FormBorderStyle.None;  
            BackColor = Color.Black;
            _enumGameStatus = GameStatus.Stopped;

            picboxCanvas = new PictureBox();
            picboxCanvas.Left = 10;
            picboxCanvas.Top = 100;
            picboxCanvas.Width = 600;
            picboxCanvas.Height = this.Height - picboxCanvas.Top;
            picboxCanvas.BackColor = Color.Black;
            picboxCanvas.BorderStyle = BorderStyle.None;
            Controls.Add(picboxCanvas);


            picboxPaddle = new Paddle(5);
            picboxPaddle.Height = 30;
            picboxPaddle.Width = picboxPaddle.Height * 2;
            picboxPaddle.BackColor = Color.Silver;
            picboxPaddle.MouseDown += PicboxPaddle_MouseDown;
            picboxPaddle.MouseMove += PicboxPaddle_MouseMove;
            picboxPaddle.MouseUp += PicboxPaddle_MouseUp;
            picboxPaddle.Visible = false;
            picboxCanvas.Controls.Add(picboxPaddle);

            //
            Image imageBall = Properties.Resources.Pink;
            picboxBall = new Ball();
            picboxBall.Image = imageBall;
            picboxBall.Width = 12;
            picboxBall.Height = 12;
            picboxBall.SizeMode = PictureBoxSizeMode.StretchImage;
            picboxBall.Visible = false;
            picboxCanvas.Controls.Add(picboxBall);

            cbDifficultyLevel.Items.Add("Easy");
            cbDifficultyLevel.Items.Add("Normal");
            cbDifficultyLevel.Items.Add("Hard");
            cbDifficultyLevel.Items.Add("Master");
            cbDifficultyLevel.SelectedIndex = 1;

            _brickMatrix = new BrickMatrix(picboxCanvas, 6, 8, 5);
            _manager = new Manager(picboxCanvas,_brickMatrix, picboxBall, picboxPaddle, GameLevel.Normal);
            _manager.UpdateScore += new Manager.UpdateScoreEventHandler(this.onUpdateScore);
            _manager.GameOver += new Manager.GameOverEventHandler(this.onGameOver);

            Welcome welcome = new Welcome();
            welcome.ShowDialog();
        }

        private void PicboxPaddle_MouseMove(object sender, MouseEventArgs e)
        {

            if (bDragging && _enumGameStatus != GameStatus.Stopped)
            {
                int iX = e.X - ptStartPoint.X;
                _manager.ResponseToPaddleMove(iX);
            }
        }

        private void PicboxPaddle_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bDragging = false;
            }
        }
        private bool bDragging = false;
        private Point ptStartPoint;
        private void PicboxPaddle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bDragging = true;
                ptStartPoint = e.Location;
            }
        }
        private void Game_Load(object sender, EventArgs e)
        {
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            int iStart = (Width - ClientSize.Width) / 4;

            Pen pen = new Pen(Color.DarkGray, picboxCanvas.Left);
            e.Graphics.DrawRectangle(pen, iStart, iStart, picboxCanvas.Right + 2, this.Height);
            e.Graphics.DrawLine(pen, iStart, picboxCanvas.Top - pen.Width, picboxCanvas.Right, picboxCanvas.Top - pen.Width);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {          
            if (_enumGameStatus != GameStatus.Paused)
                return;
            timer.Start();
            _enumGameStatus = GameStatus.InProgress;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_enumGameStatus != GameStatus.InProgress)
                return;
            timer.Stop();
            _enumGameStatus = GameStatus.Paused;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (_enumGameStatus == GameStatus.InProgress || _enumGameStatus == GameStatus.Paused)
            {
                timer.Stop();
                _enumGameStatus = GameStatus.Paused;
                if (DialogResult.Cancel == MessageBox.Show("Do you want to start a new game?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    return;
            }
            GameLevel level = GetSelectedGameLevel();
            bool bMin = double.TryParse(numMinBounceAngle.Value.ToString(), out double dMinBounceAngle);
            bool bMax = double.TryParse(numMaxBounceAngle.Value.ToString(), out double dMaxBounceAngle);
            if (bMin == false || bMax == false)
                return;
            if(dMinBounceAngle >= dMaxBounceAngle)
            {
                MessageBox.Show("The minimum launch angle should be less than maximum launch angle.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lblScoreBoard.Text = "0";

            _manager.NewGame(level, dMinBounceAngle, dMaxBounceAngle);
            _enumGameStatus = GameStatus.InProgress;
            timer.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_enumGameStatus == GameStatus.Stopped)
            {
                MessageBox.Show("The game has stopped. There is no need to save the game state");
                return;       
            }
            timer.Stop();
            //for save
        }
        private GameLevel GetSelectedGameLevel()
        {
            GameLevel level;
            switch (cbDifficultyLevel.SelectedItem)
            {
                case "Easy":
                    level = GameLevel.Easy;
                    break;
                case "Normal":
                    level = GameLevel.Normal;
                    break;
                case "Hard":
                    level = GameLevel.Hard;
                    break;
                case "Master":
                    level = GameLevel.Master;
                    break;
                default:
                    level = GameLevel.Normal;
                    break;
            }
            return level;
        }


        private void SetControlsState(bool bStart, bool bPause, bool bNewGame, bool bSave, bool bGameLevel)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _manager.ResponseToBallMove();
        }
        private void onUpdateScore(Object sender, UpdateScoreEventArgs e)
        {
            bool bScucceed = int.TryParse(lblScoreBoard.Text, out int iScore);
            if(bScucceed)
            {
                lblScoreBoard.Text = (iScore + e.Score).ToString();
            }
        }
        private void onGameOver(object sender, GameOverEventArgs e)
        {
            _enumGameStatus = GameStatus.Stopped;
/*            if(e.Win == true)
            {
                Music.play(MusicType.Win);
            }
            else
            {
                Music.play(MusicType.Lost);
            }*/
            timer.Stop();
            picboxBall.Visible = false;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            bool bMove = false;
            int iDisatance = 15;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    bMove = true;
                    iDisatance = -iDisatance;
                    break;
                case Keys.Right:
                    bMove = true;
                    break;
            }
            if (bMove && _enumGameStatus != GameStatus.Stopped)
            {
                _manager.ResponseToPaddleMove(iDisatance);
            }

        }

        private void Game_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                // Prevent controls from handling the left and right arrow keys
                e.IsInputKey = true;
            }
        }
    }
}
