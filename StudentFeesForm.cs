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
    public partial class StudentFeesForm : Form
    {
        public StudentFeesForm()
        {
            InitializeComponent();
        }

        private void StudentFeesForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            DateTimePickerMonth.Format = DateTimePickerFormat.Custom;
            DateTimePickerMonth.CustomFormat = "MMMM yyyy";  

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
             if(txtMobile.Text != "")
            {
                DataSet ds = Connection.GetData("Select name, email, roomNo from mst_student where mobile = '" + txtMobile.Text + "' ");
                if(ds.Tables[0].Rows.Count != 0)
                {

                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtRoomNo.Text = ds.Tables[0].Rows[0][2].ToString();
                    setDataGrid(txtMobile.Text);
                    //DataSet ds1 = Connection.GetData("Select * from et_fees where mobileNo = '"+ txtMobile +"' ");
                    //dataGridViewStudentFees.DataSource = ds1.Tables[0];
                }
                else
                {
                    MessageBox.Show("No Record Exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void setDataGrid(String mobile)
        {
            DataSet ds = Connection.GetData("Select * from et_fees where mobileNo = '" + mobile + "' ");
            dataGridViewStudentFees.DataSource = ds.Tables[0];
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(txtMobile.Text !="" && txtDuesAmmount.Text !="")
            {
                 DataSet ds = Connection.GetData("Select * from et_fees where  mobileNo = '"+ txtMobile.Text +"' and fmonth = '"+DateTimePickerMonth.Text  +"'  ");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    string mobile = txtMobile.Text;
                    string month = DateTimePickerMonth.Text;
                    Int64 amount = Int64.Parse(txtDuesAmmount.Text);
                    String error = Connection.SetData("Insert into et_fees (mobileNo, fmonth, amount) values ('"+ mobile +"','"+month+"', " + amount + ")");
                    if(error == "")
                    {
                        MessageBox.Show("Fees Paid..");
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Error in saving " + error);
                    }
                    
                }
                else
                {
                    MessageBox.Show("No dues of '"+ DateTimePickerMonth.Text+"' Left." , "information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            txtDuesAmmount.Clear();
            txtRoomNo.Clear();
            dataGridViewStudentFees.DataSource = 0;
        }
    }
}
