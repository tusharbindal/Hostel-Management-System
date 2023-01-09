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
    public partial class NewEmployeeForm : Form
    {
        public NewEmployeeForm()
        {
            InitializeComponent();
        }

        private void NewEmployeeForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtMobile.Text !="" && txtName.Text != "" && txtFather.Text != "" && txtMother.Text != "" &&  txtEmail.Text != "" && txtAddress.Text != "" && txtUniqueId.Text != "" && cmbDesignation.SelectedIndex !=-1)
            {

                String mobile = txtMobile.Text;
                String name = txtName.Text;
                String father_name = txtFather.Text;
                String mother_name = txtMother.Text;
                String email = txtEmail.Text;
                String address = txtAddress.Text;
                String uniqueId  = txtUniqueId.Text;
                String designation = cmbDesignation.Text;

                //String error = Connection.SetData("Insert INTO mst_employee (mobileNo, father_name, mother_name, email, address, id_proof, designation) Values ('" + mobile + "',, '" + name + "', '" + father_name + "', '" + mother_name + "', '" + email + "', '" + address + "', '" + uniqueId + "', '" + designation + "') ");
                string error = Connection.SetData("Insert into mst_employee (mobileNo, name, father_name, mother_name, email, address, uniqueId, designation) values " +
                    " ('" + mobile + "', '" + name + "', '" + father_name + "', '" + mother_name + "', '" + email + "', '" + address + "'," +
                    " '" + uniqueId + "', '" + designation + "'); ");
                if (error == "")
                {
                    MessageBox.Show("Employee Registration Successful.");
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Error is Message.." + error);
                }
                
            }
            else
            {
                MessageBox.Show("Fill all Required Data.","Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll(); 
        }
        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtUniqueId.Clear();
            cmbDesignation.SelectedIndex = -1;
           
        }
    }
}
