using System;
using System.Windows.Forms;

namespace PZN8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            if (input.Length != 7 || !IsAllDigits(input))
            {
                MessageBox.Show("Ungültige Eingabe. Es müssen 7 Ziffern sein.");
                return;
            }

            int lastDigit = CalculateLastDigit(input);
            MessageBox.Show($"Die berechnete letzte Ziffer ist: {lastDigit}\nDer vollständige PZN-8-Code lautet: {input}{lastDigit}");
        }

        public static int CalculateLastDigit(string code)
        {
            int sum = 0;
            for (int i = 1; i < 8; i++)
            {
                //sum += (code[i] - '0') * (8 - i);
                sum += (code[i] - '0') * i;
            }

            int checksum = (11 - (sum % 11)) % 11;
            return checksum == 10 ? 0 : checksum; // Wenn die Prüfziffer 10 ist, muss die letzte Ziffer 0 sein
        }

        private static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}