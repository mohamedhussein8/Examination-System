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

namespace ExaminationSystem.Exam
{
    public partial class frmExam : Form
    {
        int currentQuestion = 0;
        DataTable examDetailsTable;
        DataTable questionChoiceTable;
        QuestionChoiceList questionChoicesList;
        BindingSource bindingSourceExamDetails;
        List<RadioButton> radioButtonsList = new List<RadioButton>() { };
        string[] examAnswers;

        public User CurrentUser { get; set; }
        public int ExamID { get; set; }
        public int CourseID { get; set; }

        public frmExam(User _currentUser, int _examID, int _courseID)
        {
            InitializeComponent();
            bindingSourceExamDetails = new BindingSource();
            questionChoicesList = new QuestionChoiceList();
            examDetailsTable = new DataTable();
            questionChoiceTable = new DataTable();
            examAnswers = new string[10];

            for (int i = 0; i < examAnswers.Length; i++)
            {
                examAnswers[i] = "A";
            }

            radioButtonsList = new List<RadioButton>() { radioButton1, radioButton2, radioButton3, radioButton4};
            CurrentUser = _currentUser;
            ExamID = _examID;
            CourseID = _courseID;

            Trace.WriteLine(ExamID);
        }

        private void frmExam_Load(object sender, EventArgs e)
        {

            examDetailsTable = ExamDetailsManager.SelectExamDetails(ExamID);
            bindingSourceExamDetails.DataSource = examDetailsTable;

            lblQuestionNum.Text = "1";
            lblQuestion.DataBindings.Add("Text", bindingSourceExamDetails, "QDescription");

            DataRowView exam = (DataRowView)bindingSourceExamDetails.Current;


            questionChoicesList = QuestionChoiceManager.SelectQuestionChoice();


            var result = questionChoicesList.Where((Q) => Q.QID == (int)exam.Row["QID"]).ToList();

            cmbAnswers.DataSource = QuestionChoiceManager.SelectQuestionChoice((int)exam.Row["QID"]);
            cmbAnswers.DisplayMember = "Description";
            cmbAnswers.ValueMember = "ChoiceNum";

            ShowAnswers(exam, result);
        }



        private void btnNext_Click(object sender, EventArgs e)
        {

            int index = bindingSourceExamDetails.IndexOf(bindingSourceExamDetails.Current);
            if (index < bindingSourceExamDetails.Count - 1)
            {

                bindingSourceExamDetails.MoveNext();
                lblQuestionNum.Text = (bindingSourceExamDetails.IndexOf(bindingSourceExamDetails.Current) + 1).ToString();

                DataRowView exam = (DataRowView)bindingSourceExamDetails.Current;


                questionChoicesList = QuestionChoiceManager.SelectQuestionChoice();


                var result = questionChoicesList.Where((Q) => Q.QID == (int)exam.Row["QID"]).ToList();
                ShowAnswers(exam, result);


                cmbAnswers.DataSource = QuestionChoiceManager.SelectQuestionChoice((int)exam.Row["QID"]);
                cmbAnswers.DisplayMember = "Description";
                cmbAnswers.ValueMember = "ChoiceNum";


            }
            DataRowView ex= (DataRowView)bindingSourceExamDetails.Current;
            if (ex.Row["QType"].Equals(2))
            {

                Getcurrentselection(2);
            }
            else
            {
                Getcurrentselection(4);

            }
            if (index < bindingSourceExamDetails.Count - 1) currentQuestion++;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int index = bindingSourceExamDetails.IndexOf(bindingSourceExamDetails.Current);
            if (index != 0)
            {

                bindingSourceExamDetails.MovePrevious();
                lblQuestionNum.Text = (bindingSourceExamDetails.IndexOf(bindingSourceExamDetails.Current) + 1).ToString();

                DataRowView exam = (DataRowView)bindingSourceExamDetails.Current;
                questionChoicesList = QuestionChoiceManager.SelectQuestionChoice();
                questionChoiceTable = QuestionChoiceManager.SelectQuestionChoice((int)exam.Row["QID"]);


                Trace.WriteLine(questionChoiceTable.Rows[0].ToString());

                var result = questionChoicesList.Where((Q) => Q.QID == (int)exam.Row["QID"]).ToList();

                ShowAnswers(exam, result);


                cmbAnswers.DataSource = questionChoiceTable;
                cmbAnswers.DisplayMember = "Description";
                cmbAnswers.ValueMember = "ChoiceNum";
            }

            DataRowView ex = (DataRowView)bindingSourceExamDetails.Current;
            if (ex.Row["QType"].Equals(2))
            {

                Getcurrentselection(2);
            }
            else
            {
                Getcurrentselection(4);

            }
            if (index != 0) currentQuestion--;

        }



        private void Getcurrentselection(int numberOfQuestion)
        {

            for (int i = 0; i < numberOfQuestion; i++)
            {
                bool flag = radioButtonsList[i].Checked;
                Trace.WriteLine(flag);

                if (flag)
                {
                    string symbol = GetAnswerSymbol(i);
                    examAnswers[currentQuestion] = symbol;
                    Trace.WriteLine(symbol);
                }


            }
        }

        private string GetAnswerSymbol(int index)
        {
            string result;
            switch(index)
            {
                case 0:
                    result = "A";
                    break;
                case 1:
                    result = "B";
                    break;
                case 2:
                    result = "C";
                    break;
                case 3:
                    result = "D";
                    break;
                default:
                    result = "A";
                    break;
            }

            return result;
        }

        private void ShowAnswers(DataRowView currentExam, List<QuestionChoice> _questionChoiceList)
        {
            if (currentExam.Row["QType"].Equals("2"))
            {
                radioButton1.Text = "True";
                radioButton2.Text = "False";

                radioButton3.Visible = false;
                radioButton4.Visible = false;

                lblChoice3Num.Visible = false;
                lblChoice4Num.Visible = false;
            }
            else
            {

                radioButton3.Visible = true;
                radioButton4.Visible = true;

                lblChoice3Num.Visible = true;
                lblChoice4Num.Visible = true;


                radioButton1.Text = _questionChoiceList[0].Description;
                radioButton2.Text = _questionChoiceList[1].Description;
                radioButton3.Text = _questionChoiceList[2].Description;
                radioButton4.Text = _questionChoiceList[3].Description;

                _questionChoiceList.Clear();
            }
        }

        private void frmExam_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
        }


        private void cmbAnswers_DropDownClosed(object sender, EventArgs e)
        {

            int index = bindingSourceExamDetails.IndexOf(bindingSourceExamDetails.Current);
            examAnswers[index] = (string)cmbAnswers.SelectedValue;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            foreach(var item in examAnswers)
            {
                Trace.WriteLine($"Answer ->{item}");
            }
            int result = StudentCourseManager.ExamAnswer(ExamID, CurrentUser.UID, CourseID, examAnswers);
            this.Close();

            Trace.WriteLine(result);
        }
    }
}
