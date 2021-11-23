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
            int r = panel1.Height / 4;
            int x0 = panel1.Width / 2;
            int y0 = panel1.Height / 2;
            double a = 2 * Math.PI / vextex;
            for (int i = 0; i <vextex; i++)
            {
                MyEllipse v = new MyEllipse(Convert.ToInt32(x0 + r * Math.Sin(a * i)), Convert.ToInt32(y0 + r * Math.Cos(a * i)), i.ToString());
                draws.Add(v);
            }

            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (IDraw el in draws) el.Draw((panel1.CreateGraphics()));
        }
    }
}
