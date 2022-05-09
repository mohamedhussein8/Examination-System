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
    public partial class getSutdentgradesInput : Form
    {
        public getSutdentgradesInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studId = txtInput.Text;
            NewReport._2.getSutdentgradesFormView formReport = new NewReport._2.getSutdentgradesFormView(studId);

            this.Hide();
            formReport.ShowDialog();
            this.Show();




        }
    }
}
