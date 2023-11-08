namespace Assignment2Prj
{
    partial class Welcome
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
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pictureBoxWelcome
            // 
            this.pictureBoxWelcome.Location = new System.Drawing.Point(1, 0);
            this.pictureBoxWelcome.Name = "pictureBoxWelcome";
            this.pictureBoxWelcome.Size = new System.Drawing.Size(763, 623);
            this.pictureBoxWelcome.TabIndex = 0;
            this.pictureBoxWelcome.TabStop = false;
            this.pictureBoxWelcome.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxWelcome_Paint);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 622);
            this.Controls.Add(this.pictureBoxWelcome);
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.Shown += new System.EventHandler(this.Welcome_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Welcome_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;
    }
}