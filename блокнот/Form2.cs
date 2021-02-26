using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace блокнот
{
    public partial class Form2 : Form
    {
        //передача настроек из побочной в начальную форму
        public System.Drawing.FontStyle a=FontStyle.Regular;

        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "курсив":
                    label1.Font = new Font(label1.Font.FontFamily, int.Parse(comboBox1.SelectedItem.ToString()), FontStyle.Italic);
                    break;
                case "полужирный":
                    label1.Font = new Font(label1.Font.FontFamily, int.Parse(comboBox1.SelectedItem.ToString()), FontStyle.Bold);
                    break;
                case "обычный":
                    label1.Font = new Font(label1.Font.FontFamily, int.Parse(comboBox1.SelectedItem.ToString()), FontStyle.Regular);
                    break;
            }
            a = label1.Font.Style;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
