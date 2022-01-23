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
    public partial class SignUp : Form
    {
        Dictionary<int, Informations> Entity = new Dictionary<int, Informations>();
        private string _inputfilename;

        public SignUp(Dictionary<int, Informations> E, string filename)
        {
            InitializeComponent();
            Entity = E;
            _inputfilename = filename;
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtBirth.Text == "" || txtName.Text == "" || txtField.Text == "" || txtPlace.Text == "" || txtSpec.Text == "" || txtUniLoc.Text == "")
            {
                MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int PersonId = Entity.Keys.Last() + 1;
                List<string> specialities = txtSpec.Text.Split(',').ToList();
                Entity.Add(PersonId, new Informations
                {
                    name = txtName.Text,
                    dateOfBirth = txtBirth.Text,
                    field = txtField.Text,
                    universityLocation = txtUniLoc.Text,
                    workPlace = txtPlace.Text,
                    Specialties = specialities
                });
                MessageBox.Show($"Your ID is: {PersonId}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HomePage H = new HomePage(Entity, PersonId, true, _inputfilename);
                H.Show();
                this.Hide();
            }

           
        }
    }
}
