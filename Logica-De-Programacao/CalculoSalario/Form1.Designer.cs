namespace CalculoSalario
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSalario = new System.Windows.Forms.TextBox();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxHoraAtvM = new System.Windows.Forms.TextBox();
            this.textBoxSalarioTotalM = new System.Windows.Forms.TextBox();
            this.textBoxNumeroAulas = new System.Windows.Forms.TextBox();
            this.textBoxValorHRAula = new System.Windows.Forms.TextBox();
            this.textBoxSalarioBase = new System.Windows.Forms.TextBox();
            this.textBoxHoaAtvA = new System.Windows.Forms.TextBox();
            this.textBoxDSR = new System.Windows.Forms.TextBox();
            this.textBoxSalarioTotalA = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 210);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 154);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "Calcular";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Matrícula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "MENSALISTA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Salário R$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Hora-atividade";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 154);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Salário Total";
            // 
            // textBoxSalario
            // 
            this.textBoxSalario.Location = new System.Drawing.Point(20, 119);
            this.textBoxSalario.Name = "textBoxSalario";
            this.textBoxSalario.Size = new System.Drawing.Size(100, 22);
            this.textBoxSalario.TabIndex = 8;
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Location = new System.Drawing.Point(104, 10);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(85, 22);
            this.textBoxMatricula.TabIndex = 9;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(291, 12);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(100, 22);
            this.textBoxNome.TabIndex = 10;
            // 
            // textBoxHoraAtvM
            // 
            this.textBoxHoraAtvM.Location = new System.Drawing.Point(134, 120);
            this.textBoxHoraAtvM.Name = "textBoxHoraAtvM";
            this.textBoxHoraAtvM.Size = new System.Drawing.Size(100, 22);
            this.textBoxHoraAtvM.TabIndex = 11;
            // 
            // textBoxSalarioTotalM
            // 
            this.textBoxSalarioTotalM.Location = new System.Drawing.Point(134, 174);
            this.textBoxSalarioTotalM.Name = "textBoxSalarioTotalM";
            this.textBoxSalarioTotalM.Size = new System.Drawing.Size(100, 22);
            this.textBoxSalarioTotalM.TabIndex = 12;
            // 
            // textBoxNumeroAulas
            // 
            this.textBoxNumeroAulas.Location = new System.Drawing.Point(288, 116);
            this.textBoxNumeroAulas.Name = "textBoxNumeroAulas";
            this.textBoxNumeroAulas.Size = new System.Drawing.Size(100, 22);
            this.textBoxNumeroAulas.TabIndex = 13;
            // 
            // textBoxValorHRAula
            // 
            this.textBoxValorHRAula.Location = new System.Drawing.Point(288, 171);
            this.textBoxValorHRAula.Name = "textBoxValorHRAula";
            this.textBoxValorHRAula.Size = new System.Drawing.Size(100, 22);
            this.textBoxValorHRAula.TabIndex = 14;
            // 
            // textBoxSalarioBase
            // 
            this.textBoxSalarioBase.Location = new System.Drawing.Point(417, 116);
            this.textBoxSalarioBase.Name = "textBoxSalarioBase";
            this.textBoxSalarioBase.Size = new System.Drawing.Size(100, 22);
            this.textBoxSalarioBase.TabIndex = 15;
            // 
            // textBoxHoaAtvA
            // 
            this.textBoxHoaAtvA.Location = new System.Drawing.Point(417, 162);
            this.textBoxHoaAtvA.Name = "textBoxHoaAtvA";
            this.textBoxHoaAtvA.Size = new System.Drawing.Size(100, 22);
            this.textBoxHoaAtvA.TabIndex = 16;
            // 
            // textBoxDSR
            // 
            this.textBoxDSR.Location = new System.Drawing.Point(417, 210);
            this.textBoxDSR.Name = "textBoxDSR";
            this.textBoxDSR.Size = new System.Drawing.Size(100, 22);
            this.textBoxDSR.TabIndex = 17;
            // 
            // textBoxSalarioTotalA
            // 
            this.textBoxSalarioTotalA.Location = new System.Drawing.Point(417, 257);
            this.textBoxSalarioTotalA.Name = "textBoxSalarioTotalA";
            this.textBoxSalarioTotalA.Size = new System.Drawing.Size(100, 22);
            this.textBoxSalarioTotalA.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(288, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Aulas Semanais";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(288, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Valor Hora Aula";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(417, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Salário Base";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(417, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Hora-atividade";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(417, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "DSR";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(417, 235);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "Salário Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(288, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "AULISTA";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSalarioTotalA);
            this.Controls.Add(this.textBoxDSR);
            this.Controls.Add(this.textBoxHoaAtvA);
            this.Controls.Add(this.textBoxSalarioBase);
            this.Controls.Add(this.textBoxValorHRAula);
            this.Controls.Add(this.textBoxNumeroAulas);
            this.Controls.Add(this.textBoxSalarioTotalM);
            this.Controls.Add(this.textBoxHoraAtvM);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.textBoxMatricula);
            this.Controls.Add(this.textBoxSalario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSalario;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxHoraAtvM;
        private System.Windows.Forms.TextBox textBoxSalarioTotalM;
        private System.Windows.Forms.TextBox textBoxNumeroAulas;
        private System.Windows.Forms.TextBox textBoxValorHRAula;
        private System.Windows.Forms.TextBox textBoxSalarioBase;
        private System.Windows.Forms.TextBox textBoxHoaAtvA;
        private System.Windows.Forms.TextBox textBoxDSR;
        private System.Windows.Forms.TextBox textBoxSalarioTotalA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

