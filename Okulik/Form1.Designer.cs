namespace Okulik
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.encrypt_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.decrypt_button = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.open_box = new System.Windows.Forms.PictureBox();
            this.save_box = new System.Windows.Forms.PictureBox();
            this.clear_box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.open_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear_box)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.InitialDirectory = "D:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "D:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(23, 72);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(413, 233);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите текст:";
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Шифр Цезаря",
            "Шифр AES",
            "Шифр подстановки"});
            this.comboBox1.Location = new System.Drawing.Point(459, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 27);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(455, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите алгоритм шифрования:";
            // 
            // encrypt_button
            // 
            this.encrypt_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.encrypt_button.Enabled = false;
            this.encrypt_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encrypt_button.Location = new System.Drawing.Point(324, 311);
            this.encrypt_button.Name = "encrypt_button";
            this.encrypt_button.Size = new System.Drawing.Size(112, 32);
            this.encrypt_button.TabIndex = 6;
            this.encrypt_button.Text = "Зашифровать";
            this.encrypt_button.UseVisualStyleBackColor = true;
            this.encrypt_button.Click += new System.EventHandler(this.encrypt_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(459, 205);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(282, 343);
            this.textBox1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(455, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Результат работы алгоритма:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(459, 144);
            this.textBox2.MaxLength = 20;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 13;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(455, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // decrypt_button
            // 
            this.decrypt_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.decrypt_button.Enabled = false;
            this.decrypt_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decrypt_button.Location = new System.Drawing.Point(204, 311);
            this.decrypt_button.Name = "decrypt_button";
            this.decrypt_button.Size = new System.Drawing.Size(114, 32);
            this.decrypt_button.TabIndex = 15;
            this.decrypt_button.Text = "Расшифровать";
            this.decrypt_button.UseVisualStyleBackColor = true;
            this.decrypt_button.Click += new System.EventHandler(this.decrypt_button_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox2.Location = new System.Drawing.Point(24, 349);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(412, 199);
            this.richTextBox2.TabIndex = 16;
            this.richTextBox2.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(21, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 19);
            this.label9.TabIndex = 17;
            this.label9.Text = "Зашифрованный текст:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(753, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // open_box
            // 
            this.open_box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_box.Image = ((System.Drawing.Image)(resources.GetObject("open_box.Image")));
            this.open_box.Location = new System.Drawing.Point(21, 31);
            this.open_box.Name = "open_box";
            this.open_box.Size = new System.Drawing.Size(21, 18);
            this.open_box.TabIndex = 19;
            this.open_box.TabStop = false;
            this.open_box.Click += new System.EventHandler(this.open_box_Click);
            // 
            // save_box
            // 
            this.save_box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_box.Image = ((System.Drawing.Image)(resources.GetObject("save_box.Image")));
            this.save_box.Location = new System.Drawing.Point(48, 27);
            this.save_box.Name = "save_box";
            this.save_box.Size = new System.Drawing.Size(21, 23);
            this.save_box.TabIndex = 20;
            this.save_box.TabStop = false;
            this.save_box.Click += new System.EventHandler(this.save_box_Click);
            // 
            // clear_box
            // 
            this.clear_box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clear_box.Image = ((System.Drawing.Image)(resources.GetObject("clear_box.Image")));
            this.clear_box.Location = new System.Drawing.Point(75, 27);
            this.clear_box.Name = "clear_box";
            this.clear_box.Size = new System.Drawing.Size(22, 25);
            this.clear_box.TabIndex = 21;
            this.clear_box.TabStop = false;
            this.clear_box.Click += new System.EventHandler(this.clear_box_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 552);
            this.Controls.Add(this.clear_box);
            this.Controls.Add(this.save_box);
            this.Controls.Add(this.open_box);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.decrypt_button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.encrypt_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Шифрование";
            ((System.ComponentModel.ISupportInitialize)(this.open_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.save_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button encrypt_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button decrypt_button;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox open_box;
        private System.Windows.Forms.PictureBox save_box;
        private System.Windows.Forms.PictureBox clear_box;
    }
}

