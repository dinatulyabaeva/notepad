using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp;

namespace блокнот
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt|TIM Notepad File(*.tnf)|*.tnf";
            Init();
        }
        public void Init() //инициализация 
        {
            file = "";
            FileChanged = false;
        }
        private string print = ""; //текст для печати
        private PrintPageEventHandler PrintPageHandler;
        public string file;
        public bool FileChanged;
        public System.Drawing.FontStyle a = FontStyle.Regular;
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename); //библиотека для работы с файлами
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл успешно открыт");
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Во мне надежда вьется" +
                            "Что, сколько не враждуй," +
                            "В душе твоей хранится" +
                            "Наш первый поцелуй.");
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void выбратьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument(); //объект для печати
            printDocument.PrintPage += PrintPageHandler; //обрaботчик события печати
            PrintDialog printDialog = new PrintDialog(); //настройка печати
            printDialog.Document = printDocument; //установка объекта печати для его настройки                                     
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print(); // печатаем
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show(); //обработчик на шрифт для открытия новой формы
        }

        private void выделитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog f = new FontDialog())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Font = f.Font;
                }
            }
        }

        private void изменитьЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog c = new ColorDialog())
            {
                if (c.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionColor = c.Color;
                }
            }
        }
    }
}
