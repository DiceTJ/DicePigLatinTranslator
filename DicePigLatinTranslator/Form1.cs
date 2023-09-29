using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DicePigLatinTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEnglish.Text = "";
            txtPigLatin.Text = ""; 
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            string english = txtEnglish.Text.Trim();
            if (!string.IsNullOrEmpty(txtEnglish.Text)) 
            {
                string[] words = english.Split(' ');
                string piglatin = "";
                foreach (string word in words) 
                {
                    piglatin += TranslateWordWithCaps(word) + " ";
                }
                txtPigLatin.Text = piglatin;
            }
            else
            {
                MessageBox.Show("You must enter text to be translated!", "Enter");
                txtEnglish.Focus();
            }
        }

            private string TranslateWordWithCaps(string word)
        {
            string punct = "";
            if (word.EndsWith(".") || word.EndsWith(",") || word.EndsWith(";") || word.EndsWith(":") || word.EndsWith("!") || word.EndsWith("?"))
            {
                punct = word.Substring(word.Length - 1);
                word = word.Remove(word.Length - 1,1);

            }

            if (isInitialCap(word))
                word = toInitialCap(Translateword(word));
            if (isUpper(word))
                word = Translateword(word).ToUpper();
            if (isLower(word))
                word = Translateword(word).ToLower();

            return word;

        }

            private string Translateword(string word) 
        {
            char c = word[0];
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
            {
                word += "way";
            }
            else
            {
                if (c == 'y' || c == 'Y')
                {
                    word = word.Remove(0, 1);
                    word += c.ToString();
                    c = word[0];
                }
                while (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u' &&  c != 'A' && c != 'E' && c != 'I' && c != 'O' && c != 'U' && c != 'y' && c != 'Y')
                {
                    word = word.Remove(0, 1);
                    word += c.ToString();
                    c = word[0];
                }
                word += "ay";
            }
            
            return word;
        }

        private bool isUpper(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (isUpper(word[i]) == false)
                    return false;



            }
            return true;
        }

        private bool isLower(string word)
        {
            for(int i = 0; i < word.Length;i++)
                if (isLower(word[i])== false)
                    return false;
            return true;

        }

        private bool isInitialCap(string word)
        {
            char firstLetter = word[0];
            string otherLetters = word.Remove(0, 1);
            if (isUpper(firstLetter) && isLower(otherLetters))
                return true;
            else
                return false;


        }
        private bool isUpper(char c)
        {
            if (c >= 65 && c <= 90 || c.ToString() == "'")
                return true;
            else
                return false;
            


        }

        private bool isLower(char c)
        {
            if (c >= 97 && c<= 122 || c.ToString() == "'")
                return true;
            else
                return false;


        }

        private string toInitialCap(string word)
        {
            string firstLetter = word.Substring(0, 1).ToUpper();
            string otherLetters = word.Substring(1).ToLower();
            return firstLetter + otherLetters;


        }
    }   

}
