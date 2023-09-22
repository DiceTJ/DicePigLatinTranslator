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
            if (!string.IsNullOrEmpty(txtEnglish.Text)) 
            {
                //Do all the rules

            }
            else
            {
                MessageBox.Show("You must enter text to be translated!", "Enter");
                txtEnglish.Focus();
            }
        }
    }
}
