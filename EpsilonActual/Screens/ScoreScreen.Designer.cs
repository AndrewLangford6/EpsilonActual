namespace EpsilonActual
{
    partial class ScoreScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(51, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 299);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Mr. Weston - 9999\r\n2. ------------\r\n3. ------------\r\n4. ------------\r\n5. -----" +
    "-------\r\n6. ------------\r\n7. ------------\r\n8. ------------\r\n9. ------------\r\n10." +
    " ------------\r\n\r\n\r\n \r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(81, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "High Scores";
            // 
            // ScoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::EpsilonActual.Properties.Resources.FLOOR1;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ScoreScreen";
            this.Size = new System.Drawing.Size(294, 264);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ScoreScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
