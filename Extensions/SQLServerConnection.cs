using System;
using System.Data.SqlClient;

namespace hrhdashboard.Extensions
{
    public class SqlServerConnection
    {
        private static String sConn = "Data Source=localhost; Initial Catalog=hrh;User ID=davie;Password=michael844;Max Pool Size=200;";
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

        public Int64 SqlServerUpdate(string SqlString)
        {
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
