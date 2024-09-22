using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectSection123
{
    //Name: María Angélica González Aragón
    //Date: November 23rd
    //Project Section2 - V2
    public abstract class ValidatorBase : Form
    {
        protected Stopwatch stopwatch = new Stopwatch();

        public ValidatorBase()
        {

            DisplayCurrentDate();
            stopwatch.Start();
        }

        private void DisplayCurrentDate()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToLongDateString();
            label1.Text = $"Today: {formattedDate}";
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }

      
        public abstract void ValidateTextBox1(string inputValue);
        public abstract void ValidateTextBox2(string inputValue);

        public abstract bool IsValidIPv4(string ipAddressString);
        public abstract bool IsValidIPv6(string textBox2Value);

        public abstract void WriteToBinaryFile(string dataToWrite);

        public void ValidateTextBoxes()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    ValidateTextBox1(textBox1.Text.Trim());
                }
                else if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    ValidateTextBox2(textBox2.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string exchangeText;
            FileStream fs = new FileStream(@"./IPAddressData.dat", FileMode.Open, FileAccess.Read);
            StreamReader objR = new StreamReader(fs);
            exchangeText = objR.ReadToEnd();
            objR.Close();
            fs.Close();
            MessageBox.Show(exchangeText, "IP Validator History");
        }
    }
}
