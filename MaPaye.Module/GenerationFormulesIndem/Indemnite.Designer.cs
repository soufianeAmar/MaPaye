namespace MaPaye.Module
{
    partial class Indemnite
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
            this.OK = new System.Windows.Forms.Button();
            this.PremierOperateur2 = new DevExpress.XtraEditors.LookUpEdit();
            this.indemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PremierOperateur2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indemBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(151, 68);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(60, 23);
            this.OK.TabIndex = 8;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // PremierOperateur2
            // 
            this.PremierOperateur2.EditValue = "<Null>";
            this.PremierOperateur2.Location = new System.Drawing.Point(12, 30);
            this.PremierOperateur2.Name = "PremierOperateur2";
            this.PremierOperateur2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PremierOperateur2.Properties.DataSource = this.indemBindingSource1;
            this.PremierOperateur2.Size = new System.Drawing.Size(199, 20);
            this.PremierOperateur2.TabIndex = 9;
            // 
            // indemBindingSource1
            // 
            this.indemBindingSource1.DataSource = typeof(MaPaye.Module.Indem);
            // 
            // Indemnite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 103);
            this.Controls.Add(this.PremierOperateur2);
            this.Controls.Add(this.OK);
            this.Name = "Indemnite";
            this.Text = "Indemnite";
            this.Load += new System.EventHandler(this.Indemnite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PremierOperateur2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indemBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.BindingSource indemBindingSource1;
        private DevExpress.XtraEditors.LookUpEdit PremierOperateur2;
    }
}