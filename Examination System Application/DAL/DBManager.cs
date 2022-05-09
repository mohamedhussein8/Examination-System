using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBManager : IDisposable
    {
        SqlConnection sqlCn;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;
        DataTable DT;


        public DBManager()
        {
            try
            {
                sqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExaminationSystemCN"].ConnectionString);
                sqlCmd = new SqlCommand("", sqlCn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlDA = new SqlDataAdapter(sqlCmd);
                DT = new DataTable();

            }
            catch (Exception ex)
            {
                //Log Exception
            }
        }

        public int ExecuteNonQuery(string SPName)
        {
            int R = -1;
            try
            {
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                if (sqlCn.State == ConnectionState.Closed)
                    sqlCn.Open();

                R = sqlCmd.ExecuteNonQuery();

                sqlCn.Close();
            }
            catch (Exception ex)
            {

            }
            return R;
        }

        public int ExecuteNonQuery(string SPName, Dictionary<string, object> Parms)
        {
            int R = -1;
            try
            {
                sqlCmd.Parameters.Clear();

                foreach (var item in Parms)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                if (sqlCn.State == ConnectionState.Closed)
                    sqlCn.Open();

                R = sqlCmd.ExecuteNonQuery();

                sqlCn.Close();
            }
            catch (Exception ex)
            {

            }
            return R;
        }


        public int ExecuteNonQueryWithOutParm(string SPName, Dictionary<string, object> Parms)
        {
            int R = -1;
            try
            {

                sqlCmd.Parameters.Clear();

                foreach (var item in Parms)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                var returnParameter = sqlCmd.Parameters.Add("@outParam", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;

                sqlCmd.CommandText = SPName;

                if (sqlCn.State == ConnectionState.Closed)
                    sqlCn.Open();

                sqlCmd.ExecuteNonQuery();
                var result = returnParameter.Value;
                sqlCn.Close();
               
                return Convert.ToInt32(result);



            }
            catch (Exception ex)
            {

            }
            return 0;
        }




        public object ExecuteScaler(string SPName)
        {
            object R = new object();
            try
            {
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                if (sqlCn.State == ConnectionState.Closed)
                    sqlCn.Open();

                R = sqlCmd.ExecuteScalar();

                sqlCn.Close();
            }
            catch (Exception ex)
            {

            }
            return R;
        }

        public object ExecuteScaler(string SPName, Dictionary<string, object> Parms)
        {
            object R = new object();
            try
            {
                sqlCmd.Parameters.Clear();

                foreach (var item in Parms)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                if (sqlCn.State == ConnectionState.Closed)
                    sqlCn.Open();

                R = sqlCmd.ExecuteScalar();

                sqlCn.Close();
            }
            catch (Exception ex)
            {

            }
            return R;
        }

        public DataTable ExecuteDataTable(string SPName)
        {
            try
            {
                DT.Clear();
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                sqlDA.Fill(DT);
                return DT;
            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }

        public DataTable ExecuteDataTable(string SPName, Dictionary<string, object> Parms)
        {
            try
            {
                DT.Clear();
                sqlCmd.Parameters.Clear();

                foreach (var item in Parms)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                sqlDA.Fill(DT);
                return DT;

            }
            catch (Exception ex)
            {

            }
            return new DataTable();
        }




        public void Dispose()
        {
            try
            {
                sqlCn?.Dispose();
            }
            catch
            {

            }
        }



    }
}
