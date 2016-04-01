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
            this.lblaantal1 = new System.Windows.Forms.Label();
            this.lblaantal2 = new System.Windows.Forms.Label();
            this.lblaanzet = new System.Windows.Forms.Label();
            this.lbluitleg = new System.Windows.Forms.Label();
            this.btnregels = new System.Windows.Forms.Button();
            this.btnvariant = new System.Windows.Forms.Button();
            this.btnpaard = new System.Windows.Forms.Button();
            this.btntoren = new System.Windows.Forms.Button();
            this.btnloper = new System.Windows.Forms.Button();
            this.btndame = new System.Windows.Forms.Button();
            this.btnkoning = new System.Windows.Forms.Button();
            this.btnpion = new System.Windows.Forms.Button();
            this.btnterug = new System.Windows.Forms.Button();
            this.pbuitleg = new System.Windows.Forms.PictureBox();
            this.lblbeurt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbuitleg)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPlayer1.Location = new System.Drawing.Point(68, 504);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(26, 18);
            this.lblPlayer1.TabIndex = 0;
            this.lblPlayer1.Text = "P1";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPlayer2.Location = new System.Drawing.Point(68, 9);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(26, 18);
            this.lblPlayer2.TabIndex = 1;
            this.lblPlayer2.Text = "P2";
            // 
            // btHerstart
            // 
            this.btHerstart.BackColor = System.Drawing.Color.Transparent;
            this.btHerstart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btHerstart.FlatAppearance.BorderSize = 0;
            this.btHerstart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btHerstart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btHerstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHerstart.Location = new System.Drawing.Point(625, 453);
            this.btHerstart.Name = "btHerstart";
            this.btHerstart.Size = new System.Drawing.Size(102, 35);
            this.btHerstart.TabIndex = 2;
            this.btHerstart.UseVisualStyleBackColor = false;
            this.btHerstart.Click += new System.EventHandler(this.btHerstart_Click);
            this.btHerstart.MouseEnter += new System.EventHandler(this.btHerstart_MouseEnter);
            this.btHerstart.MouseLeave += new System.EventHandler(this.btHerstart_MouseLeave);
            // 
            // lblResterend1
            // 
            this.lblResterend1.AutoSize = true;
            this.lblResterend1.BackColor = System.Drawing.Color.Transparent;
            this.lblResterend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResterend1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblResterend1.Location = new System.Drawing.Point(260, 504);
            this.lblResterend1.Name = "lblResterend1";
            this.lblResterend1.Size = new System.Drawing.Size(146, 18);
            this.lblResterend1.TabIndex = 3;
            this.lblResterend1.Text = "Resterende Stukken:";
            // 
            // lblResterend2
            // 
            this.lblResterend2.AutoSize = true;
            this.lblResterend2.BackColor = System.Drawing.Color.Transparent;
            this.lblResterend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResterend2.ForeColor = System.Drawing.SystemColors.Control;
            this.lblResterend2.Location = new System.Drawing.Point(260, 9);
            this.lblResterend2.Name = "lblResterend2";
            this.lblResterend2.Size = new System.Drawing.Size(146, 18);
            this.lblResterend2.TabIndex = 4;
            this.lblResterend2.Text = "Resterende Stukken:";
            // 
            // lblaantal1
            // 
            this.lblaantal1.AutoSize = true;
            this.lblaantal1.BackColor = System.Drawing.Color.Transparent;
            this.lblaantal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblaantal1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblaantal1.Location = new System.Drawing.Point(407, 9);
            this.lblaantal1.Name = "lblaantal1";
            this.lblaantal1.Size = new System.Drawing.Size(0, 18);
            this.lblaantal1.TabIndex = 5;
            // 
            // lblaantal2
            // 
            this.lblaantal2.AutoSize = true;
            this.lblaantal2.BackColor = System.Drawing.Color.Transparent;
            this.lblaantal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblaantal2.ForeColor = System.Drawing.SystemColors.Control;
            this.lblaantal2.Location = new System.Drawing.Point(406, 504);
            this.lblaantal2.Name = "lblaantal2";
            this.lblaantal2.Size = new System.Drawing.Size(0, 18);
            this.lblaantal2.TabIndex = 6;
            // 
            // lblaanzet
            // 
            this.lblaanzet.AutoSize = true;
            this.lblaanzet.Location = new System.Drawing.Point(561, 9);
            this.lblaanzet.Name = "lblaanzet";
            this.lblaanzet.Size = new System.Drawing.Size(0, 13);
            this.lblaanzet.TabIndex = 7;
            // 
            // lbluitleg
            // 
            this.lbluitleg.AutoSize = true;
            this.lbluitleg.BackColor = System.Drawing.Color.Transparent;
            this.lbluitleg.ForeColor = System.Drawing.Color.White;
            this.lbluitleg.Location = new System.Drawing.Point(475, 79);
            this.lbluitleg.Name = "lbluitleg";
            this.lbluitleg.Size = new System.Drawing.Size(0, 13);
            this.lbluitleg.TabIndex = 8;
            this.lbluitleg.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnregels
            // 
            this.btnregels.BackColor = System.Drawing.Color.Transparent;
            this.btnregels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnregels.FlatAppearance.BorderSize = 0;
            this.btnregels.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnregels.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnregels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnregels.Location = new System.Drawing.Point(624, 34);
            this.btnregels.Name = "btnregels";
            this.btnregels.Size = new System.Drawing.Size(102, 37);
            this.btnregels.TabIndex = 9;
            this.btnregels.UseVisualStyleBackColor = true;
            this.btnregels.Visible = false;
            this.btnregels.Click += new System.EventHandler(this.btnregels_Click);
            this.btnregels.MouseEnter += new System.EventHandler(this.btnregels_MouseEnter);
            this.btnregels.MouseLeave += new System.EventHandler(this.btnregels_MouseLeave);
            // 
            // btnvariant
            // 
            this.btnvariant.BackColor = System.Drawing.Color.Transparent;
            this.btnvariant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnvariant.FlatAppearance.BorderSize = 0;
            this.btnvariant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnvariant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnvariant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvariant.Location = new System.Drawing.Point(536, 73);
            this.btnvariant.Name = "btnvariant";
            this.btnvariant.Size = new System.Drawing.Size(191, 52);
            this.btnvariant.TabIndex = 10;
            this.btnvariant.UseVisualStyleBackColor = false;
            this.btnvariant.Visible = false;
            this.btnvariant.Click += new System.EventHandler(this.btnvariant_Click);
            this.btnvariant.MouseEnter += new System.EventHandler(this.btnvariant_MouseEnter);
            this.btnvariant.MouseLeave += new System.EventHandler(this.btnvariant_MouseLeave);
            // 
            // btnpaard
            // 
            this.btnpaard.BackColor = System.Drawing.Color.Transparent;
            this.btnpaard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnpaard.FlatAppearance.BorderSize = 0;
            this.btnpaard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnpaard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnpaard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpaard.Location = new System.Drawing.Point(536, 131);
            this.btnpaard.Name = "btnpaard";
            this.btnpaard.Size = new System.Drawing.Size(191, 42);
            this.btnpaard.TabIndex = 11;
            this.btnpaard.UseVisualStyleBackColor = false;
            this.btnpaard.Visible = false;
            this.btnpaard.Click += new System.EventHandler(this.btnpaard_Click);
            this.btnpaard.MouseEnter += new System.EventHandler(this.btnpaard_MouseEnter);
            this.btnpaard.MouseLeave += new System.EventHandler(this.btnpaard_MouseLeave);
            // 
            // btntoren
            // 
            this.btntoren.BackColor = System.Drawing.Color.Transparent;
            this.btntoren.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btntoren.FlatAppearance.BorderSize = 0;
            this.btntoren.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btntoren.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btntoren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntoren.Location = new System.Drawing.Point(536, 179);
            this.btntoren.Name = "btntoren";
            this.btntoren.Size = new System.Drawing.Size(191, 42);
            this.btntoren.TabIndex = 12;
            this.btntoren.UseVisualStyleBackColor = false;
            this.btntoren.Visible = false;
            this.btntoren.Click += new System.EventHandler(this.btntoren_Click);
            this.btntoren.MouseEnter += new System.EventHandler(this.btntoren_MouseEnter);
            this.btntoren.MouseLeave += new System.EventHandler(this.btntoren_MouseLeave);
            // 
            // btnloper
            // 
            this.btnloper.BackColor = System.Drawing.Color.Transparent;
            this.btnloper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnloper.FlatAppearance.BorderSize = 0;
            this.btnloper.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnloper.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnloper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloper.Location = new System.Drawing.Point(535, 227);
            this.btnloper.Name = "btnloper";
            this.btnloper.Size = new System.Drawing.Size(191, 48);
            this.btnloper.TabIndex = 13;
            this.btnloper.UseVisualStyleBackColor = false;
            this.btnloper.Visible = false;
            this.btnloper.Click += new System.EventHandler(this.btnloper_Click);
            this.btnloper.MouseEnter += new System.EventHandler(this.btnloper_MouseEnter);
            this.btnloper.MouseLeave += new System.EventHandler(this.btnloper_MouseLeave);
            // 
            // btndame
            // 
            this.btndame.BackColor = System.Drawing.Color.Transparent;
            this.btndame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btndame.FlatAppearance.BorderSize = 0;
            this.btndame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btndame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btndame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndame.Location = new System.Drawing.Point(535, 281);
            this.btndame.Name = "btndame";
            this.btndame.Size = new System.Drawing.Size(191, 48);
            this.btndame.TabIndex = 14;
            this.btndame.UseVisualStyleBackColor = false;
            this.btndame.Visible = false;
            this.btndame.Click += new System.EventHandler(this.btndame_Click);
            this.btndame.MouseEnter += new System.EventHandler(this.btndame_MouseEnter);
            this.btndame.MouseLeave += new System.EventHandler(this.btndame_MouseLeave);
            // 
            // btnkoning
            // 
            this.btnkoning.BackColor = System.Drawing.Color.Transparent;
            this.btnkoning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnkoning.FlatAppearance.BorderSize = 0;
            this.btnkoning.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnkoning.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnkoning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkoning.Location = new System.Drawing.Point(536, 335);
            this.btnkoning.Name = "btnkoning";
            this.btnkoning.Size = new System.Drawing.Size(191, 48);
            this.btnkoning.TabIndex = 15;
            this.btnkoning.UseVisualStyleBackColor = false;
            this.btnkoning.Visible = false;
            this.btnkoning.Click += new System.EventHandler(this.btnkoning_Click);
            this.btnkoning.MouseEnter += new System.EventHandler(this.btnkoning_MouseEnter);
            this.btnkoning.MouseLeave += new System.EventHandler(this.btnkoning_MouseLeave);
            // 
            // btnpion
            // 
            this.btnpion.BackColor = System.Drawing.Color.Transparent;
            this.btnpion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnpion.FlatAppearance.BorderSize = 0;
            this.btnpion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnpion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnpion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpion.Location = new System.Drawing.Point(536, 389);
            this.btnpion.Name = "btnpion";
            this.btnpion.Size = new System.Drawing.Size(191, 48);
            this.btnpion.TabIndex = 16;
            this.btnpion.UseVisualStyleBackColor = false;
            this.btnpion.Visible = false;
            this.btnpion.Click += new System.EventHandler(this.btnpion_Click);
            this.btnpion.MouseEnter += new System.EventHandler(this.btnpion_MouseEnter);
            this.btnpion.MouseLeave += new System.EventHandler(this.btnpion_MouseLeave);
            // 
            // btnterug
            // 
            this.btnterug.BackColor = System.Drawing.Color.Transparent;
            this.btnterug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnterug.FlatAppearance.BorderSize = 0;
            this.btnterug.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnterug.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnterug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnterug.Location = new System.Drawing.Point(521, 34);
            this.btnterug.Name = "btnterug";
            this.btnterug.Size = new System.Drawing.Size(102, 35);
            this.btnterug.TabIndex = 17;
            this.btnterug.UseVisualStyleBackColor = false;
            this.btnterug.Click += new System.EventHandler(this.btnterug_Click);
            this.btnterug.MouseEnter += new System.EventHandler(this.btnterug_MouseEnter);
            this.btnterug.MouseLeave += new System.EventHandler(this.btnterug_MouseLeave);
            // 
            // pbuitleg
            // 
            this.pbuitleg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbuitleg.Location = new System.Drawing.Point(478, 251);
            this.pbuitleg.Name = "pbuitleg";
            this.pbuitleg.Size = new System.Drawing.Size(198, 196);
            this.pbuitleg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbuitleg.TabIndex = 18;
            this.pbuitleg.TabStop = false;
            this.pbuitleg.Visible = false;
            // 
            // lblbeurt
            // 
            this.lblbeurt.AutoSize = true;
            this.lblbeurt.BackColor = System.Drawing.Color.Transparent;
            this.lblbeurt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbeurt.ForeColor = System.Drawing.SystemColors.Control;
            this.lblbeurt.Location = new System.Drawing.Point(570, 9);
            this.lblbeurt.Name = "lblbeurt";
            this.lblbeurt.Size = new System.Drawing.Size(0, 18);
            this.lblbeurt.TabIndex = 19;
            // 
            // SpeelBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(738, 540);
            this.Controls.Add(this.lblbeurt);
            this.Controls.Add(this.pbuitleg);
            this.Controls.Add(this.btnterug);
            this.Controls.Add(this.btnpion);
            this.Controls.Add(this.btnkoning);
            this.Controls.Add(this.btndame);
            this.Controls.Add(this.btnloper);
            this.Controls.Add(this.btntoren);
            this.Controls.Add(this.btnpaard);
            this.Controls.Add(this.btnvariant);
            this.Controls.Add(this.btnregels);
            this.Controls.Add(this.lbluitleg);
            this.Controls.Add(this.lblaanzet);
            this.Controls.Add(this.lblaantal2);
            this.Controls.Add(this.lblaantal1);
            this.Controls.Add(this.lblResterend2);
            this.Controls.Add(this.lblResterend1);
            this.Controls.Add(this.btHerstart);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SpeelBord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schaken";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SpeelBord_FormClosed);
            this.Load += new System.EventHandler(this.SpeelBord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbuitleg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Button btHerstart;
        private System.Windows.Forms.Label lblResterend1;
        private System.Windows.Forms.Label lblResterend2;
        private System.Windows.Forms.Label lblaanzet;
        private System.Windows.Forms.Label lbluitleg;
        private System.Windows.Forms.Button btnvariant;
        private System.Windows.Forms.Button btnpaard;
        private System.Windows.Forms.Button btntoren;
        private System.Windows.Forms.Button btnloper;
        private System.Windows.Forms.Button btndame;
        private System.Windows.Forms.Button btnkoning;
        private System.Windows.Forms.Button btnpion;
        private System.Windows.Forms.Button btnterug;
        private System.Windows.Forms.PictureBox pbuitleg;
        private System.Windows.Forms.Button btnregels;
        public System.Windows.Forms.Label lblbeurt;
        public System.Windows.Forms.Label lblaantal1;
        public System.Windows.Forms.Label lblaantal2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}