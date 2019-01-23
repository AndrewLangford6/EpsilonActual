namespace EpsilonActual
{
    partial class PauseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PauseForm));
            this.continueButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(34)))));
            this.continueButton.Location = new System.Drawing.Point(48, 56);
            this.continueButton.Margin = new System.Windows.Forms.Padding(2);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(120, 42);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            this.continueButton.Enter += new System.EventHandler(this.button_Enter);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(34)))));
            this.exitButton.Location = new System.Drawing.Point(48, 120);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(120, 42);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.Enter += new System.EventHandler(this.button_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(208, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 216);
            this.label1.TabIndex = 2;
            this.label1.Text = "Controls:\r\n\r\nX to Shoot\r\nY to Jump\r\nArrow Keys to Move\r\n\r\nCurrent Objective:\r\nSur" +
    "vive!\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PauseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EpsilonActual.Properties.Resources.FLOOR1;
            this.ClientSize = new System.Drawing.Size(463, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.continueButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PauseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAUSE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
    }
}