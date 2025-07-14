namespace Antecessor_sucessor
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelSucessor = new System.Windows.Forms.Label();
            this.labelAntecessor = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "número";
            // 
            // labelSucessor
            // 
            this.labelSucessor.AutoSize = true;
            this.labelSucessor.Location = new System.Drawing.Point(39, 111);
            this.labelSucessor.Name = "labelSucessor";
            this.labelSucessor.Size = new System.Drawing.Size(51, 13);
            this.labelSucessor.TabIndex = 1;
            this.labelSucessor.Text = "Sucessor";
            // 
            // labelAntecessor
            // 
            this.labelAntecessor.AutoSize = true;
            this.labelAntecessor.Location = new System.Drawing.Point(39, 144);
            this.labelAntecessor.Name = "labelAntecessor";
            this.labelAntecessor.Size = new System.Drawing.Size(60, 13);
            this.labelAntecessor.TabIndex = 2;
            this.labelAntecessor.Text = "Antecessor";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calcular Antecessor e Sucessor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelAntecessor);
            this.Controls.Add(this.labelSucessor);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Calcular";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSucessor;
        private System.Windows.Forms.Label labelAntecessor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

