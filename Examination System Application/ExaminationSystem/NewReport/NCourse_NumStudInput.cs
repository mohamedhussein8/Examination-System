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
    public partial class NCourse_NumStudInput : Form
    {
        public NCourse_NumStudInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            NewReport.NCourse_NumStudView formReport = new NewReport.NCourse_NumStudView(input);
            this.Hide();
            formReport.ShowDialog();
            this.Show();


        }
    }
}
