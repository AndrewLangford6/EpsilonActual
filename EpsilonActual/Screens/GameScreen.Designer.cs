namespace EpsilonActual
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.hpLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.hpBar = new System.Windows.Forms.ProgressBar();
            this.winloseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // hpLabel
            // 
            this.hpLabel.AutoSize = true;
            this.hpLabel.BackColor = System.Drawing.Color.Transparent;
            this.hpLabel.ForeColor = System.Drawing.Color.White;
            this.hpLabel.Location = new System.Drawing.Point(3, 0);
            this.hpLabel.Name = "hpLabel";
            this.hpLabel.Size = new System.Drawing.Size(29, 13);
            this.hpLabel.TabIndex = 0;
            this.hpLabel.Text = "label";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(260, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(29, 13);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "label";
            this.scoreLabel.Click += new System.EventHandler(this.scoreLabel_Click);
            // 
            // hpBar
            // 
            this.hpBar.ForeColor = System.Drawing.Color.Red;
            this.hpBar.Location = new System.Drawing.Point(27, 3);
            this.hpBar.Maximum = 200;
            this.hpBar.Name = "hpBar";
            this.hpBar.Size = new System.Drawing.Size(100, 12);
            this.hpBar.TabIndex = 2;
            // 
            // winloseLabel
            // 
            this.winloseLabel.BackColor = System.Drawing.Color.Transparent;
            this.winloseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winloseLabel.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winloseLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.winloseLabel.Location = new System.Drawing.Point(3, 34);
            this.winloseLabel.Name = "winloseLabel";
            this.winloseLabel.Size = new System.Drawing.Size(319, 241);
            this.winloseLabel.TabIndex = 3;
            this.winloseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.winloseLabel);
            this.Controls.Add(this.hpBar);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.hpLabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(325, 325);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label hpLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.ProgressBar hpBar;
        public System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label winloseLabel;
    }
}
