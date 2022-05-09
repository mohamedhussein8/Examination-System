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
    public partial class NCourse_NumStudView : Form
    {
        NCourse_NumStudReport cry = new NCourse_NumStudReport();
        public int instId { get; set; }
        public NCourse_NumStudView(string id)
        {
            InitializeComponent();
            instId = int.Parse(id);
        }

        private void NCourse_NumStudView_Load(object sender, EventArgs e)
        {
           DataTable DT = new DataTable();
            DT = UserManager.NCourse_NumStud(instId);
            cry.Load(@"NCourse_NumStudReport.rpt");

            cry.SetDataSource(DT);
            cry.SetDatabaseLogon("sa", "123");
            crystalReportViewer1.ReportSource = cry;
            crystalReportViewer1.DisplayToolbar = true;


        }
    }
}
