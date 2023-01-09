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
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from mst_student where mobile = '" + txtMobile.Text + "'");
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0][6].ToString();
                txtCollage.Text = ds.Tables[0].Rows[0][7].ToString();
                txtIdProof.Text = ds.Tables[0].Rows[0][8].ToString();
                txtRoomNo.Text = ds.Tables[0].Rows[0][9].ToString();
                cmbLiving.Text = ds.Tables[0].Rows[0][10].ToString();
               
            }
            else
            {
                clearAll();
                MessageBox.Show("No Record with this Mobile No Exists..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtCollage.Clear();
            txtIdProof.Clear();
            txtRoomNo.Clear();
            cmbLiving.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String mobile = txtMobile.Text;
            String name = txtName.Text;
            String fname = txtFather.Text;
            String mname = txtMother.Text;
            String email = txtEmail.Text;
            String address = txtAddress.Text;
            String collage = txtCollage.Text;
            String idproof = txtIdProof.Text;
            Int64 room_no = Int64.Parse(txtRoomNo.Text);
            String living = cmbLiving.Text;
            String error = Connection.SetData("Update mst_student set name = '" + name + "', father_name = '" + fname + "', mother_name = '" + mname + "'," +
                " email = '" + email + "', address = '" + address + "', collage = '" + collage + "', id_proof = '" + idproof + "', roomNo = '" + room_no + "'," +
                " living = '" + living + "' where mobile = '" + mobile + "' ");
            // " living = '" + living + "' where mobile = '" + mobile + "' update mst_addroom set booked = '" + living + "' where room_no = '" + room_no + "' ");
            if (error == "")
            {
                error = Connection.SetData(" update mst_addroom set roomBooked = '" + living + "' where roomNo = '" + room_no + "' ");
                MessageBox.Show("Data Updation Successfull...");
                clearAll();
            }
            else
            {
                MessageBox.Show("Error in updating: " + error);
            }
        }
           
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataSet ds = Connection.GetData("Delete from mst_student where mobile = '" + txtMobile.Text + "' ");
                MessageBox.Show("Student Record Deleted...");
                clearAll();
            }
        }

        private void UpdateDeleteStudentForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
        }

        private void txtRoomNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
