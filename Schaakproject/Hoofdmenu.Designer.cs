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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hoofdmenu));
            this.herstartButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.lblTmpSpeler1 = new System.Windows.Forms.Label();
            this.lblTmpSpeler2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // herstartButton
            // 
            this.herstartButton.Location = new System.Drawing.Point(22, 168);
            this.herstartButton.Name = "herstartButton";
            this.herstartButton.Size = new System.Drawing.Size(75, 23);
            this.herstartButton.TabIndex = 0;
            this.herstartButton.Text = "Herstart";
            this.herstartButton.UseVisualStyleBackColor = true;
            this.herstartButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.herstartButton_MouseClick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(22, 139);
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
            this.lblTmpSpeler1.Location = new System.Drawing.Point(12, 9);
            this.lblTmpSpeler1.Name = "lblTmpSpeler1";
            this.lblTmpSpeler1.Size = new System.Drawing.Size(46, 13);
            this.lblTmpSpeler1.TabIndex = 2;
            this.lblTmpSpeler1.Text = "Speler 1";
            // 
            // lblTmpSpeler2
            // 
            this.lblTmpSpeler2.AutoSize = true;
            this.lblTmpSpeler2.Location = new System.Drawing.Point(469, 9);
            this.lblTmpSpeler2.Name = "lblTmpSpeler2";
            this.lblTmpSpeler2.Size = new System.Drawing.Size(46, 13);
            this.lblTmpSpeler2.TabIndex = 3;
            this.lblTmpSpeler2.Text = "Speler 2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.lblTmpSpeler2);
            this.panel1.Controls.Add(this.lblTmpSpeler1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 29);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.startButton);
            this.panel2.Controls.Add(this.herstartButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(418, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(109, 428);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Hoofdmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 457);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hoofdmenu";
            this.Text = "Schaakspel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button herstartButton;
        private System.Windows.Forms.Button startButton;
        public System.Windows.Forms.Label lblTmpSpeler1;
        public System.Windows.Forms.Label lblTmpSpeler2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

