using BLL;
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
    public partial class getStudentAnswersView : Form
    {
        getStudentAnswersReport cry = new getStudentAnswersReport();
        public int examId { get; set; }
        public int studentId { get; set; }
        public getStudentAnswersView(string eId,string studId)
        {
            InitializeComponent();
            examId = int.Parse(eId);
            studentId = int.Parse(studId);

        }

        private void getStudentAnswersView_Load(object sender, EventArgs e)
        {

            DataTable DT = new DataTable();
            DT = UserManager.studentAnswers(examId, studentId);
            cry.Load(@"getStudentAnswersReport.rpt");

            cry.SetDataSource(DT);
            cry.SetDatabaseLogon("sa", "123");
            crystalReportViewer2.ReportSource = cry;
            crystalReportViewer2.DisplayToolbar = true;








        }
    }
}
