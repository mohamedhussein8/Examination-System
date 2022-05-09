using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSystem.NewReport
{
    public partial class getCourseTopicsInput : Form
    {
        public getCourseTopicsInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = txtinput.Text;
            NewReport.getCourseTopicsView formReport = new NewReport.getCourseTopicsView(input);
            this.Hide();
            formReport.ShowDialog();
            this.Show();
        }
    }
}
