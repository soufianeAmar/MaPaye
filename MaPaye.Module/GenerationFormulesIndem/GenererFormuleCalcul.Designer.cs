namespace MaPaye.Module
{
    partial class GenererFormuleCalculForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.AddOperator = new System.Windows.Forms.Button();
            this.Formule = new System.Windows.Forms.TextBox();
            this.AddPayeElement = new System.Windows.Forms.Button();
            this.indemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.AddIndem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.indemBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Formule de Calcul = ";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(510, 114);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(76, 23);
            this.OK.TabIndex = 8;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // AddOperator
            // 
            this.AddOperator.Location = new System.Drawing.Point(124, 29);
            this.AddOperator.Name = "AddOperator";
            this.AddOperator.Size = new System.Drawing.Size(147, 23);
            this.AddOperator.TabIndex = 10;
            this.AddOperator.Text = "Ajouter Operateur";
            this.AddOperator.UseVisualStyleBackColor = true;
            this.AddOperator.Click += new System.EventHandler(this.AddOperator_Click);
            // 
            // Formule
            // 
            this.Formule.Location = new System.Drawing.Point(124, 79);
            this.Formule.Name = "Formule";
            this.Formule.Size = new System.Drawing.Size(462, 20);
            this.Formule.TabIndex = 11;
            // 
            // AddPayeElement
            // 
            this.AddPayeElement.Location = new System.Drawing.Point(448, 29);
            this.AddPayeElement.Name = "AddPayeElement";
            this.AddPayeElement.Size = new System.Drawing.Size(138, 23);
            this.AddPayeElement.TabIndex = 10;
            this.AddPayeElement.Text = "Ajouter Element de Paye";
            this.AddPayeElement.UseVisualStyleBackColor = true;
            this.AddPayeElement.Click += new System.EventHandler(this.AddPayeElement_Click);
            // 
            // indemBindingSource1
            // 
            this.indemBindingSource1.DataSource = typeof(MaPaye.Module.Indem);
            // 
            // AddIndem
            // 
            this.AddIndem.Location = new System.Drawing.Point(294, 29);
            this.AddIndem.Name = "AddIndem";
            this.AddIndem.Size = new System.Drawing.Size(138, 23);
            this.AddIndem.TabIndex = 10;
            this.AddIndem.Text = "Ajouter Indemnité";
            this.AddIndem.UseVisualStyleBackColor = true;
            this.AddIndem.Click += new System.EventHandler(this.AddIndem_Click);
            // 
            // GenererFormuleCalculForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 155);
            this.Controls.Add(this.Formule);
            this.Controls.Add(this.AddIndem);
            this.Controls.Add(this.AddPayeElement);
            this.Controls.Add(this.AddOperator);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label2);
            this.Name = "GenererFormuleCalculForm";
            this.Text = "GenererFormuleCalcul";
            ((System.ComponentModel.ISupportInitialize)(this.indemBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.BindingSource indemBindingSource1;
        private System.Windows.Forms.Button AddOperator;
        private System.Windows.Forms.TextBox Formule;
        private System.Windows.Forms.Button AddPayeElement;
        private System.Windows.Forms.Button AddIndem;
    }
}