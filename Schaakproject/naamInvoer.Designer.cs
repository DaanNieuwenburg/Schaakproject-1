namespace Schaakproject
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
            this.btnNaamSubmit = new System.Windows.Forms.Button();
            this.txtSpeler2Naam = new System.Windows.Forms.TextBox();
            this.lblSpeler2Naam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSpeler1Naam
            // 
            this.txtSpeler1Naam.Location = new System.Drawing.Point(90, 74);
            this.txtSpeler1Naam.Name = "txtSpeler1Naam";
            this.txtSpeler1Naam.Size = new System.Drawing.Size(100, 20);
            this.txtSpeler1Naam.TabIndex = 0;
            // 
            // lblSpeler1Naam
            // 
            this.lblSpeler1Naam.AutoSize = true;
            this.lblSpeler1Naam.Location = new System.Drawing.Point(90, 55);
            this.lblSpeler1Naam.Name = "lblSpeler1Naam";
            this.lblSpeler1Naam.Size = new System.Drawing.Size(83, 13);
            this.lblSpeler1Naam.TabIndex = 1;
            this.lblSpeler1Naam.Text = "Voer je naam in:";
            // 
            // btnNaamSubmit
            // 
            this.btnNaamSubmit.Location = new System.Drawing.Point(90, 161);
            this.btnNaamSubmit.Name = "btnNaamSubmit";
            this.btnNaamSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnNaamSubmit.TabIndex = 2;
            this.btnNaamSubmit.Text = "Submit";
            this.btnNaamSubmit.UseVisualStyleBackColor = true;
            this.btnNaamSubmit.Click += new System.EventHandler(this.btnNaamSubmit_Click);
            // 
            // txtSpeler2Naam
            // 
            this.txtSpeler2Naam.Location = new System.Drawing.Point(90, 135);
            this.txtSpeler2Naam.Name = "txtSpeler2Naam";
            this.txtSpeler2Naam.Size = new System.Drawing.Size(100, 20);
            this.txtSpeler2Naam.TabIndex = 3;
            // 
            // lblSpeler2Naam
            // 
            this.lblSpeler2Naam.AutoSize = true;
            this.lblSpeler2Naam.Location = new System.Drawing.Point(90, 119);
            this.lblSpeler2Naam.Name = "lblSpeler2Naam";
            this.lblSpeler2Naam.Size = new System.Drawing.Size(110, 13);
            this.lblSpeler2Naam.TabIndex = 4;
            this.lblSpeler2Naam.Text = "Tegenstanders naam:";
            // 
            // NaamInvoer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblSpeler2Naam);
            this.Controls.Add(this.txtSpeler2Naam);
            this.Controls.Add(this.btnNaamSubmit);
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
        private System.Windows.Forms.Button btnNaamSubmit;
        private System.Windows.Forms.Label lblSpeler2Naam;
        public System.Windows.Forms.TextBox txtSpeler1Naam;
        public System.Windows.Forms.TextBox txtSpeler2Naam;
    }
}