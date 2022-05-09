
using System.Windows.Forms;

namespace ExaminationSystem.Exam
{
    partial class frmExam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.cmbAnswers = new System.Windows.Forms.ComboBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblQuestionNum = new System.Windows.Forms.Label();
            this.lblChoice4Num = new System.Windows.Forms.Label();
            this.lblChoice3Num = new System.Windows.Forms.Label();
            this.lblChoice2Num = new System.Windows.Forms.Label();
            this.lblChoice1Num = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnNext.Location = new System.Drawing.Point(478, 321);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 26);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnPrev.Location = new System.Drawing.Point(108, 321);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(88, 26);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "Previos";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // cmbAnswers
            // 
            this.cmbAnswers.FormattingEnabled = true;
            this.cmbAnswers.Location = new System.Drawing.Point(629, 204);
            this.cmbAnswers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbAnswers.Name = "cmbAnswers";
            this.cmbAnswers.Size = new System.Drawing.Size(30, 21);
            this.cmbAnswers.TabIndex = 4;
            this.cmbAnswers.DropDownClosed += new System.EventHandler(this.cmbAnswers_DropDownClosed);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(594, 359);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(64, 20);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "End Exam";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblQuestionNum
            // 
            this.lblQuestionNum.AutoSize = true;
            this.lblQuestionNum.BackColor = System.Drawing.Color.White;
            this.lblQuestionNum.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblQuestionNum.Location = new System.Drawing.Point(99, 34);
            this.lblQuestionNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuestionNum.Name = "lblQuestionNum";
            this.lblQuestionNum.Size = new System.Drawing.Size(147, 21);
            this.lblQuestionNum.TabIndex = 6;
            this.lblQuestionNum.Text = "Question Number";
            // 
            // lblChoice4Num
            // 
            this.lblChoice4Num.AutoSize = true;
            this.lblChoice4Num.Location = new System.Drawing.Point(18, 109);
            this.lblChoice4Num.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChoice4Num.Name = "lblChoice4Num";
            this.lblChoice4Num.Size = new System.Drawing.Size(20, 19);
            this.lblChoice4Num.TabIndex = 18;
            this.lblChoice4Num.Text = "D";
            // 
            // lblChoice3Num
            // 
            this.lblChoice3Num.AutoSize = true;
            this.lblChoice3Num.Location = new System.Drawing.Point(18, 84);
            this.lblChoice3Num.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChoice3Num.Name = "lblChoice3Num";
            this.lblChoice3Num.Size = new System.Drawing.Size(21, 19);
            this.lblChoice3Num.TabIndex = 17;
            this.lblChoice3Num.Text = "C";
            // 
            // lblChoice2Num
            // 
            this.lblChoice2Num.AutoSize = true;
            this.lblChoice2Num.Location = new System.Drawing.Point(18, 56);
            this.lblChoice2Num.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChoice2Num.Name = "lblChoice2Num";
            this.lblChoice2Num.Size = new System.Drawing.Size(18, 19);
            this.lblChoice2Num.TabIndex = 16;
            this.lblChoice2Num.Text = "B";
            // 
            // lblChoice1Num
            // 
            this.lblChoice1Num.AutoSize = true;
            this.lblChoice1Num.Location = new System.Drawing.Point(18, 25);
            this.lblChoice1Num.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChoice1Num.Name = "lblChoice1Num";
            this.lblChoice1Num.Size = new System.Drawing.Size(21, 19);
            this.lblChoice1Num.TabIndex = 15;
            this.lblChoice1Num.Text = "A";
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(99, 62);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(480, 79);
            this.lblQuestion.TabIndex = 19;
            this.lblQuestion.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.lblChoice4Num);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.lblChoice3Num);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.lblChoice2Num);
            this.groupBox1.Controls.Add(this.lblChoice1Num);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(99, 153);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(478, 137);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose the correct answer:";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(47, 107);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(124, 23);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(47, 82);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(124, 23);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(47, 54);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(124, 23);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(47, 25);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(124, 23);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // frmExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(125)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblQuestionNum);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.cmbAnswers);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmExam";
            this.Text = "frmExam";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExam_FormClosed);
            this.Load += new System.EventHandler(this.frmExam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnNext;
        private Button btnPrev;
        private ComboBox cmbAnswers;
        private Button btnFinish;
        private Label lblQuestionNum;
        private Label lblChoice4Num;
        private Label lblChoice3Num;
        private Label lblChoice2Num;
        private Label lblChoice1Num;
        private RichTextBox lblQuestion;
        private GroupBox groupBox1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}