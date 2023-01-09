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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void lblCross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void hmsLabel_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();

            c1.Checked = true;
            pictureBox1.ImageLocation = string.Format(@"D:\Align Project\Hostel Management System\Image\" + ImageNumber + ".jpg ");

            DataSet ds = Connection.GetData("Select Count(*) from mst_addrooms");
            Int32 rows_count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            lbltotalroom.Text = rows_count.ToString();

            DataSet ds1 = Connection.GetData("Select Count(*) from mst_student");
            Int32 rows_count1 = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
            lbltotalstudent.Text = rows_count1.ToString();

            DataSet ds2 = Connection.GetData("Select Count(*) from mst_employee");
            Int32 rows_count2 = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
            lbltotalemployee.Text = rows_count2.ToString();

            DataSet ds3 = Connection.GetData("Select Count(*) from et_fees");
            Int32 rows_count3 = Convert.ToInt32(ds3.Tables[0].Rows[0][0]);
            lbltotalfees.Text = rows_count3.ToString();

            DataSet ds4 = Connection.GetData("Select Count(*) from et_emppayment");
            Int32 rows_count4 = Convert.ToInt32(ds4.Tables[0].Rows[0][0]);
            lbltotalpayment.Text = rows_count4.ToString();

        }
            Boolean labelVisible = true;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (labelVisible == true)
            {
                hmsLabel.Visible = true;
                labelVisible = false;
            }
            else
            {
                hmsLabel.Visible = false;
                labelVisible = true;
            }
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            AddNewRoomForm frm = new AddNewRoomForm();
            frm.Show();
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            NewStudentForm frm = new NewStudentForm();
            frm.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm frm = new UpdateDeleteStudentForm();
            frm.Show();
        }

        private void btnStudentFees_Click(object sender, EventArgs e)
        {
            StudentFeesForm frm = new StudentFeesForm();
            
                frm.Show();
            
        }

        private void btnStudentLiving_Click(object sender, EventArgs e)
        {
            StudentLivingForm frm = new StudentLivingForm();
            frm.Show();
        }

        private void btnLeavedStudent_Click(object sender, EventArgs e)
        {
            StudentLeavedForm frm = new StudentLeavedForm();
            frm.Show();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            NewEmployeeForm frm = new NewEmployeeForm();
            frm.Show();
        }

        private void btnupDelEmployee_Click(object sender, EventArgs e)
        {
            UpdateDeleteEmployeeForm frm = new UpdateDeleteEmployeeForm();
            frm.Show();
        }

        private void btnEmpPayment_Click(object sender, EventArgs e)
        {
            EmployeePaymentForm frm = new EmployeePaymentForm();
            
                frm.Show();
        }

        private void btnEmpWorking_Click(object sender, EventArgs e)
        {
            EmployeeWorkingForm frm = new EmployeeWorkingForm();
            frm.Show();
        }

        private void btnEmpLeaved_Click(object sender, EventArgs e)
        {
            EmpLeavedForm frm = new EmpLeavedForm();
            frm.Show();

        }
        private int ImageNumber = 1;

        private void LoadNextImages()
        {
            timer1.Start();
            ImageNumber++;
            if (ImageNumber > 6)
            {
                ImageNumber = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"D:\Align Project\Hostel Management System\Image\" + ImageNumber + ".jpg ");
            LoadChecked();
        }

        private void LoadPreviousImages()
        {
            timer1.Start();
            ImageNumber--;
            if (ImageNumber < 1)
            {
                ImageNumber = 6;
            }
            pictureBox1.ImageLocation = string.Format(@"D:\Align Project\Hostel Management System\Image\" + ImageNumber + ".jpg ");
            LoadChecked();
        }

        private void LoadChecked()
        {
            if (ImageNumber == 1) { c1.Checked = true; }
            else if (ImageNumber == 2) { c2.Checked = true; }
            else if (ImageNumber == 3) { c3.Checked = true; }
            else if (ImageNumber == 4) { c4.Checked = true; }
            else if (ImageNumber == 5) { c5.Checked = true; }
            else if (ImageNumber == 6) { cb6.Checked = true; }
        }

        private void ChangedCheck()
        {
            timer1.Start();
            if (c1.Checked == true) { ImageNumber = 1; }
            else if (c2.Checked == true) { ImageNumber = 2; }
            else if (c3.Checked == true) { ImageNumber = 3; }
            else if (c4.Checked == true) { ImageNumber = 4; }
            else if (c5.Checked == true) { ImageNumber = 5; }
            else if (cb6.Checked == true) { ImageNumber = 6; }
            pictureBox1.ImageLocation = string.Format(@"D:\Align Project\Hostel Management System\Image\" + ImageNumber + ".jpg ");
        }




        private void timer2_Tick(object sender, EventArgs e)
        {
            LoadNextImages();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            LoadPreviousImages();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            ChangedCheck();
        }
    }
}
