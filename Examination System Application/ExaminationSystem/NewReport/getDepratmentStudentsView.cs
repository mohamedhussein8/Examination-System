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
    public partial class getDepratmentStudentsView : Form
    {
        getDepratmentStudentsReport cry = new getDepratmentStudentsReport();
        public int deptID { get; set; }
        public getDepratmentStudentsView(string id)
        {
            InitializeComponent();
            deptID = int.Parse(id);

        }

        private void getDepratmentStudentsView_Load(object sender, EventArgs e)
        {

            DataTable DT = new DataTable();
            DT = UserManager.getDepratmentStudents(deptID);
            cry.Load(@"getDepratmentStudentsReport.rpt");

            cry.SetDataSource(DT);
            cry.SetDatabaseLogon("sa", "123");
            getDepartMentStudreportViewer.ReportSource = cry;
            getDepartMentStudreportViewer.DisplayToolbar = true;



        }

        private void getDepartMentStudreportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
