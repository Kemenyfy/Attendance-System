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
    public partial class StudentsForm : Form
    {

        public int ClassID { get; set; }
        public string ClassName { get; set; }

        public StudentsForm()
        {
            InitializeComponent();
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.dataSet1.Students);
            labelClassID.Text = ClassID.ToString();
            labelClassName.Text = ClassName.ToString();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            this.studentsBindingSource.EndEdit();
            this.studentsTableAdapter.Update(dataSet1.Students);
        }
    }
}
