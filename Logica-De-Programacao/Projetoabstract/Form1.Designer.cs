namespace Projetoabstract
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
            this.labelArea = new System.Windows.Forms.Label();
            this.labelPerimetro = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxQuadrado = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLadoA = new System.Windows.Forms.TextBox();
            this.textBoxLadoB = new System.Windows.Forms.TextBox();
            this.textBoxLadoC = new System.Windows.Forms.TextBox();
            this.textBoxBaseR = new System.Windows.Forms.TextBox();
            this.textBoxAlturaR = new System.Windows.Forms.TextBox();
            this.textBoxBaseT = new System.Windows.Forms.TextBox();
            this.textBoxAlturaT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digitar o valor do lado do quadrado em metros";
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Location = new System.Drawing.Point(15, 178);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(94, 13);
            this.labelArea.TabIndex = 1;
            this.labelArea.Text = "A area da forma é ";
            // 
            // labelPerimetro
            // 
            this.labelPerimetro.AutoSize = true;
            this.labelPerimetro.Location = new System.Drawing.Point(15, 205);
            this.labelPerimetro.Name = "labelPerimetro";
            this.labelPerimetro.Size = new System.Drawing.Size(90, 13);
            this.labelPerimetro.TabIndex = 2;
            this.labelPerimetro.Text = "O perímetro do é ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxQuadrado
            // 
            this.textBoxQuadrado.Location = new System.Drawing.Point(245, 101);
            this.textBoxQuadrado.Name = "textBoxQuadrado";
            this.textBoxQuadrado.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuadrado.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Quadrado",
            "Triangulo",
            "Retangulo"});
            this.comboBox1.Location = new System.Drawing.Point(110, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seleciona a forma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Digitar lado A, Lado B lado C Base e Altura do triangulo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Digita base e altura do retangulo";
            // 
            // textBoxLadoA
            // 
            this.textBoxLadoA.Location = new System.Drawing.Point(288, 39);
            this.textBoxLadoA.Name = "textBoxLadoA";
            this.textBoxLadoA.Size = new System.Drawing.Size(35, 20);
            this.textBoxLadoA.TabIndex = 9;
            // 
            // textBoxLadoB
            // 
            this.textBoxLadoB.Location = new System.Drawing.Point(333, 39);
            this.textBoxLadoB.Name = "textBoxLadoB";
            this.textBoxLadoB.Size = new System.Drawing.Size(29, 20);
            this.textBoxLadoB.TabIndex = 10;
            // 
            // textBoxLadoC
            // 
            this.textBoxLadoC.Location = new System.Drawing.Point(368, 39);
            this.textBoxLadoC.Name = "textBoxLadoC";
            this.textBoxLadoC.Size = new System.Drawing.Size(34, 20);
            this.textBoxLadoC.TabIndex = 11;
            // 
            // textBoxBaseR
            // 
            this.textBoxBaseR.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.textBoxBaseR.Location = new System.Drawing.Point(186, 68);
            this.textBoxBaseR.Name = "textBoxBaseR";
            this.textBoxBaseR.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBaseR.Size = new System.Drawing.Size(45, 20);
            this.textBoxBaseR.TabIndex = 12;
            // 
            // textBoxAlturaR
            // 
            this.textBoxAlturaR.Location = new System.Drawing.Point(245, 68);
            this.textBoxAlturaR.Name = "textBoxAlturaR";
            this.textBoxAlturaR.Size = new System.Drawing.Size(44, 20);
            this.textBoxAlturaR.TabIndex = 13;
            // 
            // textBoxBaseT
            // 
            this.textBoxBaseT.Location = new System.Drawing.Point(408, 39);
            this.textBoxBaseT.Name = "textBoxBaseT";
            this.textBoxBaseT.Size = new System.Drawing.Size(37, 20);
            this.textBoxBaseT.TabIndex = 14;
            // 
            // textBoxAlturaT
            // 
            this.textBoxAlturaT.Location = new System.Drawing.Point(451, 39);
            this.textBoxAlturaT.Name = "textBoxAlturaT";
            this.textBoxAlturaT.Size = new System.Drawing.Size(35, 20);
            this.textBoxAlturaT.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 243);
            this.Controls.Add(this.textBoxAlturaT);
            this.Controls.Add(this.textBoxBaseT);
            this.Controls.Add(this.textBoxAlturaR);
            this.Controls.Add(this.textBoxBaseR);
            this.Controls.Add(this.textBoxLadoC);
            this.Controls.Add(this.textBoxLadoB);
            this.Controls.Add(this.textBoxLadoA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxQuadrado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPerimetro);
            this.Controls.Add(this.labelArea);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Classe e métodos abstratos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Label labelPerimetro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxQuadrado;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLadoA;
        private System.Windows.Forms.TextBox textBoxLadoB;
        private System.Windows.Forms.TextBox textBoxLadoC;
        private System.Windows.Forms.TextBox textBoxBaseR;
        private System.Windows.Forms.TextBox textBoxAlturaR;
        private System.Windows.Forms.TextBox textBoxBaseT;
        private System.Windows.Forms.TextBox textBoxAlturaT;
    }
}

