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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NaamInvoer));
            this.txtSpeler1Naam = new System.Windows.Forms.TextBox();
            this.lblSpeler1Naam = new System.Windows.Forms.Label();
            this.btnBegin = new System.Windows.Forms.Button();
            this.txtSpeler2Naam = new System.Windows.Forms.TextBox();
            this.lblSpeler2Naam = new System.Windows.Forms.Label();
            this.btModeMultiplayer = new System.Windows.Forms.Button();
            this.btModeComputer = new System.Windows.Forms.Button();
            this.btModeRealMulti = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.lblDontPress = new System.Windows.Forms.Label();
            this.btTerug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSpeler1Naam
            // 
            this.txtSpeler1Naam.Location = new System.Drawing.Point(205, 111);
            this.txtSpeler1Naam.Name = "txtSpeler1Naam";
            this.txtSpeler1Naam.Size = new System.Drawing.Size(100, 20);
            this.txtSpeler1Naam.TabIndex = 0;
            this.txtSpeler1Naam.Visible = false;
            // 
            // lblSpeler1Naam
            // 
            this.lblSpeler1Naam.AutoSize = true;
            this.lblSpeler1Naam.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeler1Naam.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSpeler1Naam.Location = new System.Drawing.Point(213, 71);
            this.lblSpeler1Naam.Name = "lblSpeler1Naam";
            this.lblSpeler1Naam.Size = new System.Drawing.Size(83, 13);
            this.lblSpeler1Naam.TabIndex = 1;
            this.lblSpeler1Naam.Text = "Voer je naam in:";
            this.lblSpeler1Naam.Visible = false;
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.Transparent;
            this.btnBegin.BackgroundImage = global::Schaakproject.Properties.Resources.buttonBegin1;
            this.btnBegin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBegin.FlatAppearance.BorderSize = 0;
            this.btnBegin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBegin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBegin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBegin.ForeColor = System.Drawing.Color.Transparent;
            this.btnBegin.Location = new System.Drawing.Point(158, 365);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(200, 78);
            this.btnBegin.TabIndex = 2;
            this.btnBegin.UseVisualStyleBackColor = false;
            this.btnBegin.Visible = false;
            this.btnBegin.Click += new System.EventHandler(this.btnNaamSubmit_Click);
            this.btnBegin.MouseEnter += new System.EventHandler(this.btnBegin_MouseEnter);
            this.btnBegin.MouseLeave += new System.EventHandler(this.btnBegin_MouseLeave);
            // 
            // txtSpeler2Naam
            // 
            this.txtSpeler2Naam.Location = new System.Drawing.Point(205, 174);
            this.txtSpeler2Naam.Name = "txtSpeler2Naam";
            this.txtSpeler2Naam.Size = new System.Drawing.Size(100, 20);
            this.txtSpeler2Naam.TabIndex = 3;
            this.txtSpeler2Naam.Visible = false;
            // 
            // lblSpeler2Naam
            // 
            this.lblSpeler2Naam.AutoSize = true;
            this.lblSpeler2Naam.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeler2Naam.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSpeler2Naam.Location = new System.Drawing.Point(202, 140);
            this.lblSpeler2Naam.Name = "lblSpeler2Naam";
            this.lblSpeler2Naam.Size = new System.Drawing.Size(110, 13);
            this.lblSpeler2Naam.TabIndex = 4;
            this.lblSpeler2Naam.Text = "Tegenstanders naam:";
            this.lblSpeler2Naam.Visible = false;
            // 
            // btModeMultiplayer
            // 
            this.btModeMultiplayer.BackColor = System.Drawing.Color.Transparent;
            this.btModeMultiplayer.BackgroundImage = global::Schaakproject.Properties.Resources.button1Klad;
            this.btModeMultiplayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btModeMultiplayer.FlatAppearance.BorderSize = 0;
            this.btModeMultiplayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btModeMultiplayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btModeMultiplayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModeMultiplayer.Location = new System.Drawing.Point(185, 87);
            this.btModeMultiplayer.Name = "btModeMultiplayer";
            this.btModeMultiplayer.Size = new System.Drawing.Size(150, 66);
            this.btModeMultiplayer.TabIndex = 5;
            this.btModeMultiplayer.UseVisualStyleBackColor = false;
            this.btModeMultiplayer.Click += new System.EventHandler(this.btModeMultiplayer_Click);
            this.btModeMultiplayer.MouseEnter += new System.EventHandler(this.btModeMultiplayer_MouseEnter);
            this.btModeMultiplayer.MouseLeave += new System.EventHandler(this.btModeMultiplayer_MouseLeave);
            // 
            // btModeComputer
            // 
            this.btModeComputer.BackColor = System.Drawing.Color.Transparent;
            this.btModeComputer.BackgroundImage = global::Schaakproject.Properties.Resources.button2Klad;
            this.btModeComputer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btModeComputer.FlatAppearance.BorderSize = 0;
            this.btModeComputer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btModeComputer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btModeComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModeComputer.ForeColor = System.Drawing.Color.Transparent;
            this.btModeComputer.Location = new System.Drawing.Point(185, 32);
            this.btModeComputer.Name = "btModeComputer";
            this.btModeComputer.Size = new System.Drawing.Size(150, 63);
            this.btModeComputer.TabIndex = 6;
            this.btModeComputer.UseVisualStyleBackColor = false;
            this.btModeComputer.Click += new System.EventHandler(this.btModeComputer_Click);
            this.btModeComputer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btModeComputer_KeyPress);
            this.btModeComputer.MouseEnter += new System.EventHandler(this.btModeComputer_MouseEnter);
            this.btModeComputer.MouseLeave += new System.EventHandler(this.btModeComputer_MouseLeave);
            // 
            // btModeRealMulti
            // 
            this.btModeRealMulti.BackColor = System.Drawing.Color.Transparent;
            this.btModeRealMulti.BackgroundImage = global::Schaakproject.Properties.Resources.button3Klad;
            this.btModeRealMulti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btModeRealMulti.FlatAppearance.BorderSize = 0;
            this.btModeRealMulti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btModeRealMulti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btModeRealMulti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModeRealMulti.Location = new System.Drawing.Point(185, 142);
            this.btModeRealMulti.Name = "btModeRealMulti";
            this.btModeRealMulti.Size = new System.Drawing.Size(150, 63);
            this.btModeRealMulti.TabIndex = 7;
            this.btModeRealMulti.UseVisualStyleBackColor = false;
            this.btModeRealMulti.Click += new System.EventHandler(this.btModeRealMulti_Click);
            this.btModeRealMulti.MouseEnter += new System.EventHandler(this.btModeRealMulti_MouseEnter);
            this.btModeRealMulti.MouseLeave += new System.EventHandler(this.btModeRealMulti_MouseLeave);
            // 
            // lbTitel
            // 
            this.lbTitel.BackColor = System.Drawing.Color.Transparent;
            this.lbTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.ForeColor = System.Drawing.Color.White;
            this.lbTitel.Location = new System.Drawing.Point(12, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(490, 20);
            this.lbTitel.TabIndex = 8;
            this.lbTitel.Text = "Selecteer een schaakmode";
            this.lbTitel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDontPress
            // 
            this.lblDontPress.AutoSize = true;
            this.lblDontPress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDontPress.ForeColor = System.Drawing.Color.Red;
            this.lblDontPress.Location = new System.Drawing.Point(155, 396);
            this.lblDontPress.Name = "lblDontPress";
            this.lblDontPress.Size = new System.Drawing.Size(227, 16);
            this.lblDontPress.TabIndex = 11;
            this.lblDontPress.Text = "Don\'t press the goddamn button";
            this.lblDontPress.Visible = false;
            // 
            // btTerug
            // 
            this.btTerug.BackColor = System.Drawing.Color.Transparent;
            this.btTerug.BackgroundImage = global::Schaakproject.Properties.Resources.backIcon;
            this.btTerug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btTerug.FlatAppearance.BorderSize = 0;
            this.btTerug.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btTerug.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btTerug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTerug.Location = new System.Drawing.Point(94, 9);
            this.btTerug.Name = "btTerug";
            this.btTerug.Size = new System.Drawing.Size(41, 32);
            this.btTerug.TabIndex = 12;
            this.btTerug.UseVisualStyleBackColor = false;
            this.btTerug.Click += new System.EventHandler(this.button1_Click);
            this.btTerug.MouseEnter += new System.EventHandler(this.btTerug_MouseEnter);
            this.btTerug.MouseLeave += new System.EventHandler(this.btTerug_MouseLeave);
            // 
            // NaamInvoer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(514, 455);
            this.Controls.Add(this.btTerug);
            this.Controls.Add(this.lblDontPress);
            this.Controls.Add(this.txtSpeler1Naam);
            this.Controls.Add(this.btModeRealMulti);
            this.Controls.Add(this.btModeComputer);
            this.Controls.Add(this.btModeMultiplayer);
            this.Controls.Add(this.lblSpeler2Naam);
            this.Controls.Add(this.txtSpeler2Naam);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.lblSpeler1Naam);
            this.Controls.Add(this.lbTitel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NaamInvoer";
            this.Text = "Voer je naam in";
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
        private System.Windows.Forms.Label lblDontPress;
        private System.Windows.Forms.Button btTerug;
    }
}