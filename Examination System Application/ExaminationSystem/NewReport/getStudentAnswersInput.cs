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
    public partial class getStudentAnswersInput : Form
    {
        public getStudentAnswersInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string eId = txtExamID.Text;
            string sId = txtStudId.Text;

            NewReport.getStudentAnswersView formReport = new NewReport.getStudentAnswersView(eId, sId);
            this.Close();
            formReport.ShowDialog();
            this.Show();



        }
    }
}
