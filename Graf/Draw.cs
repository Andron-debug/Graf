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
    public partial class Draw : Form
    {
        int vextex;
        bool type;
        CheckBox[,] graf;
        List<IDraw> draws;
        MyEllipse[] vertex_array;

        public Draw(int v, bool t, CheckBox[,] g)
        {
            InitializeComponent();
            vextex = v;
            type = t;
            graf = g;
        }

        private void Draw_Load(object sender, EventArgs e)
        {
            draws = new List<IDraw>();
            vertex_array = new MyEllipse[vextex];
            int r = panel1.Height / 4;
            int x0 = panel1.Width / 2;
            int y0 = panel1.Height / 2;
            double a = 2 * Math.PI / vextex;
            //Добавление вершин
            for (int i = 0; i <vextex; i++)
            {
                MyEllipse v = new MyEllipse(Convert.ToInt32(x0 + r * Math.Sin(a * i)), Convert.ToInt32(y0 + r * Math.Cos(a * i)), i.ToString());
                vertex_array[i] = v;
                draws.Add(v);
            }
            //Добавление ребер
            if (type)//если граф
            {
                for (int i = 0; i < vextex; i++)
                    for (int j = i; j < vextex; j++)
                    {
                        if ((graf[i, j].Checked) && (i != j))
                        {
                            MyLine eg = new MyLine(vertex_array[i].X, vertex_array[i].Y, vertex_array[j].X, vertex_array[j].Y);
                            draws.Add(eg);
                        }
                        if ((graf[i, j].Checked) && (i == j))
                        {
                            MyEllipse eg = new MyEllipse(vertex_array[i].X - vertex_array[i].R - vertex_array[i].R/2, vertex_array[i].Y - vertex_array[i].R - vertex_array[i].R / 2, "L");
                            draws.Add(eg);
                        }
                    }
            }
            else//если орграф
            {
                for (int i = 0; i < vextex; i++)
                    for (int j = 0; j < vextex; j++)
                    {
                        if ((graf[i, j].Checked) && (i != j))
                        {
                            MyArrow eg = new MyArrow(vertex_array[i].X, vertex_array[i].Y, vertex_array[j].X, vertex_array[j].Y);
                            draws.Add(eg);
                        }
                        if ((graf[i, j].Checked) && (i == j))
                        {
                            MyEllipse eg = new MyEllipse(vertex_array[i].X - vertex_array[i].R - vertex_array[i].R / 2, vertex_array[i].Y - vertex_array[i].R - vertex_array[i].R / 2, "L");
                            draws.Add(eg);
                        }
                    }
            }

            draws.Reverse();
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (IDraw el in draws) el.Draw((panel1.CreateGraphics()));
        }
    }
}
