using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExamDetailsManager
    {

        static DBManager dBmanager = new DBManager();

        public static DataTable SelectExamDetails(int _examID)
        {
            try
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@E_ID"] = _examID;
                return dBmanager.ExecuteDataTable("Exam_Details", map);
            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }


        #region Mapping

        internal static ExamDetailsList DataTable2ExamDetails(DataTable Dt)
        {
            ExamDetailsList examDetails = new ExamDetailsList();
            try
            {
                for (int i = 0; i < Dt?.Rows.Count; i++)
                {
                    examDetails.Add(DataRow2ExamDetails(Dt.Rows[i]));
                }
            }
            catch (Exception ex)
            {

            }
            return examDetails;
        }


        internal static ExamDetails DataRow2ExamDetails(DataRow Dr)
        {
            ExamDetails U = new ExamDetails();
            try
            {
                if (int.TryParse(Dr["EID"]?.ToString() ?? "-1", out int TempInt))
                    U.EID = TempInt;

                if (int.TryParse(Dr["QID"]?.ToString() ?? "-1", out TempInt))
                    U.QID = TempInt;

                if (int.TryParse(Dr["CID"]?.ToString() ?? "-1", out TempInt))
                    U.CID = TempInt;

                U.QDescription = Dr["QDescription"]?.ToString() ?? "NA";

                if (int.TryParse(Dr["QType"]?.ToString() ?? " - 1", out TempInt))
                    U.QType = TempInt;

                U.Model_Answer = Dr["Model_Answer"]?.ToString() ?? "NA";
            }
            catch (Exception ex)
            {

            }
            return U;
        }


        #endregion
    }
}
