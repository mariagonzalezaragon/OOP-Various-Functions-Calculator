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
    public partial class temperatureConverter2 : Form
    {
        private Stopwatch stopwatch = new Stopwatch();
        public temperatureConverter2()
        {
            InitializeComponent();
            stopwatch.Start();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Close();
            temperatureConverter obj = new temperatureConverter();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double celsius;
            double fahrenheit;
            string message;


            try
            {
                fahrenheit = Convert.ToDouble(textBox1.Text);
                celsius = (fahrenheit - 32)* 5 / 9;

                textBox2.Text = $"{celsius:F2} °C";

                message = GetMessageDescription(fahrenheit);

                if (fahrenheit >= 104)
                {
                    textBox3.BackColor = Color.Red;
                    textBox1.ForeColor = Color.Red;
                }
                else if (fahrenheit < 104 && fahrenheit >= 86)
                {
                    textBox3.BackColor = Color.Yellow;
                    textBox1.ForeColor = Color.Yellow;
                }
                else if (fahrenheit < 86 && fahrenheit >= 70)
                {
                    textBox3.BackColor = Color.Green;
                    textBox1.ForeColor = Color.Green;
                }
                else if (fahrenheit < 70 && fahrenheit >= 32)
                {
                    textBox3.BackColor = Color.Blue;
                    textBox1.ForeColor = Color.Blue;
                }
                else if (fahrenheit == -40)
                {
                    textBox3.Font = new Font(textBox3.Font, FontStyle.Bold);
                }

                textBox3.Text = message;

                string temperatureText = fahrenheit + " F = " + celsius.ToString("F2") + " C," +
                    "\t" + DateTime.Now.ToShortDateString() + "\t" +
                    DateTime.Now.ToShortTimeString() + ", " +
                    message;

                using (FileStream fs = new FileStream(@"./TempConversions.txt", FileMode.Append, FileAccess.Write))
                using (StreamWriter objW = new StreamWriter(fs))
                {
                    objW.WriteLine(temperatureText);
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

        private string GetMessageDescription(double fahrenheit)
        {

            if (fahrenheit >= 212)

                return " Water boils";

            else if (fahrenheit >= 104)
                return " Hot Bath";

            else if (fahrenheit >= 98.6)
                return " Body temperature";

            else if (fahrenheit >= 86)
                return "Beach weather";

            else if (fahrenheit >= 70)
                return "Room temperature";

            else if (fahrenheit >= 50)
                return "Cool Day";

            else if (fahrenheit >= 32)
                return "Freezing point of water";

            else if (fahrenheit >= 0)
                return "Very Cold Day";

            else if (fahrenheit >= -40)
                return "Extremely Cold Day \r\n(and the same number!) ";

            else
                return "Non valid value";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temperatureText;
            FileStream fs = new FileStream(@"./TempConversions.txt", FileMode.Open, FileAccess.Read);
            StreamReader objR = new StreamReader(fs);
            temperatureText = objR.ReadToEnd();
            objR.Close();
            fs.Close();
            MessageBox.Show(temperatureText, "Temperature Converter History");
        }

        private void btnExit_Click(object sender, EventArgs e)
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

        private void temperatureConverter2_Load(object sender, EventArgs e)
        {

        }
    }
}
