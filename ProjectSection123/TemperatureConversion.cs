using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectSection123
{
    public class TemperatureConversionBase : Form
    {
        protected Stopwatch stopwatch = new Stopwatch();

        public TemperatureConversionBase()
        {
            InitializeComponent();
            stopwatch.Start();
        }

        protected virtual void ConvertTemperature()
        {
            // Implement temperature conversion logic in the derived classes
        }

        protected void DisplayTemperatureHistory()
        {
            string temperatureText;
            using (FileStream fs = new FileStream(@"./TempConversions.txt", FileMode.Open, FileAccess.Read))
            using (StreamReader objR = new StreamReader(fs))
            {
                temperatureText = objR.ReadToEnd();
            }
            MessageBox.Show(temperatureText, "Temperature Converter History");
        }

        protected void ExitApplication()
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

        protected string GetMessageDescription(double celsius)
        {
            if (celsius >= 100)
                return " Water boils";

            if (celsius >= 40)
                return " Hot Bath";

            if (celsius >= 37)
                return " Body temperature";

            if (celsius >= 30)
                return "Beach weather";

            if (celsius >= 21)
                return "Room temperature";

            if (celsius >= 10)
                return "Cool Day";

            if (celsius >= 0)
                return "Freezing point of water";

            if (celsius >= -18)
                return "Very Cold Day";

            if (celsius >= -40)
                return "Extremely Cold Day \r\n(and the same number!) ";

            return "Non valid value";
        }

        // Common UI components and events can be declared here
        // You can override Load event, etc., if needed

        private void InitializeComponent()
        {
            // Common UI components initialization can be done here
        }
    }
}
