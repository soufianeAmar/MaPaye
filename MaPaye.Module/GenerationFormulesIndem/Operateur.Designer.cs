namespace MaPaye.Module
{
    partial class Operateur
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
            this.components = new System.ComponentModel.Container();
            this.PremierOperateur = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.indemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.indemBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // PremierOperateur
            // 
            this.PremierOperateur.FormattingEnabled = true;
            this.PremierOperateur.Items.AddRange(new object[] {
            "BASE",
            "TAUX",
            "NBR "});
            this.PremierOperateur.Location = new System.Drawing.Point(12, 29);
            this.PremierOperateur.Name = "PremierOperateur";
            this.PremierOperateur.Size = new System.Drawing.Size(208, 21);
            this.PremierOperateur.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(159, 69);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(61, 23);
            this.OK.TabIndex = 8;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // indemBindingSource1
            // 
            this.indemBindingSource1.DataSource = typeof(MaPaye.Module.Indem);
            // 
            // Operateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 104);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.PremierOperateur);
            this.Name = "Operateur";
            this.Text = "Operateur";
            this.Load += new System.EventHandler(this.Operateur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.indemBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox PremierOperateur;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.BindingSource indemBindingSource1;
    }
}