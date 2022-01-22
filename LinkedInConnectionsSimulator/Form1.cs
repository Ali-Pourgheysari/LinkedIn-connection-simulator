using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedInConnectionsSimulator
{
    public partial class Form1 : Form
    {
        Dictionary<int, Informations> Entity = new Dictionary<int, Informations>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Entity = ReadJson.readJsonfile();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Both Id and Name fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Entity.ContainsKey(Convert.ToInt32(txtid.Text)) && Entity[Convert.ToInt32(txtid.Text)].name == txtName.Text)
                {
                    HomePage H = new HomePage(Entity, Convert.ToInt32(txtid.Text));
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
            SignUp s = new SignUp();
            s.Show();
            this.Hide();
        }
    }
}
