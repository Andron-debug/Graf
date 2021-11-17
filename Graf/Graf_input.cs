using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graf
{

    public partial class Graf_input : Form
    {
        CheckBox[,] graf;
        int vertex;
        public Graf_input(int count)
        {
            InitializeComponent();
            vertex = count;
        }

        private void Graf_input_Load(object sender, EventArgs e)
        {
            graf_tableLayoutPanel.ColumnCount = vertex + 1;
            graf_tableLayoutPanel.RowCount = vertex + 1;
            graf = new CheckBox[vertex, vertex];
            foreach (ColumnStyle s in graf_tableLayoutPanel.ColumnStyles)
            {
                s.SizeType = SizeType.Absolute;
                s.Width = 25;
            }
            foreach (RowStyle s in graf_tableLayoutPanel.RowStyles)
            {
                s.SizeType = SizeType.Absolute;
                s.Height = 25;
            }

            for (int i = 0; i < vertex; i++)
            {
                string name = i.ToString();
                //Заполнение 0 столбца
                Label l = new Label();
                l.TextAlign = ContentAlignment.MiddleLeft;
                l.Text = name;
                graf_tableLayoutPanel.Controls.Add(l, 0, i + 1);

                //Заполнение 0 строки
                Label l2 = new Label();
                l2.TextAlign = ContentAlignment.MiddleCenter;
                l2.Width = 25;
                l2.Text = name;
                graf_tableLayoutPanel.Controls.Add(l2, i + 1, 0);
            }
            for (int i = 1; i <= vertex; i++)
                for (int j = 1; j <= vertex; j++)
                {
                    graf[i - 1, j - 1] = new CheckBox();
                    graf[i - 1, j - 1].Width = 25;
                    graf_tableLayoutPanel.Controls.Add(graf[i - 1, j - 1], i, j);
                }
            this.Width = graf_tableLayoutPanel.Width + 40;


        }

        private void Graf_input_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        /*
        количество вершин ++
        количество ребер ++
        количество петель ++
        максимальная степень(для орграфа — по заходам и по исходам отдельно),
        категория связности
        (для графа — связный или несвязный, для орграфа — одна из четырех категорий — сильно связный, односторонне связный, слабо связный или несвязный).
        */
        private void Analyze_Click(object sender, EventArgs e)
        {
            int edge;//кол-во ребр
            int loops;//кол-во петель
            //Максимальная степень по исходам для орграфа
          
            //Максимальная степень по заходам для орграфа

            if (is_graf.Checked)
            {
                //Граф
                if (is_graf_test())
                {
                    loops = loopsCount();
                    edge = (checkedCount() - loops)/ 2 + loops;
                    // Максимальная степень
                    int max = -1;
                    int max_vertex = -1;
                    for (int i = 0; i < vertex; i++)
                    {
                        int t = 0;
                        for (int j = 0; j < vertex; j++)
                            t++;
                        if (t > max)
                        {
                            max = t;
                            max_vertex = i;
                        }
                    }
                    Form f = new Result(vertex, edge, loops, max, max_vertex);
                    f.ShowDialog();
                }
                else
                {

                    DialogResult result = MessageBox.Show("Матрица не симетрична! Провости замыкание автоматически?", "Ошибка ввода", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) closing();
                }
            }
            else
            {
                //Орграф
                edge = checkedCount();
                loops = loopsCount();
                //Максимальная степень по заходам
                int max_in = -1;
                int max_in_vertex = -1;
                for (int i = 0; i < vertex; i++)
                {
                    int t = 0;
                    for (int j = 0; j < vertex; j++)
                        if(graf[i, j].Checked)
                            t++;
                    if (t > max_in)
                    {
                        max_in = t;
                        max_in_vertex = i;
                    }
                }
                //Максимальная степень по исходам
                int max_out = -1;
                int max_out_vertex = -1;
                for (int j = 0; j < vertex; j++)
                {
                    int t = 0;
                    for (int i = 0; i < vertex; i++)
                        if (graf[i, j].Checked)
                            t++;
                    if (t > max_out)
                    {
                        max_out = t;
                        max_out_vertex = j;
                    }
                }
                Form f = new Result(vertex, edge, loops, max_in, max_in_vertex, max_out, max_out_vertex); //int mxi, int mxiv, int mxo, int mxov
                f.ShowDialog();
            }
        }
        private bool is_graf_test()
        {
            bool result = true;
            for (int i = 0; i < vertex; i++)
            {
                for (int j = i; j < vertex; j++)
                    if (graf[i, j].Checked != graf[j, i].Checked)
                    {
                        result = false;
                        break;
                    }
                if (!result) break;
            }
            return result;
        }
        private int checkedCount()
        {
            int result = 0;
            for (int i = 0; i < vertex; i++)
                for (int j = 0; j < vertex; j++)
                    if (graf[i, j].Checked) result++;
            return result;
        }
        private void closing()
        {
            for (int i = 0; i < vertex; i++)
                for (int j = i; j < vertex; j++)
                    if (graf[i, j].Checked != graf[j, i].Checked)
                    {
                        graf[i, j].Checked = true;
                        graf[j, i].Checked = true;
                    }
        }
        private int loopsCount()
        {
            int result = 0;
            for (int i = 0; i < vertex; i++)
                if (graf[i, i].Checked)
                    result++;
            return result;
        }

    }
}
