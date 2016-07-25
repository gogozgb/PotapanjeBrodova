namespace PrikazFlote
{
    partial class FormFlota
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
            this.buttonSloži = new System.Windows.Forms.Button();
            this.mrežaZaFlotu = new PrikazFlote.MrežaZaFlotu();
            this.SuspendLayout();
            // 
            // buttonSloži
            // 
            this.buttonSloži.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSloži.Location = new System.Drawing.Point(318, 415);
            this.buttonSloži.Name = "buttonSloži";
            this.buttonSloži.Size = new System.Drawing.Size(75, 23);
            this.buttonSloži.TabIndex = 1;
            this.buttonSloži.Text = "&Složi";
            this.buttonSloži.UseVisualStyleBackColor = true;
            this.buttonSloži.Click += new System.EventHandler(this.buttonSloži_Click);
            // 
            // mrežaZaFlotu
            // 
            this.mrežaZaFlotu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mrežaZaFlotu.Location = new System.Drawing.Point(12, 12);
            this.mrežaZaFlotu.Name = "mrežaZaFlotu";
            this.mrežaZaFlotu.Size = new System.Drawing.Size(381, 382);
            this.mrežaZaFlotu.TabIndex = 0;
            this.mrežaZaFlotu.Text = "mrežaZaFlotu";
            // 
            // FormFlota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 450);
            this.Controls.Add(this.buttonSloži);
            this.Controls.Add(this.mrežaZaFlotu);
            this.Name = "FormFlota";
            this.Text = "Flota";
            this.ResumeLayout(false);

        }

        #endregion

        private MrežaZaFlotu mrežaZaFlotu;
        private System.Windows.Forms.Button buttonSloži;
    }
}

