using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_System
{
    public partial class LoginForm : Form
    {
        public bool loginFlag { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            loginFlag = false;
        }

        private void MetroButtonLogin_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.UsersTableAdapter userAdapter = new DataSet1TableAdapters.UsersTableAdapter();
            DataTable dt = userAdapter.GetDataByUserAndPassword(metroTextBoxUser.Text, metroTextBoxPassword.Text);

            if (dt.Rows.Count > 0)
            {
                //Valid Login
                MessageBox.Show("Login Successful");
                loginFlag = true;
            }
            else
            {
                //Not Valid Login
                MessageBox.Show("Access Denied");
                loginFlag = false;
            }

            Close();
        }
    }
}
