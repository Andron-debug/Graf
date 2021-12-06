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
    public partial class Gamilton : Form
    {
        List<List<int>> gameltons;
        public Gamilton(List<List<int>> gam)
        {
            InitializeComponent();
            gameltons = gam;
        }

        private void Gamilton_Load(object sender, EventArgs e)
        {
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
