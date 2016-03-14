namespace Schaakproject
{
    partial class PromoveerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pbToren = new System.Windows.Forms.PictureBox();
            this.pbLoper = new System.Windows.Forms.PictureBox();
            this.pbPaard = new System.Windows.Forms.PictureBox();
            this.pbDame = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbToren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPaard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDame)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Promoveer naar:";
            // 
            // pbToren
            // 
            this.pbToren.Image = global::Schaakproject.Properties.Resources.TorenWit;
            this.pbToren.Location = new System.Drawing.Point(118, 133);
            this.pbToren.Name = "pbToren";
            this.pbToren.Size = new System.Drawing.Size(45, 45);
            this.pbToren.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbToren.TabIndex = 3;
            this.pbToren.TabStop = false;
            this.pbToren.Click += new System.EventHandler(this.pbToren_Click);
            // 
            // pbLoper
            // 
            this.pbLoper.Image = global::Schaakproject.Properties.Resources.LoperWit;
            this.pbLoper.Location = new System.Drawing.Point(118, 55);
            this.pbLoper.Name = "pbLoper";
            this.pbLoper.Size = new System.Drawing.Size(45, 45);
            this.pbLoper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLoper.TabIndex = 2;
            this.pbLoper.TabStop = false;
            this.pbLoper.Click += new System.EventHandler(this.pbLoper_Click);
            // 
            // pbPaard
            // 
            this.pbPaard.Image = global::Schaakproject.Properties.Resources.PaardWit;
            this.pbPaard.Location = new System.Drawing.Point(12, 133);
            this.pbPaard.Name = "pbPaard";
            this.pbPaard.Size = new System.Drawing.Size(45, 45);
            this.pbPaard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPaard.TabIndex = 1;
            this.pbPaard.TabStop = false;
            this.pbPaard.Click += new System.EventHandler(this.pbPaard_Click);
            // 
            // pbDame
            // 
            this.pbDame.Image = global::Schaakproject.Properties.Resources.DameWit;
            this.pbDame.Location = new System.Drawing.Point(12, 55);
            this.pbDame.Name = "pbDame";
            this.pbDame.Size = new System.Drawing.Size(45, 45);
            this.pbDame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDame.TabIndex = 0;
            this.pbDame.TabStop = false;
            this.pbDame.Click += new System.EventHandler(this.pbDame_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dame";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loper";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Paard";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Toren";
            // 
            // PromoveerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 211);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbToren);
            this.Controls.Add(this.pbLoper);
            this.Controls.Add(this.pbPaard);
            this.Controls.Add(this.pbDame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PromoveerForm";
            this.Text = "PromoveerForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbToren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPaard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDame;
        private System.Windows.Forms.PictureBox pbPaard;
        private System.Windows.Forms.PictureBox pbToren;
        private System.Windows.Forms.PictureBox pbLoper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}