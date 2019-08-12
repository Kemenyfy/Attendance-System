using Attendance_System.DataSet1TableAdapters;
using System;
using System.Data;

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

        private void AddStudentsButton_Click(object sender, EventArgs e)
        {
            StudentsForm students = new StudentsForm();
            students.ClassName = metroComboBox1.Text;
            students.ClassID = (int)metroComboBox1.SelectedValue;
            students.ShowDialog();
        }

        private void GetValuesButton_Click(object sender, EventArgs e)
        {
            // Check if records exists, if yes, load them for edit and if not create a record for each student and load for edit
            AttendanceRecordsTableAdapter ada = new AttendanceRecordsTableAdapter();
            DataTable dt = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);

            if (dt.Rows.Count > 0)
            {
                // We have records, so we can edit
                DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;
            }
            else
            {
                // Create record for each student
                // Get the class students list
                StudentsTableAdapter students_adapter = new StudentsTableAdapter();
                DataTable dt_Students = students_adapter.GetDataByClassID((int)metroComboBox1.SelectedValue);

                foreach (DataRow row in dt_Students.Rows)
                {
                    // Insert a new record for this student
                    ada.InsertQuery((int)row[0], (int)metroComboBox1.SelectedValue, dateTimePicker1.Text, "", row[1].ToString(), metroComboBox1.Text);
                }

                DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;
            }
        }
    }
}
