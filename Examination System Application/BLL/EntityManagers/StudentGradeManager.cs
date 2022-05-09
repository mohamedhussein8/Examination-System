using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentGradeManager
    {
        static DBManager dBmanager = new DBManager();

        public static StudentGradeList SelectStudentGrades()
        {
            try
            {
                return DataTable2StudentGrades(dBmanager.ExecuteDataTable("Select_User_Course_Join"));
            }
            catch (Exception ex)
            {

            }
            return new StudentGradeList();
        }



        #region Mapping

        internal static StudentGradeList DataTable2StudentGrades(DataTable Dt)
        {
            StudentGradeList studentGrades = new StudentGradeList();
            try
            {
                for (int i = 0; i < Dt?.Rows.Count; i++)
                {
                    studentGrades.Add(DataRow2StudentGrade(Dt.Rows[i]));
                }
            }
            catch (Exception ex)
            {

            }
            return studentGrades;
        }


        internal static StudentGrade DataRow2StudentGrade(DataRow Dr)
        {
            StudentGrade SC = new StudentGrade();
            try
            {

                if (int.TryParse(Dr["SID"]?.ToString() ?? "-1", out int TempInt))
                    SC.SID = TempInt;

                if (int.TryParse(Dr["CID"]?.ToString() ?? "-1", out TempInt))
                    SC.CID = TempInt;

                SC.userName = Dr["userName"]?.ToString() ?? "NA";


                SC.Cname = Dr["Cname"]?.ToString() ?? "NA";

                if (int.TryParse(Dr["Grade"]?.ToString() ?? "-1", out TempInt))
                    SC.Grade = TempInt;
            }
            catch (Exception ex)
            {

            }
            return SC;
        }

        #endregion
    }
}