﻿namespace Schaakproject
{
    partial class NaamInvoer
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
            this.txtSpeler1Naam = new System.Windows.Forms.TextBox();
            this.lblSpeler1Naam = new System.Windows.Forms.Label();
            this.btnBegin = new System.Windows.Forms.Button();
            this.txtSpeler2Naam = new System.Windows.Forms.TextBox();
            this.lblSpeler2Naam = new System.Windows.Forms.Label();
            this.btModeMultiplayer = new System.Windows.Forms.Button();
            this.btModeComputer = new System.Windows.Forms.Button();
            this.btModeRealMulti = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.lblNotImplented = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSpeler1Naam
            // 
            this.txtSpeler1Naam.Location = new System.Drawing.Point(12, 143);
            this.txtSpeler1Naam.Name = "txtSpeler1Naam";
            this.txtSpeler1Naam.Size = new System.Drawing.Size(100, 20);
            this.txtSpeler1Naam.TabIndex = 0;
            this.txtSpeler1Naam.Visible = false;
            // 
            // lblSpeler1Naam
            // 
            this.lblSpeler1Naam.AutoSize = true;
            this.lblSpeler1Naam.Location = new System.Drawing.Point(9, 127);
            this.lblSpeler1Naam.Name = "lblSpeler1Naam";
            this.lblSpeler1Naam.Size = new System.Drawing.Size(83, 13);
            this.lblSpeler1Naam.TabIndex = 1;
            this.lblSpeler1Naam.Text = "Voer je naam in:";
            this.lblSpeler1Naam.Visible = false;
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(104, 226);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 2;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Visible = false;
            this.btnBegin.Click += new System.EventHandler(this.btnNaamSubmit_Click);
            // 
            // txtSpeler2Naam
            // 
            this.txtSpeler2Naam.Location = new System.Drawing.Point(172, 143);
            this.txtSpeler2Naam.Name = "txtSpeler2Naam";
            this.txtSpeler2Naam.Size = new System.Drawing.Size(100, 20);
            this.txtSpeler2Naam.TabIndex = 3;
            this.txtSpeler2Naam.Visible = false;
            // 
            // lblSpeler2Naam
            // 
            this.lblSpeler2Naam.AutoSize = true;
            this.lblSpeler2Naam.Location = new System.Drawing.Point(169, 127);
            this.lblSpeler2Naam.Name = "lblSpeler2Naam";
            this.lblSpeler2Naam.Size = new System.Drawing.Size(110, 13);
            this.lblSpeler2Naam.TabIndex = 4;
            this.lblSpeler2Naam.Text = "Tegenstanders naam:";
            this.lblSpeler2Naam.Visible = false;
            // 
            // btModeMultiplayer
            // 
            this.btModeMultiplayer.Location = new System.Drawing.Point(12, 56);
            this.btModeMultiplayer.Name = "btModeMultiplayer";
            this.btModeMultiplayer.Size = new System.Drawing.Size(75, 23);
            this.btModeMultiplayer.TabIndex = 5;
            this.btModeMultiplayer.Text = "Multiplayer";
            this.btModeMultiplayer.UseVisualStyleBackColor = true;
            this.btModeMultiplayer.Click += new System.EventHandler(this.btModeMultiplayer_Click);
            // 
            // btModeComputer
            // 
            this.btModeComputer.Location = new System.Drawing.Point(104, 56);
            this.btModeComputer.Name = "btModeComputer";
            this.btModeComputer.Size = new System.Drawing.Size(75, 23);
            this.btModeComputer.TabIndex = 6;
            this.btModeComputer.Text = "Computer";
            this.btModeComputer.UseVisualStyleBackColor = true;
            this.btModeComputer.Click += new System.EventHandler(this.btModeComputer_Click);
            // 
            // btModeRealMulti
            // 
            this.btModeRealMulti.Location = new System.Drawing.Point(197, 56);
            this.btModeRealMulti.Name = "btModeRealMulti";
            this.btModeRealMulti.Size = new System.Drawing.Size(75, 23);
            this.btModeRealMulti.TabIndex = 7;
            this.btModeRealMulti.Text = "Real Multi";
            this.btModeRealMulti.UseVisualStyleBackColor = true;
            this.btModeRealMulti.Click += new System.EventHandler(this.btModeRealMulti_Click);
            // 
            // lbTitel
            // 
            this.lbTitel.AutoSize = true;
            this.lbTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.Location = new System.Drawing.Point(8, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(227, 20);
            this.lbTitel.TabIndex = 8;
            this.lbTitel.Text = "Selecteer een schaakmode";
            // 
            // lblNotImplented
            // 
            this.lblNotImplented.AutoSize = true;
            this.lblNotImplented.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotImplented.ForeColor = System.Drawing.Color.Red;
            this.lblNotImplented.Location = new System.Drawing.Point(88, 229);
            this.lblNotImplented.Name = "lblNotImplented";
            this.lblNotImplented.Size = new System.Drawing.Size(108, 16);
            this.lblNotImplented.TabIndex = 9;
            this.lblNotImplented.Text = "Not implented.";
            this.lblNotImplented.Visible = false;
            // 
            // NaamInvoer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblNotImplented);
            this.Controls.Add(this.lbTitel);
            this.Controls.Add(this.btModeRealMulti);
            this.Controls.Add(this.btModeComputer);
            this.Controls.Add(this.btModeMultiplayer);
            this.Controls.Add(this.lblSpeler2Naam);
            this.Controls.Add(this.txtSpeler2Naam);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.lblSpeler1Naam);
            this.Controls.Add(this.txtSpeler1Naam);
            this.Name = "NaamInvoer";
            this.Text = "Voer je naam in";
            this.Load += new System.EventHandler(this.NaamInvoer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSpeler1Naam;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Label lblSpeler2Naam;
        public System.Windows.Forms.TextBox txtSpeler1Naam;
        public System.Windows.Forms.TextBox txtSpeler2Naam;
        private System.Windows.Forms.Button btModeMultiplayer;
        private System.Windows.Forms.Button btModeComputer;
        private System.Windows.Forms.Button btModeRealMulti;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Label lblNotImplented;
    }
}