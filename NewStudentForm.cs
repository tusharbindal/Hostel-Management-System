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
    public partial class NewStudentForm : Form
    {
        public NewStudentForm()
        {
            InitializeComponent();
        }

        private void NewStudentForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            DataSet ds = Connection.GetData("Select roomNo from mst_addrooms where roomStatus = 'Yes' and roomBooked = 'No' ");

            for(int i=0; i<ds.Tables[0].Rows.Count;i++)
            {
                Int64 room = Int64.Parse(ds.Tables[0].Rows[i][0].ToString());
                cmbRoomNo.Items.Add(room);
            }
        }

       
        private void cmbRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            txtCollage.Clear();
            txtIdProof.Clear();
            cmbRoomNo.SelectedIndex = -1;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // if (txtMobile.Text !="" && txtName.Text != "" && txtFather.Text! = "" && txtMother.Text != "" && txtEmail.Text != "" && txtAddress.Text != "" && txtCollege.Text != "" && txtIdProff.Text != "" && cmbRoomNo.SelectedIndex != -1)
            if (txtMobile.Text != "" && txtName.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtEmail.Text != "" && txtAddress.Text != "" && txtCollage.Text != "" && txtIdProof.Text != "" && cmbRoomNo.SelectedIndex != -1)
            {



                String mobile = txtMobile.Text;
                String name = txtName.Text;
                String father_name = txtFather.Text;
                String mother_name = txtMother.Text;
                String email = txtEmail.Text;
                String address = txtAddress.Text;
                String collage = txtCollage.Text;
                String id_proof = txtIdProof.Text;
                int roomNo = Convert.ToInt32(cmbRoomNo.Text.ToString());
                //String roomNo = cmbRoomNo.Text;

                string error = Connection.SetData("Insert into mst_student (mobile,name,father_name, mother_name, email,address, collage, id_proof, roomNo) values " +
                    "('" + mobile + "', '" + name + "', '" + father_name + "', '" + mother_name + "', '" + email + "', '" + address + "', '" + collage + "'," +
                    " '" + id_proof + "'," + roomNo + " ); ");
                if (error == "")
                {
                    error = Connection.SetData("update mst_addrooms set roomBooked= 'Yes' where roomNo = " + roomNo + "  ");
                    MessageBox.Show("Student Registration Successful..");
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Error in Saving : " + error);
                }
            }

            else
            {
                MessageBox.Show("Fill all empty space.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
