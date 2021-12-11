using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace hotel.All_user_control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        string query;
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtMobile.Text!="" && txtGender.Text != "" && txtEmail.Text!="" && txtUserName.Text!="" && txtpassword.Text!="")
            {
                string name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                string gender = txtGender.Text;
                string email = txtEmail.Text;
                string username = txtUserName.Text;
                string pass = txtpassword.Text;

                if(txtMobile.Text.Length == 10)
                {
                    if(txtMobile.Text.IndexOf('0',0)!=0)
                    {
                        query = "insert into employee (ename,mobile,gender,emailid,username,pass) values('" + name + "'," + mobile + ",'" + gender + "','" + email + "','" + username + "','" + pass + "')";
                        fn.setData(query, "Employee Registered.");
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Number cannot start with 0");
                    }

                }
                else
                {
                    MessageBox.Show("Enter 10 digits ");
                }

            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
 
            getMaxID();
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee.SelectedIndex == 1)
            {
                setEmployee(guna2DataGridView1);
            }
            else if (tabEmployee.SelectedIndex == 2)
            {
                setEmployee(guna2DataGridView2);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid = " + txtID.Text+ " ";
                    fn.setData(query, "Record Deleted.");
                    tabEmployee_SelectedIndexChanged(this, null);
                }
            }
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        //***********************REQUIRED METHOD******************************
        public void getMaxID()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getdata(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSET.Text = (num + 1).ToString();
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtpassword.Clear();
        }

        public void setEmployee(DataGridView dgv)
        {
            query = "select * from employee";
            DataSet ds = fn.getdata(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if(Regex.IsMatch(txtEmail.Text,pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.txtEmail, "Please Provide Valid Mail Address");
                return;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("digits only allowed");
            }
        }
    }
}
