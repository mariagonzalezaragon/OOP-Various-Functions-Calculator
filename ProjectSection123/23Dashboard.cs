using System;
using System.Diagnostics;
using System.Windows.Forms;


//Name: María Angélica González Aragón
//Date: November 16th
//Project Section2 - V1

namespace ProjectSection123
{
    public partial class frm23Dashboard : Form
    {

        private Stopwatch stopwatch = new Stopwatch();
        public frm23Dashboard()
        {
            InitializeComponent();
            stopwatch.Start();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Do you want to quit this app? You have been here {Math.Floor(stopwatch.Elapsed.TotalMinutes)} minutes", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                stopwatch.Stop(); 
                this.Close();
            }
        }
            private void button1_Click(object sender, EventArgs e)
        {
            LottoMax obj = new LottoMax();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lotto649 obj = new Lotto649();
            obj.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Lotto649 obj = new Lotto649();
            obj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temperatureConverter obj = new temperatureConverter();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MoneyExchange obj = new MoneyExchange();
            obj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IP_Validator obj = new IP_Validator();
            obj.ShowDialog();
        }
    }
}
