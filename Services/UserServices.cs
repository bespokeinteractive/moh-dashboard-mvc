using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using hrhdashboard.Models;
using hrhdashboard.Extensions;
          
namespace hrhdashboard.Services
{
    public class UserServices
    {
        public Users GetUser(String username)
        {
            Users user = null;

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT usr_idnt, usr_name, usr_email, log_enabled, log_tochange, log_admin_lvl, log_access_lvl, log_password FROM Users INNER JOIN [Login] ON usr_idnt=log_user WHERE log_username='" + username +"'");
            if (dr.Read())
            {
                user = new Users
                {
                    Id = Convert.ToInt64(dr[0]),
                    Name = dr[1].ToString(),
                    Email = dr[2].ToString(),
                    Enabled = Convert.ToBoolean(dr[3]),
                    ToChange = Convert.ToBoolean(dr[4]),

                    AdminLevel = Convert.ToInt16(dr[5]),
                    AccessLevel = Convert.ToInt16(dr[6]),

                    Username = username,
                    Password = dr[7].ToString()
                };
            }

            return user;
        }

        public Roles GetRole(int idnt){
            Roles role = null;

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT rl_idnt, rl_type, rl_role FROM Roles WHERE rl_idnt=" + idnt);
            if (dr.Read())
            {
                role = new Roles
                {
                    Id = Convert.ToInt16(dr[0]),
                    Type = Convert.ToInt16(dr[1]),
                    Name = dr[2].ToString()
                };
            }

            return role;
        }

        public List<Roles> GetRoles()
        {
            List<Roles> roles = new List<Roles>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT rl_idnt, rl_type, rl_role FROM Roles");
            if (dr.HasRows){
                while (dr.Read())
                {
                    Roles role = new Roles
                    {
                        Id = Convert.ToInt16(dr[0]),
                        Type = Convert.ToInt16(dr[1]),
                        Name = dr[2].ToString()
                    };
                    
                    roles.Add(role);
                }
            }

            return roles;
        }

    }
}
