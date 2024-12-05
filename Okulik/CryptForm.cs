using System;
using System.Windows.Forms;
using System.IO;
using Xceed.Words.NET;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Diagnostics;


namespace Encryption
{
    public partial class CryptForm : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        public CryptForm()
        {
            InitializeComponent();
            AddToolStripMenuItems();

            // Устанавливаем текст для подсказки
            toolTip1.SetToolTip(open_box, "Открыть файл\nПоддерживаемые форматы:\n.txt и .doc");
            toolTip1.SetToolTip(save_box, "Сохранить файл\nПоддерживаемые форматы:\n.txt и .doc");
            toolTip1.SetToolTip(clear_box, "Очистить");
            toolTip1.SetToolTip(encrypt_button, "Зашифровать");
            toolTip1.SetToolTip(decrypt_button, "Расшифровать");
        }
        private void AddToolStripMenuItems()
        {
            // Создаем пункты меню
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Файл");
            ToolStripMenuItem editMenu = new ToolStripMenuItem("Правка");
            ToolStripMenuItem ciphersMenu = new ToolStripMenuItem("Шифры");
            ToolStripMenuItem aboutMenu = new ToolStripMenuItem("Справка");

            // Создаем подпункты меню
            ToolStripMenuItem openToolStripMenuItem = new ToolStripMenuItem("Открыть...");
            ToolStripMenuItem newWindowToolStripMenuItem = new ToolStripMenuItem("Очистить");
            ToolStripMenuItem saveToolStripMenuItem = new ToolStripMenuItem("Сохранить зашифрованные данные...");
            ToolStripMenuItem saveAsToolStripMenuItem = new ToolStripMenuItem("Сохранить результат работы...");
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Выход из программы");
            ToolStripMenuItem undoMenuItem = new ToolStripMenuItem("Отменить");
            ToolStripMenuItem cutToolStripMenuItem = new ToolStripMenuItem("Вырезать");
            ToolStripMenuItem copyToolStripMenuItem = new ToolStripMenuItem("Копировать");
            ToolStripMenuItem pasteToolStripMenuItem = new ToolStripMenuItem("Вставить");
            ToolStripMenuItem deleteToolStripMenuItem = new ToolStripMenuItem("Удалить");
            ToolStripMenuItem selectAllToolStripMenuItem = new ToolStripMenuItem("Выделить все");
            ToolStripMenuItem timeDateToolStripMenuItem = new ToolStripMenuItem("Время и дата");
            ToolStripMenuItem caesarCipherToolStripMenuItem = new ToolStripMenuItem("Шифр Цезаря");
            ToolStripMenuItem aesCipherToolStripMenuItem = new ToolStripMenuItem("Шифр AES");
            ToolStripMenuItem substitutionCipherToolStripMenuItem = new ToolStripMenuItem("Шифр подстановки");
            ToolStripMenuItem aboutProgramToolStripMenuItem = new ToolStripMenuItem("О программе...");
            ToolStripMenuItem aboutCaesarCipherToolStripMenuItem = new ToolStripMenuItem("О шифре Цезаря...");
            ToolStripMenuItem aboutAesCipherToolStripMenuItem = new ToolStripMenuItem("О шифре AES...");
            ToolStripMenuItem aboutSubstitutionCipherToolStripMenuItem = new ToolStripMenuItem("О шифре подстановки...");

            // Добавляем подпункты в меню 
            fileMenu.DropDownItems.Add(openToolStripMenuItem);
            fileMenu.DropDownItems.Add(newWindowToolStripMenuItem);
            fileMenu.DropDownItems.Add(saveToolStripMenuItem);
            fileMenu.DropDownItems.Add(saveAsToolStripMenuItem);
            fileMenu.DropDownItems.Add(exitMenuItem);
            editMenu.DropDownItems.Add(undoMenuItem);
            editMenu.DropDownItems.Add(cutToolStripMenuItem);
            editMenu.DropDownItems.Add(copyToolStripMenuItem);
            editMenu.DropDownItems.Add(pasteToolStripMenuItem);
            editMenu.DropDownItems.Add(deleteToolStripMenuItem);
            editMenu.DropDownItems.Add(selectAllToolStripMenuItem);
            editMenu.DropDownItems.Add(timeDateToolStripMenuItem);
            ciphersMenu.DropDownItems.Add(caesarCipherToolStripMenuItem);
            ciphersMenu.DropDownItems.Add(aesCipherToolStripMenuItem);
            ciphersMenu.DropDownItems.Add(substitutionCipherToolStripMenuItem);
            aboutMenu.DropDownItems.Add(aboutProgramToolStripMenuItem);
            aboutMenu.DropDownItems.Add(aboutCaesarCipherToolStripMenuItem);
            aboutMenu.DropDownItems.Add(aboutAesCipherToolStripMenuItem);
            aboutMenu.DropDownItems.Add(aboutSubstitutionCipherToolStripMenuItem);

            // Добавляем обработчики событий для подпунктов меню
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            newWindowToolStripMenuItem.Click += NewWindowToolStripMenuItem_Click;
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;
            undoMenuItem.Click += UndoToolStripMenuItem_Click;
            cutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            copyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            selectAllToolStripMenuItem.Click += SelectAllToolStripMenuItem_Click;
            timeDateToolStripMenuItem.Click += TimeDateToolStripMenuItem_Click;
            caesarCipherToolStripMenuItem.Click += CaesarCipherToolStripMenuItem_Click;
            aesCipherToolStripMenuItem.Click += AesCipherToolStripMenuItem_Click;
            substitutionCipherToolStripMenuItem.Click += SubstitutionCipherToolStripMenuItem_Click;
            aboutProgramToolStripMenuItem.Click += AboutProgramToolStripMenuItem_Click;
            aboutCaesarCipherToolStripMenuItem.Click += AboutCaesarCipherToolStripMenuItem_Click;
            aboutAesCipherToolStripMenuItem.Click += AboutAesCipherToolStripMenuItem_Click;
            aboutSubstitutionCipherToolStripMenuItem.Click += AboutSubstitutionCipherToolStripMenuItem_Click;

            // Добавляем созданные меню на ToolStrip
            toolStrip1.Items.Add(fileMenu);
            toolStrip1.Items.Add(editMenu);
            toolStrip1.Items.Add(ciphersMenu);
            toolStrip1.Items.Add(aboutMenu);
        }

        private void CaesarCipherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void AesCipherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }

        private void SubstitutionCipherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 2;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_box_Click(sender, e);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Документы Word (*.doc;*.docx)|*.doc;*.docx";
            saveFileDialog1.Title = "Сохранить файл";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName);

                if (fileExtension == ".txt" || fileExtension == ".docx" || fileExtension == ".doc")
                {
                    if (fileExtension == ".txt")
                    {
                        // Сохранение текста в TXT файл
                        System.IO.File.WriteAllText(fileName, richTextBox2.Text);
                        MessageBox.Show("Текст успешно сохранен в файле .txt!");
                    }
                    else if (fileExtension == ".doc")
                    {
                        // Сохранение текста в документ Word с помощью DocX
                        using (DocX document = DocX.Create(fileName))
                        {
                            document.InsertParagraph(richTextBox2.Text);
                            document.Save();
                            MessageBox.Show("Файл успешно сохранен в формате .doc!");
                        }
                    }
                    else if (fileExtension == ".docx")
                    {
                        // Сохранение текста в документ Word с помощью DocX
                        using (DocX document = DocX.Create(fileName))
                        {
                            document.InsertParagraph(richTextBox2.Text);
                            document.Save();
                            MessageBox.Show("Файл успешно сохранен в формате .docx!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выбран неподдерживаемый формат файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_box_Click(sender, e);
        }
        private void NewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_box_Click(sender,e);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            textBox2.Undo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            textBox2.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            richTextBox2.Copy();
            textBox1.Copy();
            textBox2.Copy();
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFileContentButton_Click(sender,e,0,3,"О программе");
        }

        private void AboutCaesarCipherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFileContentButton_Click(sender, e, 4, 5, "Шифр Цезаря");
        }

        private void AboutAesCipherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFileContentButton_Click(sender, e, 6, 9, "Шифр AES");
        }

        private void AboutSubstitutionCipherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFileContentButton_Click(sender, e, 10, 11, "Шифр подстановки");
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                int selectionStart = richTextBox1.SelectionStart;
                richTextBox1.Text = richTextBox1.Text.Insert(selectionStart, Clipboard.GetText());
                richTextBox1.SelectionStart = selectionStart + Clipboard.GetText().Length;
            }
            if (textBox2.Focused)
            {
                int selectionStart = textBox2.SelectionStart;
                textBox2.Text = textBox2.Text.Insert(selectionStart, Clipboard.GetText());
                textBox2.SelectionStart = selectionStart + Clipboard.GetText().Length;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectedText = "";
            }
            if (textBox2.SelectedText != "")
            {
                textBox2.SelectedText = "";
            }
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox2.SelectAll();
            textBox1.SelectAll();
            textBox2.SelectAll();
        }

        private void TimeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
            {
                int selectionStart = richTextBox1.SelectionStart;
                richTextBox1.Text = richTextBox1.Text.Insert(selectionStart, DateTime.Now.ToString());
                richTextBox1.SelectionStart = selectionStart + DateTime.Now.ToString().Length;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show(" Вы выбрали алгоритм, Шифр Цезаря. Теперь введите, в появившемся поле для ввода, на сколько вы хотите осуществить сдвиг каждых символов.");
                label8.Text = "На сколько позиций сдвинуть:";
                textBox2.Clear();
                textBox2.Visible = true;
                label8.Visible = true;
                richTextBox1_TextChanged(this, EventArgs.Empty);
                textBox2_TextChanged(this, EventArgs.Empty);
            }
            else
            if (comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show(" Вы выбрали алгоритм, Шифр AES. Теперь введите, в появившемся поле для ввода, пароль для шиврования.");
                label8.Text = "Введите пароль:";
                textBox2.Clear();
                textBox2.Visible = true;
                label8.Visible = true;
                richTextBox1_TextChanged(this, EventArgs.Empty);
                textBox2_TextChanged(this, EventArgs.Empty);
            }
            else
            if (comboBox1.SelectedIndex == 2)
            {
                MessageBox.Show(" Вы выбрали алгоритм, Шифр подстановки.");
                textBox2.Visible = false;
                label8.Visible = false;
                textBox2.Clear();
                richTextBox1_TextChanged(this, EventArgs.Empty);
                textBox2_TextChanged(this, EventArgs.Empty);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text) && (comboBox1.SelectedIndex == 2 || ((comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1) && !string.IsNullOrEmpty(textBox2.Text)))) // Если текстовое поле не пустое
            {
                encrypt_button.Enabled = true; // Включаем кнопку
                decrypt_button.Enabled = true;
            }
            else
            {
                encrypt_button.Enabled = false; // Выключаем кнопку
                decrypt_button.Enabled = false;
            }
            label1.Text = "Введенный текст:";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text) && (comboBox1.SelectedIndex == 2 || ((comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1) && !string.IsNullOrEmpty(textBox2.Text)))) // Если текстовое поле не пустое
            {
                encrypt_button.Enabled = true; // Включаем кнопку
                decrypt_button.Enabled = true;
            }
            else
            {
                encrypt_button.Enabled = false; // Выключаем кнопку
                decrypt_button.Enabled = false;
            }
        }

        private void encrypt_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(richTextBox1.Text) == false && comboBox1.SelectedIndex != -1)
                {
                    if (comboBox1.SelectedIndex == 0 && string.IsNullOrWhiteSpace(textBox2.Text) == false)
                    {
                        if (textBox2.Text.All(char.IsDigit))
                        {
                            if (textBox2.Text.Length < 10)
                            {
                                string line = richTextBox1.Text;
                                int operationCount;
                                stopwatch.Start();
                                richTextBox2.Text = Crypt.CaesarEncrypt(richTextBox1.Text, Convert.ToInt32(textBox2.Text), out operationCount);
                                stopwatch.Stop();
                                label9.Text = "Зашифрованный текст:";
                                MessageBox.Show(" Данные успешно зашифрованы!");
                                textBox1.Text += (" " + DateTime.Now.ToString() + Environment.NewLine + " Строку \"" + line + "\" зашифровали с помошью алгоритма, Шифр Цезаря." + Environment.NewLine + " Сдвиг: " + textBox2.Text + Environment.NewLine + " Результат: " + richTextBox2.Text + Environment.NewLine + " Время работы алгоритма: " + stopwatch.ElapsedMilliseconds.ToString() + " миллисекунд." + Environment.NewLine + " Количество операций при шифровании текста: " + Convert.ToString(operationCount) + Environment.NewLine);
                                decrypt_button.Enabled = false;
                                textBox2.Clear();
                                encrypt_button.Enabled = false;
                            }
                            else
                                MessageBox.Show("Ошибка при вводе данных. Слишком большое число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Ошибка при вводе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (comboBox1.SelectedIndex == 1 && string.IsNullOrWhiteSpace(textBox2.Text) == false)
                    {
                            string line = richTextBox1.Text;
                            stopwatch.Start();
                            richTextBox2.Text = Crypt.AESEncrypt(richTextBox1.Text, textBox2.Text);
                            stopwatch.Stop();
                            label9.Text = "Зашифрованный текст:";
                            MessageBox.Show(" Данные успешно зашифрованы!");
                            textBox1.Text += (" " + DateTime.Now.ToString() + Environment.NewLine + " Строку \"" + line + "\" зашифровали с помошью алгоритма, Шифр AES. " + Environment.NewLine +" Ключ: " + textBox2.Text + Environment.NewLine + " Результат: " + richTextBox2.Text + Environment.NewLine + " Время работы алгоритма: " + stopwatch.ElapsedMilliseconds.ToString() + " миллисекунд." + Environment.NewLine);
                            decrypt_button.Enabled = false;
                            textBox2.Clear();
                            encrypt_button.Enabled = false;
                            label9.Text = "Зашифрованный текст:";
                    }
                    else
                    if (comboBox1.SelectedIndex == 2)
                    {
                        string line = richTextBox1.Text;
                        int operationCount;
                        stopwatch.Start();
                        richTextBox2.Text = Crypt.SubstitutionEncrypt(richTextBox1.Text, out operationCount);
                        stopwatch.Stop();
                        label9.Text = "Зашифрованный текст:";
                        MessageBox.Show(" Данные успешно зашифрованы!");
                        textBox1.Text += (" " + DateTime.Now.ToString() + Environment.NewLine + " Строку \"" + line + "\" зашифровали с помошью алгоритма, Шифр подстановки." + Environment.NewLine + " Результат: " + richTextBox2.Text + Environment.NewLine + " Время работы алгоритма: " + stopwatch.ElapsedMilliseconds.ToString() + " миллисекунд." + Environment.NewLine + " Количество операций при шифровании текста: " + Convert.ToString(operationCount) + Environment.NewLine);
                        decrypt_button.Enabled = false;
                        encrypt_button.Enabled = false;
                        label9.Text = "Зашифрованный текст:";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void decrypt_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(richTextBox1.Text) == false && comboBox1.SelectedIndex != -1)
                {
                    if (comboBox1.SelectedIndex == 0 && string.IsNullOrWhiteSpace(textBox2.Text) == false)
                    {
                        if (textBox2.Text.All(char.IsDigit))
                        {
                            if (textBox2.Text.Length<10)
                            {
                                string line = richTextBox1.Text;
                                int operationCount;
                                stopwatch.Start();
                                richTextBox2.Text = Crypt.CaesarDecrypt(richTextBox1.Text, Convert.ToInt32(textBox2.Text), out operationCount);
                                stopwatch.Stop();
                                label9.Text = "Расшифрованный текст:";
                                MessageBox.Show(" Данные успешно расшифрованы!");
                                textBox1.Text += (" " + DateTime.Now.ToString() + Environment.NewLine + " Зашифрованную строку \"" + line + "\" расшифровали с помошью алгоритма, Шифр Цезаря." + Environment.NewLine + " Сдвиг: " + textBox2.Text + Environment.NewLine + " Результат: " + richTextBox2.Text + Environment.NewLine + " Время работы алгоритма: " + stopwatch.ElapsedMilliseconds.ToString() + " миллисекунд." + Environment.NewLine + " Количество операций при дешифровании текста: " + Convert.ToString(operationCount) + Environment.NewLine);
                                decrypt_button.Enabled = false;
                                encrypt_button.Enabled = false;
                                textBox2.Clear();
                            }
                            else
                                MessageBox.Show("Ошибка при вводе данных. Слишком большое число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                            MessageBox.Show("Ошибка при вводе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (comboBox1.SelectedIndex == 1 && string.IsNullOrWhiteSpace(textBox2.Text) == false)
                    {
                            string line = richTextBox1.Text;
                            stopwatch.Start();
                            richTextBox2.Text = Crypt.AESDecrypt(richTextBox1.Text, textBox2.Text);
                            stopwatch.Stop();
                            label9.Text = "Расшифрованный текст:";
                            MessageBox.Show(" Данные успешно расшифрованы!");
                            textBox1.Text += (" " + DateTime.Now.ToString() + Environment.NewLine + " Зашифрованную строку \"" + line + "\" расшифровали с помошью алгоритма, Шифр AES." + Environment.NewLine +" Ключ: " + textBox2.Text + Environment.NewLine + " Результат: " + richTextBox2.Text + Environment.NewLine + " Время работы алгоритма: " + stopwatch.ElapsedMilliseconds.ToString() + " миллисекунд." + Environment.NewLine);
                            decrypt_button.Enabled = false;
                            encrypt_button.Enabled = false;
                            textBox2.Clear();
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        string line = richTextBox1.Text;
                        int operationCount;
                        stopwatch.Start();
                        richTextBox2.Text = Crypt.SubstitutionDecrypt(richTextBox1.Text, out operationCount);
                        stopwatch.Stop();
                        label9.Text = "Расшифрованный текст:";
                        MessageBox.Show(" Данные успешно расшифрованы!");
                        textBox1.Text += (" " + DateTime.Now.ToString() + Environment.NewLine + " Зашифрованную строку \"" + line + "\" расшифровали с помошью алгоритма, Шифр подстановки." + Environment.NewLine + " Результат: " + richTextBox2.Text + Environment.NewLine + " Время работы алгоритма: " + stopwatch.ElapsedMilliseconds.ToString() + " миллисекунд." + Environment.NewLine + " Количество операций при дешифровании текста: " + Convert.ToString(operationCount) + Environment.NewLine);
                        decrypt_button.Enabled = false;
                        encrypt_button.Enabled = false;
                        textBox2.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clear_box_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            label8.Visible= false;
            textBox2.Visible = false;
        }

        private void save_box_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Документы Word (*.doc;*.docx)|*.doc;*.docx";
            saveFileDialog1.Title = "Сохранить файл";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName);

                if (fileExtension == ".txt" || fileExtension == ".docx" || fileExtension == ".doc")
                {
                    if (fileExtension == ".txt")
                    {
                        // Сохранение текста в TXT файл
                        System.IO.File.WriteAllText(fileName, textBox1.Text);
                        MessageBox.Show("Текст успешно сохранен в файле .txt!");
                    }
                    else if (fileExtension == ".doc")
                    {
                        // Сохранение текста в документ Word с помощью DocX
                        using (DocX document = DocX.Create(fileName))
                        {
                            document.InsertParagraph(textBox1.Text);
                            document.Save();
                            MessageBox.Show("Файл успешно сохранен в формате .doc!");
                        }
                    }
                    else if (fileExtension == ".docx")
                    {
                        // Сохранение текста в документ Word с помощью DocX
                        using (DocX document = DocX.Create(fileName))
                        {
                            document.InsertParagraph(textBox1.Text);
                            document.Save();
                            MessageBox.Show("Файл успешно сохранен в формате .docx!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выбран неподдерживаемый формат файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void open_box_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Все файлы (*.*)|*.*";
            openFileDialog1.Title = "Открыть файл";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                string fileExtension = Path.GetExtension(fileName);

                if (fileExtension == ".txt" || fileExtension == ".docx" || fileExtension == ".doc")
                {
                    if (fileExtension == ".txt")
                    {
                        // Чтение текста из TXT файла
                        string text = System.IO.File.ReadAllText(fileName);
                        richTextBox1.Text = text;
                        label1.Text = "Считанный текст с файла: " + fileName;
                        MessageBox.Show("Текст успешно загружен из файла .txt!");
                    }
                    else if (fileExtension == ".doc")
                    {
                        // Чтение текста из документа Word с помощью DocX
                        using (DocX document = DocX.Load(fileName))
                        {
                            string text = document.Text;
                            richTextBox1.Text = text;
                            label1.Text = "Считанный текст с файла: " + fileName;
                            MessageBox.Show("Текст успешно загружен из файла .doc!");
                        }
                    }
                    else if (fileExtension == ".docx")
                    {
                        // Чтение текста из документа Word с помощью DocX
                        using (DocX document = DocX.Load(fileName))
                        {
                            string text = document.Text;
                            richTextBox1.Text = text;
                            label1.Text = "Считанный текст с файла: " + fileName;
                            MessageBox.Show("Текст успешно загружен из файла .docx!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выбран неподдерживаемый формат файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ShowFileContentButton_Click(object sender, EventArgs e,int begin,int end,string chapter)
        {
            try
            {
                string fileName = "Справка_Шифрование.txt"; // Получаем только имя файла

                string directoryPath = Directory.GetCurrentDirectory(); // Получаем путь к текущей директории (папке проекта)

                string filePath = Path.Combine(directoryPath, fileName);

                if (File.Exists(filePath))
                {
                    
                        string line = ReadLineFromFile(filePath, begin,end);
                        if (!string.IsNullOrEmpty(line))
                        {
                            MessageBox.Show(line, chapter, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Указанная строка не найдена", "Ошибка");
                        }
                }
                else
                {
                    MessageBox.Show("Файл не найден", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка");
            }
        }

        private string ReadLineFromFile(string filePath, int begin, int end)
        {
            StringBuilder lines = new StringBuilder();
            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    for (int i = 1; i <= end; ++i)
                    {
                        string line = file.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        if (i >= begin)
                        {
                            lines.AppendLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка");
            }
            return lines.ToString();
        }

        private void CryptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitMenuItem_Click(sender, e);
        }
    }
}
