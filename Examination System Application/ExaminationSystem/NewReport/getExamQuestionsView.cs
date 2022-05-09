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
    public partial class getExamQuestionsView : Form
    {
        getExamQuestionsReport cry = new getExamQuestionsReport();
        public int eId { set; get; }
        public getExamQuestionsView(string id)
        {
            InitializeComponent();
            eId = int.Parse(id);
        }

        private void getExamQuestionsView_Load(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            DT = UserManager.getExamQuestions(eId);
            cry.Load(@"getExamQuestionsReport.rpt");
            cry.SetDataSource(DT);
            cry.SetDatabaseLogon("sa", "123");
            crystalReportViewer2.ReportSource = cry;
            crystalReportViewer2.DisplayToolbar = true;
        }
    }
}
