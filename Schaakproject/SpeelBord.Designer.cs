namespace Schaakproject
{
    partial class SpeelBord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeelBord));
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.btHerstart = new System.Windows.Forms.Button();
            this.lblResterend1 = new System.Windows.Forms.Label();
            this.lblResterend2 = new System.Windows.Forms.Label();
            this.lblaantal2 = new System.Windows.Forms.Label();
            this.lblaantal1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Location = new System.Drawing.Point(82, 493);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(45, 13);
            this.lblPlayer1.TabIndex = 0;
            this.lblPlayer1.Text = "Player 1";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Location = new System.Drawing.Point(82, 9);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(45, 13);
            this.lblPlayer2.TabIndex = 1;
            this.lblPlayer2.Text = "Player 2";
            // 
            // btHerstart
            // 
            this.btHerstart.Location = new System.Drawing.Point(651, 488);
            this.btHerstart.Name = "btHerstart";
            this.btHerstart.Size = new System.Drawing.Size(75, 23);
            this.btHerstart.TabIndex = 2;
            this.btHerstart.Text = "Herstart";
            this.btHerstart.UseVisualStyleBackColor = true;
            this.btHerstart.Click += new System.EventHandler(this.btHerstart_Click);
            // 
            // lblResterend1
            // 
            this.lblResterend1.AutoSize = true;
            this.lblResterend1.Location = new System.Drawing.Point(260, 493);
            this.lblResterend1.Name = "lblResterend1";
            this.lblResterend1.Size = new System.Drawing.Size(108, 13);
            this.lblResterend1.TabIndex = 3;
            this.lblResterend1.Text = "Resterende Stukken:";
            // 
            // lblResterend2
            // 
            this.lblResterend2.AutoSize = true;
            this.lblResterend2.Location = new System.Drawing.Point(260, 9);
            this.lblResterend2.Name = "lblResterend2";
            this.lblResterend2.Size = new System.Drawing.Size(108, 13);
            this.lblResterend2.TabIndex = 4;
            this.lblResterend2.Text = "Resterende Stukken:";
            // 
            // lblaantal2
            // 
            this.lblaantal2.AutoSize = true;
            this.lblaantal2.Location = new System.Drawing.Point(375, 9);
            this.lblaantal2.Name = "lblaantal2";
            this.lblaantal2.Size = new System.Drawing.Size(35, 13);
            this.lblaantal2.TabIndex = 5;
            this.lblaantal2.Text = "label1";
            // 
            // lblaantal1
            // 
            this.lblaantal1.AutoSize = true;
            this.lblaantal1.Location = new System.Drawing.Point(375, 493);
            this.lblaantal1.Name = "lblaantal1";
            this.lblaantal1.Size = new System.Drawing.Size(35, 13);
            this.lblaantal1.TabIndex = 6;
            this.lblaantal1.Text = "label2";
            // 
            // SpeelBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(738, 540);
            this.Controls.Add(this.lblaantal1);
            this.Controls.Add(this.lblaantal2);
            this.Controls.Add(this.lblResterend2);
            this.Controls.Add(this.lblResterend1);
            this.Controls.Add(this.btHerstart);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpeelBord";
            this.Text = "SpeelBord";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SpeelBord_FormClosed);
            this.Load += new System.EventHandler(this.SpeelBord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Button btHerstart;
        private System.Windows.Forms.Label lblResterend1;
        private System.Windows.Forms.Label lblResterend2;
        private System.Windows.Forms.Label lblaantal2;
        private System.Windows.Forms.Label lblaantal1;
    }
}