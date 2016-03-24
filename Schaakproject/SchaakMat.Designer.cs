namespace Schaakproject
{
    partial class SchaakMat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchaakMat));
            this.lbl_gewonnen = new System.Windows.Forms.Label();
            this.lbl_opnieuw = new System.Windows.Forms.Label();
            this.btn_ja = new System.Windows.Forms.Button();
            this.btn_nee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_gewonnen
            // 
            this.lbl_gewonnen.AutoSize = true;
            this.lbl_gewonnen.Location = new System.Drawing.Point(116, 9);
            this.lbl_gewonnen.Name = "lbl_gewonnen";
            this.lbl_gewonnen.Size = new System.Drawing.Size(29, 13);
            this.lbl_gewonnen.TabIndex = 0;
            this.lbl_gewonnen.Text = "label";
            this.lbl_gewonnen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_opnieuw
            // 
            this.lbl_opnieuw.AutoSize = true;
            this.lbl_opnieuw.Location = new System.Drawing.Point(84, 33);
            this.lbl_opnieuw.Name = "lbl_opnieuw";
            this.lbl_opnieuw.Size = new System.Drawing.Size(116, 13);
            this.lbl_opnieuw.TabIndex = 1;
            this.lbl_opnieuw.Text = "Wil je opnieuw spelen?";
            // 
            // btn_ja
            // 
            this.btn_ja.Location = new System.Drawing.Point(50, 57);
            this.btn_ja.Name = "btn_ja";
            this.btn_ja.Size = new System.Drawing.Size(75, 23);
            this.btn_ja.TabIndex = 2;
            this.btn_ja.Text = "Ja";
            this.btn_ja.UseVisualStyleBackColor = true;
            this.btn_ja.Click += new System.EventHandler(this.btn_ja_Click);
            // 
            // btn_nee
            // 
            this.btn_nee.Location = new System.Drawing.Point(154, 57);
            this.btn_nee.Name = "btn_nee";
            this.btn_nee.Size = new System.Drawing.Size(75, 23);
            this.btn_nee.TabIndex = 3;
            this.btn_nee.Text = "Nee";
            this.btn_nee.UseVisualStyleBackColor = true;
            this.btn_nee.Click += new System.EventHandler(this.btn_nee_Click);
            // 
            // SchaakMat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 92);
            this.Controls.Add(this.btn_nee);
            this.Controls.Add(this.btn_ja);
            this.Controls.Add(this.lbl_opnieuw);
            this.Controls.Add(this.lbl_gewonnen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SchaakMat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Winnaar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_gewonnen;
        private System.Windows.Forms.Label lbl_opnieuw;
        private System.Windows.Forms.Button btn_ja;
        private System.Windows.Forms.Button btn_nee;
    }
}