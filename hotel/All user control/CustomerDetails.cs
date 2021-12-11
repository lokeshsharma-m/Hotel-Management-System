using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel.All_user_control
{
    public partial class CustomerDetails : UserControl
    {
        function fn = new function();
        string query;
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtSearchBy.SelectedIndex==0)
            {
                query = "select * from customer_detail";
                getRecord(query);
            }
            else if(txtSearchBy.SelectedIndex==1)
            {
                query= "select * from customer_detail where checkout is null";
                getRecord(query);
            }
            else if(txtSearchBy.SelectedIndex==2)
            {
                query = "select * from customer_detail where checkout is not null";
                getRecord(query);
            }   
        }

        private void getRecord(string query)
        {
            DataSet ds = fn.getdata(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
