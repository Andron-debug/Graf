using System;
using System.Windows.Forms;

namespace Graf
{
    public partial class Result : Form
    {
        int vertex;
        int edge;
        int loops;
        public Result(int v, int e, int l)
        {
            InitializeComponent();
            Result_textBox.Text = "";
            vertex = v;
            edge = e;
            loops = l;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            Result_textBox.Text += $"Количество вершин {vertex}{Environment.NewLine}";
            Result_textBox.Text += $"Количество ребер {edge}{Environment.NewLine}";
            Result_textBox.Text += $"Количество петель {loops}{Environment.NewLine}";
        }
    }
}
