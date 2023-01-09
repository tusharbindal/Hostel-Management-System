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
    public partial class UpdateDeleteEmployeeForm : Form
    {
        public UpdateDeleteEmployeeForm()
        {
            InitializeComponent();
        }

        private void UpdateDeleteEmployeeForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from mst_employee where mobileNo = '"+txtMobile.Text +"' ");
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0][6].ToString();
                txtUniqueId.Text = ds.Tables[0].Rows[0][7].ToString();
                cmbDesiganation.Text = ds.Tables[0].Rows[0][8].ToString();
                cmbWorking.Text = ds.Tables[0].Rows[0][9].ToString();

            }
            else
            {
                MessageBox.Show("No Record Exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAll();

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String mobile = txtMobile.Text;
            String name = txtName.Text;
            String father_name = txtFather.Text;
            String mother_name = txtMother.Text;
            String email = txtEmail.Text;
            String address = txtAddress.Text;
            String uniqueId = txtUniqueId.Text;
            String designation = cmbDesiganation.Text;
            String working = cmbWorking.Text;
            String error = Connection.SetData("Update mst_employee set name = '" + name + "', father_name = '" + father_name + "', mother_name = '" + mother_name + "', email = '" + email + "',address = '" + address + "', uniqueId = '" + uniqueId + "', designation ='" + designation + "', working = '" + working + "' where mobileNo = '" + mobile + "' ");
            if(error == "")
            {
                MessageBox.Show("Data Updation Successful..");
                clearAll();

            }
            else
            {
                MessageBox.Show("Error is Messgae.." + error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                String error = Connection.SetData("Delete from mst_employee where mobileNo= '" + txtMobile.Text + "' ");
                if(error == "")
                {
                    MessageBox.Show("Employee Record Deleated..");
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Error is Delete Messgae.." + error);
                }

            }
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
            cmbDesiganation.SelectedIndex = -1;
            cmbDesiganation.SelectedIndex = -1;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
