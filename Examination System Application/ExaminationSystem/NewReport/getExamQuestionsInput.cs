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
    public partial class getExamQuestionsInput : Form
    {
        public getExamQuestionsInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            NewReport.getExamQuestionsView frmReport = new NewReport.getExamQuestionsView(input);
            this.Hide();
            frmReport.ShowDialog();
            this.Show();
        }
    }
}
