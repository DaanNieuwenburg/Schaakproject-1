﻿namespace Schaakproject
{
    partial class RemiseMelding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemiseMelding));
            this.lbl_remise = new System.Windows.Forms.Label();
            this.btn_ja = new System.Windows.Forms.Button();
            this.btn_nee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_remise
            // 
            this.lbl_remise.AutoSize = true;
            this.lbl_remise.Location = new System.Drawing.Point(81, 12);
            this.lbl_remise.Name = "lbl_remise";
            this.lbl_remise.Size = new System.Drawing.Size(119, 26);
            this.lbl_remise.TabIndex = 0;
            this.lbl_remise.Text = "Remise! \n Wil je opnieuw spelen?";
            this.lbl_remise.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_ja
            // 
            this.btn_ja.Location = new System.Drawing.Point(37, 57);
            this.btn_ja.Name = "btn_ja";
            this.btn_ja.Size = new System.Drawing.Size(75, 23);
            this.btn_ja.TabIndex = 1;
            this.btn_ja.Text = "Ja";
            this.btn_ja.UseVisualStyleBackColor = true;
            this.btn_ja.Click += new System.EventHandler(this.btn_ja_Click);
            // 
            // btn_nee
            // 
            this.btn_nee.Location = new System.Drawing.Point(166, 57);
            this.btn_nee.Name = "btn_nee";
            this.btn_nee.Size = new System.Drawing.Size(75, 23);
            this.btn_nee.TabIndex = 2;
            this.btn_nee.Text = "Nee";
            this.btn_nee.UseVisualStyleBackColor = true;
            this.btn_nee.Click += new System.EventHandler(this.btn_nee_Click);
            // 
            // RemiseMelding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 92);
            this.Controls.Add(this.btn_nee);
            this.Controls.Add(this.btn_ja);
            this.Controls.Add(this.lbl_remise);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemiseMelding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remise";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_remise;
        private System.Windows.Forms.Button btn_ja;
        private System.Windows.Forms.Button btn_nee;
    }
}