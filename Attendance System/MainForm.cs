using System;

namespace Attendance_System
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public int loggedIn { get; set; }
        public int userID { get; set; }
        public MainForm()
        {
            InitializeComponent();
            loggedIn = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Classes' table. You can move, or remove it, as needed.
            this.classesTableAdapter.Fill(this.dataSet1.Classes);

            classesBindingSource.Filter = "UserID = '" + userID.ToString() + "'";
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (loggedIn == 0)
            {
            // Open Login Form 
                LoginForm newLogin = new LoginForm();
                newLogin.ShowDialog();

                if (newLogin.loginFlag == false)
                {
                    Close();
                }
                else
                {
                    userID = newLogin.UserID;
                    statusLblUser.Text = userID.ToString(); 
                    loggedIn = 1;
                    classesBindingSource.Filter = "UserID = '" + userID.ToString() + "'";
                }
            }
        }

        private void AddClassButton_Click(object sender, EventArgs e)
        {
            FormAddClass addClass = new FormAddClass();
            addClass.UserID = this.userID;
            addClass.ShowDialog();
        }
    }
}
