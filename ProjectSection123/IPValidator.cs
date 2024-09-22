using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Net;

//Name: María Angélica González Aragón
//Date: November 23rd
//Project Section2 - V2

namespace ProjectSection123
{
    public partial class IP_Validator : ValidatorBase
    {
        public IP_Validator() : base()
        {
            
        }

        public override void ValidateTextBox1(string inputValue)
        {
            try
            {
                if (IsValidIPv4(inputValue))
                {
                    WriteToBinaryFile(inputValue);
                    MessageBox.Show(inputValue + " The IP is correct", "Success");
                }
                else
                {
                    MessageBox.Show(inputValue + " The IP must have 4 bytes, integer number, between 0 to 255, separated by a dot (255.255.255.255)", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        public override void ValidateTextBox2(string inputValue)
        {
            try
            {
                if (IsValidIPv6(inputValue))
                {
                    WriteToBinaryFile(inputValue);
                    MessageBox.Show(inputValue + " The IP is correct", "Success");
                }
                else
                {
                    MessageBox.Show(inputValue + ", The IP must have 8 quartets, hexadecimal numbers of 4 positions, separated by a colon (0123:4567:89ab:cdef:0123:4567:89ab:cdef)", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        public override bool IsValidIPv4(string ipAddressString)
        {
            string pattern = @"^(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]?[0-9])$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(ipAddressString);
        }

        public override bool IsValidIPv6(string textBox2Value)
        {
            string pattern = @"^([0-9a-fA-F]{4}:){7}[0-9a-fA-F]{4}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(textBox2Value);
        }

        public override void WriteToBinaryFile(string dataToWrite)
        {
            string pathBinary = @"C:\Users\maria\OneDrive\Desktop\Maria Universidad\2nd Term\OOP\Project\ProjectSection123\ProjectSection123\bin\Debug\IPAddressData.dat";

            using (FileStream fs = new FileStream(pathBinary, FileMode.Append, FileAccess.Write))
            using (BinaryWriter binaryOut = new BinaryWriter(fs))
            {
                
                string dataWithTimestamp = $"{dataToWrite} {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                binaryOut.Write(dataWithTimestamp);
            }
        }
    }
}