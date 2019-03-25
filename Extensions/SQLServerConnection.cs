using System;
using System.Data.SqlClient;

namespace hrhdashboard.Extensions
{
    public class SqlServerConnection
    {
        private static readonly String sConn = "Data Source=41.76.170.72;Initial Catalog=dashboard;User ID=root;Password=root-2011;Max Pool Size=200;";
        private readonly SqlConnection conn = new SqlConnection(sConn);
        private SqlCommand comm = new SqlCommand();

        public SqlDataReader SqlServerConnect(string SqlString)
        {

            try {
                conn.Open();
                comm = new SqlCommand(SqlString, conn);

                return comm.ExecuteReader();
            }
            catch (Exception){
                return null;
            }
        }

        public Int64 SqlServerUpdate(string SqlString) {
            try {
                SqlCommand command = new SqlCommand(SqlString, conn);
                command.Connection.Open();

                return Convert.ToInt64(command.ExecuteScalar());
            }
            catch (Exception){
                return 0;
            }
            finally {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
