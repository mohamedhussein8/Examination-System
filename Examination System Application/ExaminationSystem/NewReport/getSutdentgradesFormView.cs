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

namespace ExaminationSystem.NewReport._2
{
    public partial class getSutdentgradesFormView : Form
    {

        getSutdentgrades cry = new getSutdentgrades();
        public int studId { get; set;}
        public getSutdentgradesFormView(string id)
        {
            InitializeComponent();
            studId = int.Parse(id);



        }

        private void getSutdentgradesFormView_Load(object sender, EventArgs e)
        {

            DataTable DT = new DataTable();
            DT = UserManager.getSutdentgrades(studId);
            cry.Load(@"getSutdentgrades.rpt");

            cry.SetDataSource(DT);
            cry.SetDatabaseLogon("sa", "123");
            crystalReportViewer2.ReportSource = cry;
            crystalReportViewer2.DisplayToolbar = true;


        }
    }
}
