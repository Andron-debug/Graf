
namespace Graf
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.is_gaf = new System.Windows.Forms.RadioButton();
            this.is_orggraf = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество вершин";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(17, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 30);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип";
            // 
            // is_gaf
            // 
            this.is_gaf.AutoSize = true;
            this.is_gaf.Checked = true;
            this.is_gaf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.is_gaf.Location = new System.Drawing.Point(17, 134);
            this.is_gaf.Name = "is_gaf";
            this.is_gaf.Size = new System.Drawing.Size(74, 29);
            this.is_gaf.TabIndex = 3;
            this.is_gaf.TabStop = true;
            this.is_gaf.Text = "Гаф";
            this.is_gaf.UseVisualStyleBackColor = true;
            // 
            // is_orggraf
            // 
            this.is_orggraf.AutoSize = true;
            this.is_orggraf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.is_orggraf.Location = new System.Drawing.Point(17, 173);
            this.is_orggraf.Name = "is_orggraf";
            this.is_orggraf.Size = new System.Drawing.Size(107, 29);
            this.is_orggraf.TabIndex = 4;
            this.is_orggraf.Text = "Орграф";
            this.is_orggraf.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(355, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "Начать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 291);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.is_orggraf);
            this.Controls.Add(this.is_gaf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Графы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton is_gaf;
        private System.Windows.Forms.RadioButton is_orggraf;
        private System.Windows.Forms.Button button1;
    }
}

