using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace Logger 
{
    class DataBaseLogger : Logger
    {
        private readonly string _connetctionString;

        public DataBaseLogger()
        {
            _connetctionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public DataBaseLogger(string connectionString)
        {
            _connetctionString = connectionString;
        }

        protected override void Log(string msg)
        {
            string sqlCmdText = @"INSERT INTO App_Logs (Log_Msg, Log_Date)" +
                            $"VALUES (N'{msg}', {DateTime.Now.ToString(CultureInfo.InvariantCulture)}";

            using (SqlConnection connection = new SqlConnection(_connetctionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlCmdText, connection);

                try
                {
                    //sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"{msg} **LOG ON DB**");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{DateTime.Now} - EXCEPTION ON DataBaseLogger.Log: {ex.Message}");
                }

            }
        }
    }
}
