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
    public partial class AddNewRoomForm : Form
    {
       
        public AddNewRoomForm()
        {
            InitializeComponent();
          
        }

        private void AddNewRoomForm_Load(object sender, EventArgs e)
        {
             this.Location = new Point(350, 170);
            lblRoom.Visible = false;
            lblRoomExist.Visible = false;

            DataSet ds = Connection.GetData("select * from mst_addrooms ");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblRoom.Text == "Room Found.")
            {
                DataSet ds = Connection.GetData("Delete from mst_addrooms where rooNno = '" + txtRoomNo2.Text + "'");
                MessageBox.Show("Room Details Deleted.");
                AddNewRoomForm_Load(this, null);

            }
            else
            {
                MessageBox.Show("Trying to delete which doesn't Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            //100
            DataSet ds = Connection.GetData("Select * from mst_addrooms where roomNo ="+ txtRoomNo1.Text +" ");
            if(ds.Tables[0].Rows.Count == 0)
            {
                string status;
               // string booked;
                if(checkBox1.Checked)
                {
                    status = "Yes";
                    //booked = "Yes";
                }
                else
                {
                    status = "No";
                    //booked = "No";
                }
                lblRoomExist.Visible = false;

                DataSet ds1 = Connection.GetData("Insert into mst_addrooms (roomNo, roomStatus) values (" + txtRoomNo1.Text + ", '" + status + "')");
                MessageBox.Show("Room Added.");
                AddNewRoomForm_Load(this, null);


            }
            else
            {
                lblRoomExist.Text = "Room All Ready Exist.";
                lblRoomExist.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from mst_addrooms where roomNo = '" + txtRoomNo2.Text + "' ");
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblRoom.Text = "No Room Exist.";
                lblRoom.Visible = true;
                checkBox2.Checked = false;
            }
            else
            {
                lblRoom.Text = "Room Found.";
                lblRoom.Visible = true;
                if (ds.Tables[0].Rows[0][1].ToString() == "Yes")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String status;
            if (checkBox2.Checked)
            {
                status = "Yes";
            }
            else
            {
                status = "No";
            }
            DataSet ds = Connection.GetData("Update mst_addrooms set roomStatus = '" + status + "' where roomNo = '" + txtRoomNo2.Text + "'");
            MessageBox.Show("Details Updated.");
            AddNewRoomForm_Load(this, null);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
