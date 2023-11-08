namespace Assignment2Prj
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cbDifficultyLevel = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblScoreBoard = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numMinBounceAngle = new System.Windows.Forms.NumericUpDown();
            this.numMaxBounceAngle = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMinBounceAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxBounceAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // cbDifficultyLevel
            // 
            this.cbDifficultyLevel.BackColor = System.Drawing.Color.LightGray;
            this.cbDifficultyLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDifficultyLevel.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDifficultyLevel.ForeColor = System.Drawing.Color.Blue;
            this.cbDifficultyLevel.FormattingEnabled = true;
            this.cbDifficultyLevel.Location = new System.Drawing.Point(941, 629);
            this.cbDifficultyLevel.Name = "cbDifficultyLevel";
            this.cbDifficultyLevel.Size = new System.Drawing.Size(124, 32);
            this.cbDifficultyLevel.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGray;
            this.btnStart.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Blue;
            this.btnStart.Location = new System.Drawing.Point(941, 541);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(124, 46);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Continue";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.LightGray;
            this.btnPause.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.Blue;
            this.btnPause.Location = new System.Drawing.Point(941, 453);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(124, 46);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.LightGray;
            this.btnNewGame.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.ForeColor = System.Drawing.Color.Blue;
            this.btnNewGame.Location = new System.Drawing.Point(941, 365);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(124, 46);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Blue;
            this.btnSave.Location = new System.Drawing.Point(941, 803);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 46);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblScoreBoard
            // 
            this.lblScoreBoard.AutoSize = true;
            this.lblScoreBoard.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreBoard.ForeColor = System.Drawing.Color.White;
            this.lblScoreBoard.Location = new System.Drawing.Point(414, 30);
            this.lblScoreBoard.Name = "lblScoreBoard";
            this.lblScoreBoard.Size = new System.Drawing.Size(44, 49);
            this.lblScoreBoard.TabIndex = 6;
            this.lblScoreBoard.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(937, 680);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Minimum angle:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(937, 750);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Maximum angle:";
            // 
            // numMinBounceAngle
            // 
            this.numMinBounceAngle.ForeColor = System.Drawing.Color.Blue;
            this.numMinBounceAngle.Location = new System.Drawing.Point(941, 703);
            this.numMinBounceAngle.Maximum = new decimal(new int[] {
            89,
            0,
            0,
            0});
            this.numMinBounceAngle.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMinBounceAngle.Name = "numMinBounceAngle";
            this.numMinBounceAngle.Size = new System.Drawing.Size(124, 25);
            this.numMinBounceAngle.TabIndex = 10;
            this.numMinBounceAngle.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // numMaxBounceAngle
            // 
            this.numMaxBounceAngle.ForeColor = System.Drawing.Color.Blue;
            this.numMaxBounceAngle.Location = new System.Drawing.Point(941, 770);
            this.numMaxBounceAngle.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numMaxBounceAngle.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numMaxBounceAngle.Name = "numMaxBounceAngle";
            this.numMaxBounceAngle.Size = new System.Drawing.Size(124, 25);
            this.numMaxBounceAngle.TabIndex = 11;
            this.numMaxBounceAngle.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(937, 606);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Difficulty level:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(257, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 49);
            this.label1.TabIndex = 13;
            this.label1.Text = "Score:";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 853);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numMaxBounceAngle);
            this.Controls.Add(this.numMinBounceAngle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblScoreBoard);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbDifficultyLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Breakout";
            this.Load += new System.EventHandler(this.Game_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Game_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numMinBounceAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxBounceAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox cbDifficultyLevel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblScoreBoard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMinBounceAngle;
        private System.Windows.Forms.NumericUpDown numMaxBounceAngle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}

