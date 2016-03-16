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
            this.startButton = new System.Windows.Forms.Button();
            this.btnafsluiten = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.BackgroundImage = global::Schaakproject.Properties.Resources.start_klad_2_;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.ForeColor = System.Drawing.Color.Transparent;
            this.startButton.Location = new System.Drawing.Point(168, 209);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(351, 131);
            this.startButton.TabIndex = 1;
            this.startButton.TabStop = false;
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.startButton.MouseEnter += new System.EventHandler(this.startButton_MouseEnter_1);
            this.startButton.MouseLeave += new System.EventHandler(this.startButton_MouseLeave);
            // 
            // btnafsluiten
            // 
            this.btnafsluiten.BackColor = System.Drawing.Color.Transparent;
            this.btnafsluiten.BackgroundImage = global::Schaakproject.Properties.Resources.afsluiten;
            this.btnafsluiten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnafsluiten.FlatAppearance.BorderSize = 0;
            this.btnafsluiten.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnafsluiten.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnafsluiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnafsluiten.Location = new System.Drawing.Point(226, 361);
            this.btnafsluiten.Name = "btnafsluiten";
            this.btnafsluiten.Size = new System.Drawing.Size(235, 62);
            this.btnafsluiten.TabIndex = 2;
            this.btnafsluiten.UseVisualStyleBackColor = false;
            this.btnafsluiten.Click += new System.EventHandler(this.btnafsluiten_Click);
            this.btnafsluiten.MouseEnter += new System.EventHandler(this.btnafsluiten_MouseEnter);
            this.btnafsluiten.MouseLeave += new System.EventHandler(this.btnafsluiten_MouseLeave);
            // 
            // Hoofdmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(716, 446);
            this.Controls.Add(this.btnafsluiten);
            this.Controls.Add(this.startButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hoofdmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schaakspel";
            this.Load += new System.EventHandler(this.Hoofdmenu_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button btnafsluiten;
    }
}

