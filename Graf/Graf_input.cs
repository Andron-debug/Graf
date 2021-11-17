using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrix;

namespace Graf
{
    public partial class Graf_input : Form
    {
        int vertex;
        MyMatrix graf;
        public Graf_input(int count)
        {
            InitializeComponent();
            vertex = count;
            graf = new MyMatrix(count, count);
        }

        private void Graf_input_Load(object sender, EventArgs e)
        {
            graf_tableLayoutPanel.ColumnCount = vertex + 1;
            graf_tableLayoutPanel.RowCount = vertex + 1;
            
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
                    CheckBox cb = new CheckBox();
                    cb.Width = 25;
                    graf_tableLayoutPanel.Controls.Add(cb, i, j);
                }
            this.Width = graf_tableLayoutPanel.Width + 40;


        }

        private void Graf_input_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
