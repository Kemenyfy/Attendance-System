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
    public partial class FormAddClass : Form
    {
        public int UserID { get; set; }
        public FormAddClass()
        {
            InitializeComponent();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.ClassesTableAdapter ada = new DataSet1TableAdapters.ClassesTableAdapter();
            ada.AddClass(metroTextBox1.Text, UserID);
            Close();
        }
    }
}
