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
    public partial class EmployeePaymentForm : Form
    {
        public EmployeePaymentForm()
        {
            InitializeComponent();
        }

        private void EmployeePaymentForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            DateTimePickerMonth.Format = DateTimePickerFormat.Custom;
            DateTimePickerMonth.CustomFormat = "MMMM yyyy";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                DataSet ds = Connection.GetData("Select name, email, designation from mst_employee where mobileNo = '" + txtMobile.Text + "' ");
                if (ds.Tables[0].Rows.Count != 0)
                {

                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                    cmbDesiganation.Text = ds.Tables[0].Rows[0][2].ToString();

                    setDataGrid(txtMobile.Text);

                   
                }
                else
                {
                    MessageBox.Show("No Record Exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else
            {
                MessageBox.Show("Enter some data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }         
        }

        public void setDataGrid(String mobile)
        {
            DataSet ds = Connection.GetData("Select * from et_emppayment where mobileNo = '" + mobile + "' ");
            dataGridViewEmpPayment.DataSource = ds.Tables[0];
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtDuesAmmount.Text != "")
            {
                DataSet ds = Connection.GetData("Select * from et_emppayment where  mobileNo = '" + txtMobile.Text + "' and fmonth = '" + DateTimePickerMonth.Text + "'  ");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    string mobile = txtMobile.Text;
                    string month = DateTimePickerMonth.Text;
                    Int64 amount = Int64.Parse(txtDuesAmmount.Text);
                    String error = Connection.SetData("Insert into et_emppayment (mobileNo, fmonth, amount) values ('" + mobile + "','" + month + "', " + amount + ")");
                    if (error == "")
                    {
                        MessageBox.Show("Salary for month. '"+ DateTimePickerMonth.Text +"' Paid ");
                        setDataGrid(mobile);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Error in saving " + error);
                    }

                }
                else
                {
                    MessageBox.Show("Payment of '" + DateTimePickerMonth.Text + "' Done.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtEmail.Clear();
            dataGridViewEmpPayment.DataSource = 0;
            DateTimePickerMonth.ResetText();
        }
    }
}

