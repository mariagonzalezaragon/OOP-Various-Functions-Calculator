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
    public partial class temperatureConverter : Form
    {
        private Stopwatch stopwatch = new Stopwatch();

        public temperatureConverter()
        {
            InitializeComponent();
            stopwatch.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double celsius;
            double fahrenheit;
            string message;


            try
            {
                celsius = Convert.ToDouble(textBox1.Text);
                fahrenheit = (celsius * 9 / 5) + 32;

                textBox2.Text = $"{fahrenheit:F2} °F";

                message = GetMessageDescription(celsius);

                if (celsius >= 40)
                {
                    textBox3.BackColor = Color.Red;
                    textBox1.ForeColor = Color.Red;
                }
                else if (celsius < 40 && celsius >= 30)
                {
                    textBox3.BackColor = Color.Yellow;
                    textBox1.ForeColor = Color.Yellow;
                }
                else if (celsius < 30 && celsius >= 21)
                {
                    textBox3.BackColor = Color.Green;
                    textBox1.ForeColor = Color.Green;

                }
                else if (celsius < 21 && celsius >= 0)
                {
                    textBox3.BackColor = Color.Blue;
                    textBox1.ForeColor = Color.Blue;
                }
                else if (celsius == -40)
                {
                    textBox3.Font = new Font(textBox3.Font, FontStyle.Bold);

                }

                textBox3.Text = message;

                string temperatureText = celsius + " C = " + fahrenheit.ToString("F2") + " F," +
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

        private string GetMessageDescription(double celsius)
        {
            if (celsius >= 100)

                return " Water boils";

            else if (celsius >= 40)
                return " Hot Bath";

            else if (celsius >= 37)
                return " Body temperature";

            else if (celsius >= 30)
                return "Beach weather";

            else if (celsius >= 21)
                return "Room temperature";

            else if (celsius >= 10)
                return "Cool Day";

            else if (celsius >= 0)
                return "Freezing point of water";

            else if (celsius >= -18)
                return "Very Cold Day";

            else if (celsius >= -40)
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Close();
            if (radioButton2.Checked)
            {

                temperatureConverter2 obj = new temperatureConverter2();

                obj.StartPosition = FormStartPosition.CenterParent;

                obj.ShowDialog(this);

            }
        }

        private void temperatureConverter_Load(object sender, EventArgs e)
        {

        }

        private void temperatureConverter_Load_1(object sender, EventArgs e)
        {

        }
    }
}


