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
    public partial class getDepratmentStudentsInput : Form
    {
        public getDepratmentStudentsInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string deptId = txtInput.Text;
            var getDepratmentStudentsview = new NewReport.getDepratmentStudentsView(deptId);
            this.Hide();
            getDepratmentStudentsview.ShowDialog();
            this.Show();

        }
    }
}
