using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class ChangeyourPassword : Form
    {
        string m_user_name = "";
        public ChangeyourPassword(String username)
        {
            InitializeComponent();
            m_user_name = username;
        }

        private void ChangeyourPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPass.Text)
            {
                //String error = Connection.SetData("Insert into mst_user(password) values ('" + txtNewPassword + "')");
                //tring error = Connection.SetData("Update mst_user Set password = '" + txtNewPassword.Text + "' where user_name = " + m_user_name + "'");
                String error = Connection.SetData("Update mst_user Set password = '" + txtPassword.Text + "' where user_name = '" + m_user_name + "'");
                txtPassword.Text = "";
                txtConfirmPass.Text = "";
                txtPassword.Focus();

                MessageBox.Show("Reset Successfully");
            }
            else
            {
                MessageBox.Show("The new password do not match so enter same password");
            }
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
