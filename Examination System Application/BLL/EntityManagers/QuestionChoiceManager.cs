using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuestionChoiceManager
    {

        static DBManager dBmanager = new DBManager();

        public static QuestionChoiceList SelectQuestionChoice()
        {
            try
            {
                //Dictionary<string, object> map = new Dictionary<string, object>();
                //map["@Q_ID"] = _questionID;
                return DataTable2QuestionChoiceList(dBmanager.ExecuteDataTable("Select_Choices_All"));
            }
            catch (Exception ex)
            {

            }
            return new QuestionChoiceList();
        }

        public static DataTable SelectQuestionChoice(int _questionID)
        {
            try
            {
                DataTable newResult = new DataTable();
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@Q_ID"] = _questionID;


                DataTable result = dBmanager.ExecuteDataTable("Select_Choices", map);

                if (result.Rows.Count == 0)
                {

                    newResult.Columns.Add("QID");
                    newResult.Columns.Add("ChoiceNum");
                    newResult.Columns.Add("Description");

                    newResult.Rows.Add(new object[] { _questionID, "A", "True" });
                    newResult.Rows.Add(new object[] { _questionID, "B", "False" });

                    return newResult;
                }

                return result;
            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }


        #region Mapping

        internal static QuestionChoiceList DataTable2QuestionChoiceList(DataTable Dt)
        {
            QuestionChoiceList examDetails = new QuestionChoiceList();
            try
            {
                for (int i = 0; i < Dt?.Rows.Count; i++)
                {
                    examDetails.Add(DataRow2QuestionChoice(Dt.Rows[i]));
                }
            }
            catch (Exception ex)
            {

            }
            return examDetails;
        }


        internal static QuestionChoice DataRow2QuestionChoice(DataRow Dr)
        {
            QuestionChoice U = new QuestionChoice();
            try
            {
                if (int.TryParse(Dr["QID"]?.ToString() ?? "-1", out int TempInt))
                    U.QID = TempInt;

                U.ChoiceNum = Dr["ChoiceNum"]?.ToString() ?? "NA";

                U.Description = Dr["Description"]?.ToString() ?? "NA";

            }
            catch (Exception ex)
            {

            }
            return U;
        }


        #endregion
    }
}
