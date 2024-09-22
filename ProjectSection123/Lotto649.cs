using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

//Name: María Angélica González Aragón
//Date: November 7th
//Project Section1 - V2

namespace ProjectSection123
{
    public partial class Lotto649 : Form
    {

        private Stopwatch stopwatch = new Stopwatch();
        public Lotto649()
        {
            InitializeComponent();
            stopwatch.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string tempo = "", tempoText = "649, " +
            DateTime.Now.ToShortDateString() + "\t" +
            DateTime.Now.ToShortTimeString() + ", ";

            Random random = new Random();
            bool[] numbersGenerated = new bool[49];
           
            for (int i = 0; i < 7; i++)
            {
                int randomNumber;
                do
                {
                    randomNumber = random.Next(1, 49);
                } while (numbersGenerated[randomNumber]);
                numbersGenerated[randomNumber] = true;

                tempo += randomNumber.ToString() + "\t";
                
                if (i == 6)
                {
                    tempoText += "Extra " + randomNumber.ToString();
                }
            
                else
                {
                    tempoText += randomNumber.ToString() + ", ";
                }
            }

            textBox1.Text = tempo;

            FileStream fs = new FileStream(@"./LottoNumbers.txt", FileMode.Append, FileAccess.Write);
            StreamWriter objW = new StreamWriter(fs);
            objW.WriteLine(tempoText);
            objW.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tempoText;
            FileStream fs = new FileStream(@"./LottoNumbers.txt", FileMode.Open, FileAccess.Read);
            StreamReader objR = new StreamReader(fs);
            tempoText = objR.ReadToEnd();
            objR.Close();
            fs.Close();
            MessageBox.Show(tempoText,"Lotto History");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Do you want to quit lotto 649 Window? You have been here {Math.Floor(stopwatch.Elapsed.TotalMinutes)} minutes", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                stopwatch.Stop();
                this.Close();
            }
        }
    }
}
