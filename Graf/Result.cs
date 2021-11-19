using System;
using System.Windows.Forms;

namespace Graf
{
    public partial class Result : Form
    {
        int vertex;
        int edge;
        int loops;
        string connectivity;


        //Граф
        int max = -1;
        int max_vertex = -1;
        public Result(int v, int e, int l, int m, int mv, string c)
        {
            InitializeComponent();
            Result_textBox.Text = "";
            vertex = v;
            edge = e;
            loops = l;
            max = m;
            max_vertex = mv;
            connectivity = c;
        }
        //Орграф
        int max_in = -1;
        int max_out = -1;
        int max_in_vertex = -1;
        int max_out_vertex = -1;
        public Result(int v, int e, int l, int mxi, int mxiv, int mxo, int mxov, string c)
        {
            InitializeComponent();
            Result_textBox.Text = "";
            vertex = v;
            edge = e;
            loops = l;
            max_in = mxi;
            max_out = mxo;
            max_in_vertex = mxiv;
            max_out_vertex = mxov;
            connectivity = c;
        }
        private void Result_Load(object sender, EventArgs e)
        {
            Result_textBox.Text += $"Количество вершин {vertex}{Environment.NewLine}";

            Result_textBox.Text += $"Количество петель {loops}{Environment.NewLine}";
            if (max != -1)
            {
                Result_textBox.Text += $"Количество ребер {edge}{Environment.NewLine}";
                Result_textBox.Text += $"Максимальная степень {max} у вершины {max_vertex}{Environment.NewLine}";
            }
            if (max_in != -1)
            {
                Result_textBox.Text += $"Количество ребер дуг {edge}{Environment.NewLine}";
                Result_textBox.Text += $"Максимальная степень по заходам {max_in} у вершины {max_in_vertex}{Environment.NewLine}";
                Result_textBox.Text += $"Максимальная степень по исходам {max_out} у вершины {max_out_vertex}{Environment.NewLine}";
            }
            Result_textBox.Text += $"Фактор связности {connectivity}{Environment.NewLine}";
        }
    }
}
