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
    public partial class getCourseTopicsView : Form
    {
        CourseTopicsReport cry = new CourseTopicsReport();
        public int cId { set; get; }
        public getCourseTopicsView( string id)
        {

            InitializeComponent();
            cId = int.Parse(id);
        }

        private void getCourseTopicsView_Load(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            DT = UserManager.CourseTopics(cId);
            cry.Load(@"getCourseTopicsView.rpt");
            cry.SetDataSource(DT);
            cry.SetDatabaseLogon("sa", "123");
            crystalReportViewer2.ReportSource = cry;
            crystalReportViewer2.DisplayToolbar = true;
        }
    }
}
