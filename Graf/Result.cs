using System;
using System.Windows.Forms;
using Matrix;
using System.Collections.Generic;

namespace Graf
{
    public partial class Result : Form
    {
        int vertex;
        int edge;
        int loops;
        string connectivity;
        MyMatrix transport;
        CheckBox[,] graf;

        //Граф
        int max = -1;
        int max_vertex = -1;
        List<List<int>> comp;
        List<List<int>> gameltons;
        public Result(int v, int e, int l, int m, int mv, string c, List<List<int>> cm, MyMatrix t, CheckBox[,] g, List<List<int>> gam)
        {
            InitializeComponent();
            Result_textBox.Text = "";
            vertex = v;
            edge = e;
            loops = l;
            max = m;
            max_vertex = mv;
            connectivity = c;
            comp = cm;
            transport = t;
            graf = g;
            gameltons = gam;
        }

        //Орграф
        int max_in = -1;
        int max_out = -1;
        int max_in_vertex = -1;
        int max_out_vertex = -1;
        public Result(int v, int e, int l, int mxi, int mxiv, int mxo, int mxov, string c, MyMatrix t, CheckBox[,] g)
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
            transport = t;
            graf = g;
        }
        private void Result_Load(object sender, EventArgs e)
        {
            Result_textBox.Text += $"Количество вершин: {vertex}{Environment.NewLine}";

            Result_textBox.Text += $"Количество петель: {loops}{Environment.NewLine}";
            if (max != -1)
            {
                Result_textBox.Text += $"Количество ребер: {edge}{Environment.NewLine}";
                Result_textBox.Text += $"Максимальная степень {max} при вершине {max_vertex}{Environment.NewLine}";
            }
            if (max_in != -1)
            {
                Result_textBox.Text += $"Количество ребер дуг: {edge}{Environment.NewLine}";
                Result_textBox.Text += $"Максимальная степень по заходам {max_in} при вершине {max_in_vertex}{Environment.NewLine}";
                Result_textBox.Text += $"Максимальная степень по исходам {max_out} при вершине {max_out_vertex}{Environment.NewLine}";
            }
            Result_textBox.Text += $"Категория связности: {connectivity}{Environment.NewLine}";
            if (comp != null)
            {
                Result_textBox.Text += $"Количество компонент связности: {comp.Count}{Environment.NewLine}";
                Result_textBox.Text += "Компоненты связности:" + Environment.NewLine;
                foreach (List<int> l in comp)
                {
                    foreach (int c in l) Result_textBox.Text += c + " ";
                    Result_textBox.Text += Environment.NewLine;
                }
            }
            Result_textBox.Text += $"Матрица достижимости:{Environment.NewLine}{transport}";
            Result_textBox.Text += $"Матрица смежности:{Environment.NewLine}";
            for (int i = 0; i < vertex; i++)
            {
                for (int j = 0; j < vertex; j++)
                {
                    if (graf[i, j].Checked) Result_textBox.Text += "1 ";
                    else Result_textBox.Text += "0 ";
                }
                Result_textBox.Text += Environment.NewLine;
            }
            Result_textBox.Text += $"Список смежности:{Environment.NewLine}";
            for (int i = 0; i < vertex; i++)
            {
                Result_textBox.Text += i.ToString() + ": ";
                for (int j = 0; j < vertex; j++)
                {
                    if (graf[i, j].Checked) Result_textBox.Text += j.ToString()+" ";
                }
                Result_textBox.Text += Environment.NewLine;
            }
            Result_textBox.Text += $"Список инцеденциый:{Environment.NewLine}";
            for (int i = 0; i < vertex; i++)
            {
                Result_textBox.Text += i.ToString() + ": ";
                for (int j = 0; j < vertex; j++)
                {
                    if (graf[i, j].Checked)
                    {
                        int s = i;
                        int f = j;
                        if ((i > j)&&(max_in == -1))//не является орграфом
                        {
                            s = j;
                            f = i;
                        }
                        Result_textBox.Text += $"{s}-{f} ";
                    }
                    if ((max_in != -1)&& (graf[j, i].Checked)&&(i!=j))
                    {
                        Result_textBox.Text += $"{j}-{i} ";
                    }
                }
                Result_textBox.Text += Environment.NewLine;
            }
            Result_textBox.Text += "Гамильтоновы цылы:" + Environment.NewLine;
            if (gameltons.Count != 0)
            {
                foreach (List<int> l in gameltons)
                {
                    foreach (int c in l) Result_textBox.Text += c + " ";
                    Result_textBox.Text += Environment.NewLine;
                }
            }
            else 
                Result_textBox.Text += "НЕТ" + Environment.NewLine;

        }
    }
}
