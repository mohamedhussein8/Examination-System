
namespace ExaminationSystem.NewReport
{
    partial class getDepratmentStudentsView
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
            this.getDepartMentStudreportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.getDepratmentStudentsReport1 = new ExaminationSystem.NewReport.getDepratmentStudentsReport();
            this.SuspendLayout();
            // 
            // getDepartMentStudreportViewer
            // 
            this.getDepartMentStudreportViewer.ActiveViewIndex = 0;
            this.getDepartMentStudreportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.getDepartMentStudreportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.getDepartMentStudreportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getDepartMentStudreportViewer.Location = new System.Drawing.Point(0, 0);
            this.getDepartMentStudreportViewer.Name = "getDepartMentStudreportViewer";
            this.getDepartMentStudreportViewer.ReportSource = this.getDepratmentStudentsReport1;
            this.getDepartMentStudreportViewer.Size = new System.Drawing.Size(800, 450);
            this.getDepartMentStudreportViewer.TabIndex = 0;
            this.getDepartMentStudreportViewer.Load += new System.EventHandler(this.getDepartMentStudreportViewer_Load);
            // 
            // getDepratmentStudentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.getDepartMentStudreportViewer);
            this.Name = "getDepratmentStudentsView";
            this.Text = "getDepratmentStudentsView";
            this.Load += new System.EventHandler(this.getDepratmentStudentsView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer getDepartMentStudreportViewer;
        private getDepratmentStudentsReport getDepratmentStudentsReport1;
    }
}