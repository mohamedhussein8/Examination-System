using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager
    {

        static DBManager dBmanager = new DBManager();

        public static int addNewTopic( int cId,string topic)
        {
            int r = 0;
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@Cid"] = cId;
            map["@tName"] = topic;
            r = dBmanager.ExecuteNonQuery("addNewTopic", map);
            return r;
        }


        public static int Insert_Student_EXAM_Course(int sId,int eId,int cId)
        {
            int r = 0;
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@S_ID"] = sId;
            map["@E_ID"] = eId;
            map["@C_ID"] = cId;
            r = dBmanager.ExecuteNonQuery("Insert_Student_EXAM_Course", map);
            return r;
        }

        public static int Insert_Question(string _qDesc, string _qType, string _modelAnswer, int cId)
        {
            int r = 0;
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@Q_Desc"] = _qDesc;
            map["@Q_Type"] = _qType;
            map["@Q_Model_Answer"] = _modelAnswer;
            map["@CR_ID"] = cId;
            r = dBmanager.ExecuteNonQueryWithOutParm("Insert_Question", map);
            return r;
        }

        public static int Insert_Question_Choices(int _qID, string _choiceNum, string _choiceDesc)
        {
            int r = 0;
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@Q_ID"] = _qID;
            map["@Choice_Num"] = _choiceNum;
            map["@Desc"] = _choiceDesc;
            r = dBmanager.ExecuteNonQuery("Insert_Choices", map);
            return r;
        }

        public static UserList SelectAllUsers()
        {
            try
            {
                return DataTable2UserList(
                dBmanager.ExecuteDataTable("Select_User_All"));
            }
            catch (Exception ex)
            {

            }
            return new UserList();
        }

        public static DataTable SelectAllUsers2()
        {
            try
            {
                return dBmanager.ExecuteDataTable("Select_User_All");
            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }






        public static DataTable getExamQuestions(int eId)
        {
            try
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@Eid"] = eId;
                return dBmanager.ExecuteDataTable("getExamQuestions", map);

            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }


        public static DataTable selectCourseStudents(int cId)
        {
            try
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@cid"] = cId;
                return dBmanager.ExecuteDataTable("selectCourseStudents", map);

            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }


        public static DataTable selectInsCourse(int insId)
        {
            try
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@insId"] = insId;
                return dBmanager.ExecuteDataTable("selectInsCourse", map);

            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }

     

        public static int generate_Exam(int cId)
        {
            int r = 0;
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@cId"] = cId;
            map["@numOfTrueFalse"] = 3;
            map["@numOfMCQ"] = 7;
            r = dBmanager.ExecuteNonQueryWithOutParm("generate_Exam", map);
            return r;
        }


        public static DataTable getDepratmentStudents(int id)
        {
            try
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@id"] = id;
                return dBmanager.ExecuteDataTable("getDepratmentStudents", map);
               
            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }


        public static DataTable getSutdentgrades(int id)
        {
            try
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@stuId"] = id;
                return dBmanager.ExecuteDataTable("getSutdentgrades", map);

            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }

        public static DataTable CourseTopics(int id)
        {
            try
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@cid"] = id;
                return dBmanager.ExecuteDataTable("CourseTopics", map);

            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }

        public static DataTable studentAnswers(int eid,int sid)
        {
            try
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@examID"] = eid;
                map["@studentID"] = sid;
                return dBmanager.ExecuteDataTable("studentAnswers", map);

            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }

        public static DataTable NCourse_NumStud(int id)
        {
            try
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map["@InstID"] = id;
                return dBmanager.ExecuteDataTable("NCourse_NumStud", map);

            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }



        #region Mapping

        internal static UserList DataTable2UserList(DataTable Dt)
        {
            UserList userList = new UserList();
            try
            {
                for (int i = 0; i < Dt?.Rows.Count; i++)
                {
                    userList.Add(DataRow2User(Dt.Rows[i]));
                }
            }
            catch (Exception ex)
            {

            }
            return userList;
        }


        internal static User DataRow2User(DataRow Dr)
        {
            User U = new User();
            try
            {
                if (int.TryParse(Dr["UID"]?.ToString() ?? "-1", out int TempInt))
                    U.UID = TempInt;

                U.userName = Dr["userName"]?.ToString() ?? "NA";

                U.password = Dr["password"]?.ToString() ?? "NA";

                U.Fname = Dr["Fname"]?.ToString() ?? "NA";

                U.Lname = Dr["Lname"]?.ToString() ?? "NA";

                U.address = Dr["address"]?.ToString() ?? "NA";

                if (DateTime.TryParse(Dr["Date_Birth"]?.ToString() ?? "-1", out DateTime TempDateBirth))
                    U.Date_Birth = TempDateBirth;

                U.User_Type = Dr["User_Type"]?.ToString() ?? "NA";
            }
            catch (Exception ex)
            {

            }
            return U;
        }


        #endregion
    }
}
