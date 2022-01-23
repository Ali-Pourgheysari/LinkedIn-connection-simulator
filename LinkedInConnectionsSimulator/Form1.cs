using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LinkedInConnectionsSimulator
{
    public partial class Form1 : Form
    {
        Dictionary<int, Informations> Entity = new Dictionary<int, Informations>();
        private string _inputfilename;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void read()
        {
            string input;
            do
            {
                input = Interaction.InputBox("Enter input file name", "Input", "users");

                if (input == "")
                {
                    MessageBox.Show("Please enter input file name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } while (input == "");

            ReadJson.filename(input);
            Entity = ReadJson.readJsonfile();
            _inputfilename = input;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Both Id and Name fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                read();
                if (Entity.ContainsKey(Convert.ToInt32(txtid.Text)) && Entity[Convert.ToInt32(txtid.Text)].name == txtName.Text)
                {
                    HomePage H = new HomePage(Entity, Convert.ToInt32(txtid.Text), false, _inputfilename);
                    H.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Id or Name doesn't fit, Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            read();
            SignUp s = new SignUp(Entity, _inputfilename);
            s.Show();
            this.Hide();
        }
    }
}
