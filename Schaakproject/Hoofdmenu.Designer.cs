namespace Schaakproject
{
    partial class Hoofdmenu
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
            this.herstartButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.lblTmpSpeler1 = new System.Windows.Forms.Label();
            this.lblTmpSpeler2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // herstartButton
            // 
            this.herstartButton.Location = new System.Drawing.Point(440, 422);
            this.herstartButton.Name = "herstartButton";
            this.herstartButton.Size = new System.Drawing.Size(75, 23);
            this.herstartButton.TabIndex = 0;
            this.herstartButton.Text = "Herstart";
            this.herstartButton.UseVisualStyleBackColor = true;
            this.herstartButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.herstartButton_MouseClick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(217, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // lblTmpSpeler1
            // 
            this.lblTmpSpeler1.AutoSize = true;
            this.lblTmpSpeler1.Location = new System.Drawing.Point(241, 125);
            this.lblTmpSpeler1.Name = "lblTmpSpeler1";
            this.lblTmpSpeler1.Size = new System.Drawing.Size(37, 13);
            this.lblTmpSpeler1.TabIndex = 2;
            this.lblTmpSpeler1.Text = "TEMP";
            // 
            // lblTmpSpeler2
            // 
            this.lblTmpSpeler2.AutoSize = true;
            this.lblTmpSpeler2.Location = new System.Drawing.Point(241, 162);
            this.lblTmpSpeler2.Name = "lblTmpSpeler2";
            this.lblTmpSpeler2.Size = new System.Drawing.Size(37, 13);
            this.lblTmpSpeler2.TabIndex = 3;
            this.lblTmpSpeler2.Text = "TEMP";
            // 
            // Hoofdmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 457);
            this.Controls.Add(this.lblTmpSpeler2);
            this.Controls.Add(this.lblTmpSpeler1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.herstartButton);
            this.Name = "Hoofdmenu";
            this.Text = "Schaakspel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button herstartButton;
        private System.Windows.Forms.Button startButton;
        public System.Windows.Forms.Label lblTmpSpeler1;
        public System.Windows.Forms.Label lblTmpSpeler2;
    }
}

