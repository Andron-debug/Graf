using System;
using System.Windows.Forms;

namespace Graf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(textBox1.Text);
                if (count <= 0) throw new ApplicationException("Не допустимое количество");
                Form f;
                f = new Graf_input(count);
                f.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
