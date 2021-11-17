using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graf
{
    public partial class Result : Form
    {
        int vertex;
        int edge;
        public Result(int v, int e)
        {
            InitializeComponent();
            Result_textBox.Text = "";
            vertex = v;
            edge = e;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            Result_textBox.Text += $"Количество вершин {vertex}{Environment.NewLine}";
            Result_textBox.Text += $"Количество ребер {edge}{Environment.NewLine}";
        }
    }
}
