using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PrivateFontCollection customFonts = new PrivateFontCollection();
            customFonts.AddFontFile(Application.StartupPath + "\\Roman Numerals.ttf");
            label1.Font = new Font(customFonts.Families[0], 16, FontStyle.Regular);
            textBox2.Font = new Font(customFonts.Families[0], 16, FontStyle.Regular);
        }

        private void Form1_Load(object sender, EventArgs e)
        {//Disables right click context menu
            ContextMenu abc = new ContextMenu();
            textBox1.ContextMenu = abc;
        }

        private string ConvertedRomanNum(int num)
        {
            if (num > 3999999)
            {
                return "Enter a smaller value";
            }
            //Set Roman symbols and there respective values inside an array
            string[] romanSymbol = new string[] { "m", "cm", "d", "cd", "c", "xc", "l", "xl", "x", "Mx", "v", "Mv", "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] romanSymbolValue = { 1000000, 900000, 500000, 400000, 100000, 90000, 50000, 40000, 10000, 9000, 5000, 4000, 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string RomanNumber = "";
            int remainder = num;
            int quotient;
            for (int i = 0; i < romanSymbolValue.Length; i++)
            {   //Divides the Roman symbol value with the inputed number to determine the roman number 
                quotient = remainder / romanSymbolValue[i];
                remainder %= romanSymbolValue[i];
                if (quotient >= 1)
                {
                    for (int x = 1; x <= quotient; x++)
                    {
                        RomanNumber += romanSymbol[i];
                    }
                }

            }
            return RomanNumber;
        }

        private string ConvertedNumber(string RomanNumber)
        {
            string normalNum;
            /* Since the roman value of 3,999,999 is 15 charaters long, 
              the roman number length cannot exceed 15*/
            if (RomanNumber.Length > 15)
            {
                return "Enter a smaller value";
            }
            //Set Roman symbols and there respective values inside an array
            string[] romansymbols = new string[] { "m", "cm", "d", "cd", "c", "xc", "l", "xl", "x", "Mx", "v", "Mv", "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] romansymbolvalues = { 1000000, 900000, 500000, 400000, 100000, 90000, 50000, 40000, 10000, 9000, 5000, 4000, 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            int HinduArabic = 0;
            for (int i = 0; i < RomanNumber.Length; i++)
            {
                string charater = RomanNumber.Substring(i, 1);
                int value = romansymbolvalues[Array.IndexOf(romansymbols, charater)];
                int valuenext = 0;
                string nextcharater = "";
                /* Determins the Hindu-Arabic number by mathing the inputed charaters with the 
                roman symbol string thus giving its roman symbol value */
                if (i < RomanNumber.Length - 1)
                {
                    nextcharater = RomanNumber.Substring(i + 1, 1);
                    valuenext = romansymbolvalues[Array.IndexOf(romansymbols, nextcharater)];
                }
                if (value >= valuenext)
                {
                    HinduArabic += value;
                }
                else
                {
                    HinduArabic -= value;
                }
            }
            /* Matches the output of the Hindu-Arbic to Roman converter with the 
              input of Roman to Hindu Arabic convertor to check if the input is a valid Roamn number*/
            normalNum = HinduArabic.ToString();
            string rightNum = ConvertedRomanNum(Convert.ToInt32(normalNum));
            if (RomanNumber == rightNum)
            {
                return normalNum;
            }
            else
            {
                return "Invalid Input";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ShortcutsEnabled = false;
            label1.Visible = true;
            if (textBox1.TextLength > 7)
            {
                label1.Text = "Enter a smaller value";
            }
            else
            {
                if (textBox1.Text != "")
                    label1.Text = ConvertedRomanNum(Convert.ToInt32(textBox1.Text));
            }
            label1.Left = centreLabels(label1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.ShortcutsEnabled = false;
            label2.Visible = true;
            if (textBox2.Text != "")
                label2.Text = ConvertedNumber(textBox2.Text).ToString();
            label2.Left = centreLabels(label2);

        }
        // Stops any alphabet and specail charaters from being entered in the textbox 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        // Allows only the roman symbol letters in the textbox and the backspace key everything else is disabled
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || e.KeyChar == 'M' || e.KeyChar == 'C' || e.KeyChar == 'D' || e.KeyChar == 'X' || e.KeyChar == 'L' || e.KeyChar == 'I' || e.KeyChar == 'V' || +e.KeyChar == 'm' || e.KeyChar == 'c' || e.KeyChar == 'd' || e.KeyChar == 'x' || e.KeyChar == 'l' || e.KeyChar == 'v')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }


        }
        // Puts label 1 & label 2 in the center of the form 

        private int centreLabels(Label label)
        {
            int x = this.Width / 2 - label.Width / 2;
            return x;
        }

    }
}