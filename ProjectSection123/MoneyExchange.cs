using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//Name: María Angélica González Aragón
//Date: November 16th
//Project Section2 - V1

namespace ProjectSection123
{
    public partial class MoneyExchange : Form
    {
        private Stopwatch stopwatch = new Stopwatch();
        public MoneyExchange()
        {
            InitializeComponent();
            stopwatch.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double value = double.Parse(textBox1.Text);

            try 
            {

                //Convert factor "To CAD" - November 12
                //1 CAD = 0.72 USD
                //1 CAD = 0.68 EUR
                //1 CAD = 0.59 GBP
                //1 CAD = 2916 COP
                //1 CAD = 13 MXN


                double curCAD = 1.0;   
                double curUSD = 0.72;  
                double curEUR = 0.68;  
                double curGBP = 0.59;  
                double curCOP = 2916;  
                double curMXN = 13;  

           
                double origin = 0.0;
                if (radioButton1.Checked)
                    origin = curCAD;
                else if (radioButton3.Checked)
                    origin = curUSD;
                else if (radioButton2.Checked)
                    origin = curEUR;
                else if (radioButton4.Checked)
                    origin = curGBP;
                else if (radioButton5.Checked)
                    origin = curCOP;

                string originCurrency = "";
                if (radioButton1.Checked)
                    originCurrency = " CAD";
                else if (radioButton3.Checked)
                    originCurrency = " USD";
                else if (radioButton2.Checked)
                    originCurrency = " EUR";
                else if (radioButton4.Checked)
                    originCurrency = " GBP";
                else if (radioButton5.Checked)
                    originCurrency = " COP";


                double resultCAD = value * (curCAD / origin);
                double resultUSD = value * (curUSD / origin);
                double resultEUR = value * (curEUR / origin);
                double resultGBP = value * (curGBP / origin);
                double resultCOP = value * (curCOP / origin);
                double resultMXN = value * (curMXN / origin);

               
                textBox2.Text = resultCAD.ToString("N2") + " CAD";
                textBox4.Text = resultUSD.ToString("N2") + " USD";
                textBox3.Text = resultEUR.ToString("N2") + " EUR";
                textBox5.Text = resultGBP.ToString("N2") + " GBP";
                textBox7.Text = resultCOP.ToString("N2") + " COP";
                textBox6.Text = resultMXN.ToString("N2") + " MXN";


                string exchangeText = DateTime.Now.ToShortDateString() + "\t" + DateTime.Now.ToShortTimeString() + "\n" +
                    value + originCurrency + " = " + resultCAD.ToString("N2") + " CAD;" + " " +
                    resultUSD.ToString("N2") + " USD;" + " " +
                    resultEUR.ToString("N2") + " EUR;" + " " +
                    resultGBP.ToString("N2") + " GBP;" + " " +
                    resultCOP.ToString("N2") + " COP;" + " " +
                    resultMXN.ToString("N2") + " MXN.";


                using (FileStream fs = new FileStream(@"./MoneyConversions.txt", FileMode.Append, FileAccess.Write))
                using (StreamWriter objW = new StreamWriter(fs))
                {
                    objW.WriteLine(exchangeText);
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Please, type a valid numerical number", "Format error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string exchangeText;
            FileStream fs = new FileStream(@"./MoneyConversions.txt", FileMode.Open, FileAccess.Read);
            StreamReader objR = new StreamReader(fs);
            exchangeText = objR.ReadToEnd();
            objR.Close();
            fs.Close();
            MessageBox.Show(exchangeText, "Money Converter History");
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            double totalMinutes = stopwatch.Elapsed.TotalMinutes;
            int minutes = (int)Math.Floor(totalMinutes);
            int seconds = (int)Math.Floor((totalMinutes - minutes) * 60);

            if (MessageBox.Show($"Do you want to quit this app? You have been here {minutes} minutes {seconds} seconds.", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                stopwatch.Stop();
                this.Close();
            }
        }

        private void MoneyExchange_Load(object sender, EventArgs e)
        {

        }
    }
}
