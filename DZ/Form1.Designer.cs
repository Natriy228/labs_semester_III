namespace Decoder
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
            this.showb = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loggercb = new System.Windows.Forms.ComboBox();
            this.codeccb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showb
            // 
            this.showb.Location = new System.Drawing.Point(12, 455);
            this.showb.Name = "showb";
            this.showb.Size = new System.Drawing.Size(129, 23);
            this.showb.TabIndex = 1;
            this.showb.Text = "Чтение";
            this.showb.UseVisualStyleBackColor = true;
            this.showb.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loggercb
            // 
            this.loggercb.FormattingEnabled = true;
            this.loggercb.Location = new System.Drawing.Point(147, 511);
            this.loggercb.Name = "loggercb";
            this.loggercb.Size = new System.Drawing.Size(129, 21);
            this.loggercb.TabIndex = 2;
            this.loggercb.Text = "Журнал";
            this.loggercb.SelectedIndexChanged += new System.EventHandler(this.loggercb_SelectedIndexChanged);
            // 
            // codeccb
            // 
            this.codeccb.FormattingEnabled = true;
            this.codeccb.Location = new System.Drawing.Point(147, 484);
            this.codeccb.Name = "codeccb";
            this.codeccb.Size = new System.Drawing.Size(129, 21);
            this.codeccb.TabIndex = 3;
            this.codeccb.Text = "Последовательный";
            this.codeccb.SelectedValueChanged += new System.EventHandler(this.codeccb_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Кодек";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 514);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Вид системных отчётов";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 437);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 455);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Запись";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codeccb);
            this.Controls.Add(this.loggercb);
            this.Controls.Add(this.showb);
            this.MaximumSize = new System.Drawing.Size(816, 582);
            this.MinimumSize = new System.Drawing.Size(816, 582);
            this.Name = "Form1";
            this.Text = "Photo decoder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button showb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox loggercb;
        private System.Windows.Forms.ComboBox codeccb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
    }
}

