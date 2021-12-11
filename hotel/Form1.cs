using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel
{
    public partial class Form1 : Form
    {
        function fn = new function();
        string query;
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void btnlogin_Click(object sender, EventArgs e)
        {
            query = "select username,pass from employee where username='"+txtusername.Text+"' and  pass='"+txtpassword.Text+"'";
            DataSet ds = fn.getdata(query);


            if(ds.Tables[0].Rows.Count != 0)
            {
                labelerror.Visible = false;
                dashboard dash = new dashboard();
                this.Hide();
                dash.Show();
            }
            else
            {
                labelerror.Visible = true;
                txtpassword.Clear();
            }
        }
    }
}
