using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class frmInstr : Form
    {

        User currentUser;
        public frmInstr(User u)
        {
            currentUser = u;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewReport.getDepratmentStudentsInput frmReport = new NewReport.getDepratmentStudentsInput();
            this.Hide();
            frmReport.ShowDialog();
            this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewReport._2.getSutdentgradesInput frmReport = new NewReport._2.getSutdentgradesInput();
            this.Hide();
            frmReport.ShowDialog();
            this.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewReport.getCourseTopicsInput frmReport = new NewReport.getCourseTopicsInput();
            this.Hide();
            frmReport.ShowDialog();
            this.Show();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewReport.getStudentAnswersInput frmReport = new NewReport.getStudentAnswersInput();
            this.Hide();
            frmReport.ShowDialog();
            this.Show();



        }

        private void button3_Click(object sender, EventArgs e)
        {

            NewReport.NCourse_NumStudInput frmReport = new NewReport.NCourse_NumStudInput();
            this.Hide();
            frmReport.ShowDialog();
            this.Show();

        }

        private void frmInstr_Load(object sender, EventArgs e)
        {
           

            DataTable dt = UserManager.selectInsCourse(currentUser.UID);

        
            courseCombo.DataSource = dt;
            courseCombo2.DataSource = dt;
            cmbCourseName.DataSource = dt;

            courseCombo.DisplayMember = "Cname";
            courseCombo.ValueMember = "CID";

            courseCombo2.DisplayMember = "Cname";
            courseCombo2.ValueMember = "CID";

            cmbCourseName.DisplayMember = "Cname";
            cmbCourseName.ValueMember = "CID";


            grpOptions.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int cId = Convert.ToInt32(courseCombo.SelectedValue);

            int examId = 0;
            examId = UserManager.generate_Exam(cId);

            DataTable dt = UserManager.selectCourseStudents(cId);

            foreach(DataRow item in dt.Rows)
            {
                int studId = Convert.ToInt32(item["SID"]);
                UserManager.Insert_Student_EXAM_Course(studId,examId, cId);
            }

            frmInstr_Load(this, new EventArgs());

        }

        private void button5_Click(object sender, EventArgs e)
        {

            NewReport.getExamQuestionsInput frmReport =new NewReport.getExamQuestionsInput();
            this.Hide();
            frmReport.ShowDialog();
            this.Show();
        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {

            string topic = txtTopic.Text;
            int cId = Convert.ToInt32(courseCombo2.SelectedValue);
            int result = UserManager.addNewTopic(cId, topic);
            if(result == -1){
                MessageBox.Show("Topic found before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Topic Added", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




        }

        private void cmbQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch(cmbQuestionType.SelectedIndex)
            {

                case 0:
                    grpOptions.Visible = true;


                    txtChoice1.Visible = false;
                    txtChoice2.Visible = false;
                    txtChoice3.Visible = false;
                    txtChoice4.Visible = false;

                    lblChoice1.Visible = false;
                    lblChoice2.Visible = false;
                    lblChoice3.Visible = false;
                    lblChoice4.Visible = false;


                    cmbModelAnswer.Items.Clear();
                    cmbModelAnswer.Items.Add("A");
                    cmbModelAnswer.Items.Add("B");



                    break;
                case 1:
                    grpOptions.Visible = true;


                    txtChoice1.Visible = true;
                    txtChoice2.Visible = true;
                    txtChoice3.Visible = true;
                    txtChoice4.Visible = true;

                    lblChoice1.Visible = true;
                    lblChoice2.Visible = true;
                    lblChoice3.Visible = true;
                    lblChoice4.Visible = true;

                    cmbModelAnswer.Items.Clear();
                    cmbModelAnswer.Items.Add("A");
                    cmbModelAnswer.Items.Add("B");
                    cmbModelAnswer.Items.Add("C");
                    cmbModelAnswer.Items.Add("D");

                    break;
                default:

                    grpOptions.Visible = false;
                    break;
            }
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {

            // Get Data

            int courseID = Convert.ToInt32(cmbCourseName.SelectedValue);
            string questionType = (cmbQuestionType.SelectedIndex + 1).ToString();
            string questionDescription = txtQDescription.Text;
            string modelAnswer = cmbModelAnswer.SelectedItem.ToString();

            string choice1 = default;
            string choice2 = default;
            string choice3 = default;
            string choice4 = default;



            // Insert The Question
            int questionID = UserManager.Insert_Question(questionDescription, questionType, modelAnswer, courseID);


            // Insert The Choices
            if (questionType.Equals("2"))
            {
                Trace.WriteLine("I'm Here");
                choice1 = txtChoice1.Text;
                choice2 = txtChoice2.Text;
                choice3 = txtChoice3.Text;
                choice4 = txtChoice4.Text;

                UserManager.Insert_Question_Choices(questionID, "A", choice1);
                UserManager.Insert_Question_Choices(questionID, "B", choice2);
                UserManager.Insert_Question_Choices(questionID, "C", choice3);
                UserManager.Insert_Question_Choices(questionID, "D", choice4);

                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                MessageBox.Show("Question of Type MCQ Added Successfully", "Success", messageBoxButtons);

            }
            else if (questionType.Equals("1"))
            {

                MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
                MessageBox.Show("Question of Type T/F Added Successfully", "Success", messageBoxButtons);
            }
        }
    }
}
