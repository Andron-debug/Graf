using Matrix;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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
                    graf_tableLayoutPanel.Controls.Add(graf[i - 1, j - 1], j, i);
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
        максимальная степень(для орграфа — по заходам и по исходам отдельно)++
        категория связности
        (для графа — связный или несвязный, для орграфа — одна из четырех категорий — сильно связный, односторонне связный, слабо связный или несвязный).
        */
        private void Analyze_Click(object sender, EventArgs e)
        {
            
            int edge;//кол-во ребр
            int loops;//кол-во петель
            string connectivity = "";
            if (is_graf.Checked)
            {
                //Граф
                if (is_graf_test())
                {
                    loops = loopsCount();
                    edge = (checkedCount() - loops) / 2 + loops;
                    // Максимальная степень
                    int max = -1;
                    int max_vertex = -1;
                    for (int i = 0; i < vertex; i++)
                    {
                        int t = 0;
                        for (int j = 0; j < vertex; j++)
                            if (graf[i, j].Checked)
                            {
                                t++;
                                if (i == j) t++;
                            }
                        if (t > max)
                        {
                            max = t;
                            max_vertex = i;
                        }
                    }

                    // Проверка связности
                    // Проверка связности
                    connectivity = "связный";
                    List<List<int>> comp = new List<List<int>>();
                    for (int i = 0; i < vertex; i++)
                    {
                        int maxj = i;
                        List<int> tcom = new List<int>();
                        for (int j = i; j < vertex; j++)
                        {

                            bool[] visited = new bool[vertex];
                            if (!dfs(i, j, visited))
                            {
                                connectivity = "несвязный";
                            }
                            else
                            {
                                tcom.Add(j);
                                maxj = j;
                            }

                        }
                        i = maxj;
                        comp.Add(tcom);
                    }
                    Form f = new Result(vertex, edge, loops, max, max_vertex, connectivity, comp, transport(), graf);
                    f.ShowDialog();
                }
                else
                {

                    DialogResult result = MessageBox.Show("Матрица не симетрична! Провости симетризацию?", "Ошибка ввода", MessageBoxButtons.YesNo);
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
                for (int j = 0; j < vertex; j++)
                {
                    int t = 0;
                    for (int i = 0; i < vertex; i++)
                        if (graf[i, j].Checked)
                            t++;
                    if (t > max_in)
                    {
                        max_in = t;
                        max_in_vertex = j;
                    }
                }
                //Максимальная степень по исходам
                int max_out = -1;
                int max_out_vertex = -1;
                for (int i = 0; i < vertex; i++)
                {
                    int t = 0;
                    for (int j = 0; j < vertex; j++)
                        if (graf[i, j].Checked)
                            t++;
                    if (t > max_out)
                    {
                        max_out = t;
                        max_out_vertex = i;
                    }
                }
                connectivity = "сильно связный";
                for (int i = 0; i < vertex; i++)
                {
                    for(int j = 0; j< vertex; j++) 
                    {
                        bool[] visited = new bool[vertex];
                        if (!dfs(i, j, visited))
                        {
                            visited = new bool[vertex];
                            if (dfs(j, i, visited) && (connectivity != "слабо связный") && (connectivity != "несвязный"))
                            {
                                connectivity = "односторонне связный";
                            }
                            else if ((connectivity != "слабо связный") && (connectivity != "несвязный"))
                            {
                                if (weak_con()) connectivity = "слабо связный";
                                else connectivity = "несвязный";
                                break;
                            }
                            else break;
                        }
                        if ((connectivity == "слабо связный") || (connectivity == "несвязный")) break;
                    }
                }
                Form f = new Result(vertex, edge, loops, max_in, max_in_vertex, max_out, max_out_vertex, connectivity, transport(), graf); 
                f.ShowDialog();
            }
        }
        //Проверка симетричности матрицы
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
        //Количество связий
        private int checkedCount()
        {
            int result = 0;
            for (int i = 0; i < vertex; i++)
                for (int j = 0; j < vertex; j++)
                    if (graf[i, j].Checked) result++;
            return result;
        }
        //Симетричное замыкание матрицы
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
        //Количество петель
        private int loopsCount()
        {
            int result = 0;
            for (int i = 0; i < vertex; i++)
                if (graf[i, i].Checked)
                    result++;
            return result;
        }
        //Матрица достижимости
        private MyMatrix transport()
        {
            MyMatrix result;
            result = new MyMatrix(vertex, vertex);
            for (int i = 0; i < vertex; i++)
                for (int j = 0; j < vertex; j++)
                {
                    if (graf[i, j].Checked)
                        result[i, j] = 1;
                    if (i == j) result[i, j] = 1;
                }
            bool trans = false;
            int count = 1;
            while (!trans)
            {
                MyMatrix p;
                p = result * result;
                for (int i = 1; i < count; i++)
                    p *= p;
                count++;
                trans = true;
                for (int i = 0; i < vertex; i++)
                    for (int j = 0; j < vertex; j++)
                    {
                        if (p[i, j] > 1) p[i, j] = 1;
                        if ((p[i, j] != result[i, j]) && (p[i, j] == 1)) trans = false;
                        if (p[i, j] == 1) result[i, j] = 1;
                    }

            }
            return result;
        }

        //Глубокй поиск
        bool dfs (int u, int t, bool[] visited)
        {
            if (u == t) return true;
            visited[u] = true;
            for (int j = 0; j < vertex; j++)
                if ((graf[u, j].Checked) && (!visited[j]) && (dfs(j, t, visited))) return true;
            return false;
        }
        bool dfs(int u, int t, bool[] visited, bool[,] gr)
        {
            if (u == t) return true;
            visited[u] = true;
            for (int j = 0; j < vertex; j++)
                if ((gr[u, j]) && (!visited[j]) && (dfs(j, t, visited, gr))) return true;
            return false;
        }

        //Проверка слабой связности орграфа
        bool weak_con()
        {
            bool[,] gr = new bool[vertex, vertex];
            for (int i = 0; i < vertex; i++)
                for (int j = 0; j < vertex; j++)
                    if (graf[i, j].Checked)
                    {
                        gr[i, j] = true;
                        gr[j, i] = true;
                    }
            
            for (int i = 0; i < vertex; i++)
            {
                for (int j = 0; j < vertex; j++)
                {
                    bool[] visited = new bool[vertex];
                    if (!dfs(i, j, visited, gr)) return false;
                }

            }
                
            return true;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            if (is_graf.Checked)
            {
                if (is_graf_test())
                {
                    Form f = new Draw(vertex, is_graf.Checked, graf);
                    f.ShowDialog();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Матрица не симетрична! Провости симетризацию?", "Ошибка ввода", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) closing();
                }
            }
            else
            {
                Form f = new Draw(vertex, is_graf.Checked, graf);
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            closing();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < vertex; i++)
                for (int j = 0; j < vertex; j++)
                    graf[i, j].Checked = false;
        }
    }
}
