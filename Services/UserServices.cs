using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using hrhdashboard.Models;
using hrhdashboard.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hrhdashboard.Services
{
    public class UserServices
    {
        public Users GetUser(int idnt)
        {
            Users user = null;

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT usr_idnt, usr_name, usr_email, log_username, log_enabled, log_tochange, log_admin_lvl, log_access_lvl, log_password, rl_idnt, rl_type, rl_role FROM Users INNER JOIN [Login] ON usr_idnt=log_user INNER JOIN Roles ON log_admin_lvl=rl_idnt WHERE usr_idnt=" + idnt);
            if (dr.Read())
            {
                user = new Users
                {
                    Id = Convert.ToInt64(dr[0]),
                    Name = dr[1].ToString(),
                    Email = dr[2].ToString(),
                    Username = dr[3].ToString(),
                    Enabled = Convert.ToBoolean(dr[4]),
                    ToChange = Convert.ToBoolean(dr[5]),
                    AdminLevel = Convert.ToInt16(dr[6]),
                    AccessLevel = Convert.ToInt16(dr[7]),
                    Password = dr[8].ToString()
                };

                user.Role = new Roles
                {
                    Id = Convert.ToInt16(dr[9]),
                    Type = Convert.ToInt16(dr[10]),
                    Name = dr[11].ToString()
                };
            }

            return user;
        }

        public Users GetUser(String username)
        {
            Users user = null;

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT usr_idnt, usr_name, usr_email, log_username, log_enabled, log_tochange, log_admin_lvl, log_access_lvl, log_password, rl_idnt, rl_type, rl_role FROM Users INNER JOIN [Login] ON usr_idnt=log_user INNER JOIN Roles ON log_admin_lvl=rl_idnt WHERE log_username='" + username + "'");
            if (dr.Read())
            {
                user = new Users
                {
                    Id = Convert.ToInt64(dr[0]),
                    Name = dr[1].ToString(),
                    Email = dr[2].ToString(),
                    Username = dr[3].ToString(),
                    Enabled = Convert.ToBoolean(dr[4]),
                    ToChange = Convert.ToBoolean(dr[5]),
                    AdminLevel = Convert.ToInt16(dr[6]),
                    AccessLevel = Convert.ToInt16(dr[7]),
                    Password = dr[8].ToString()
                };

                user.Role = new Roles
                {
                    Id = Convert.ToInt16(dr[9]),
                    Type = Convert.ToInt16(dr[10]),
                    Name = dr[11].ToString()
                };
            }

            return user;
        }

        public List<Users> GetUsers(){
            List<Users> users = new List<Users>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT usr_idnt, usr_name, usr_email, log_username, log_enabled, log_tochange, log_admin_lvl, log_access_lvl, rl_idnt, rl_type, rl_role FROM Users INNER JOIN [Login] ON usr_idnt=log_user INNER JOIN Roles ON log_admin_lvl=rl_idnt ORDER BY usr_idnt");
            if (dr.HasRows)
            {
                while (dr.Read()){
                    Users user = new Users
                    {
                        Id = Convert.ToInt64(dr[0]),
                        Name = dr[1].ToString(),
                        Email = dr[2].ToString(),
                        Username = dr[3].ToString(),
                        Enabled = Convert.ToBoolean(dr[4]),
                        ToChange = Convert.ToBoolean(dr[5]),
                        AdminLevel = Convert.ToInt16(dr[6]),
                        AccessLevel = Convert.ToInt16(dr[7])
                    };
                    
                    user.Role = new Roles{
                        Id = Convert.ToInt16(dr[8]),
                        Type = Convert.ToInt16(dr[9]),
                        Name = dr[10].ToString()                    
                    };
                    
                    users.Add(user);
                }
            }

            return users;
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

        public List<SelectListItem> GetRolesIEnumarable()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT rl_idnt, rl_role FROM Roles");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    SelectListItem item = new SelectListItem
                    {
                        Value = dr[0].ToString(),
                        Text = dr[1].ToString()
                    };

                    items.Add(item);
                }
            }

            return items;
        }
       
        public Users SaveUsers(Users users)
        {
            SqlServerConnection conn = new SqlServerConnection();
            users.Id = conn.SqlServerUpdate("DECLARE @username nvarchar(100)='"+users.Username+"', @email nvarchar(100)= '"+users.Email+"';  BEGIN INSERT INTO Users (usr_name, usr_email) output INSERTED.usr_idnt VALUES (@username, @email) END");
            conn.SqlServerUpdate("DECLARE @userid INT = "+users.Id+", @username nvarchar(100)= '"+users.Username + "', @password nvarchar(100) = '"+users.Password+ "', @adminlvl INT = "+users.Role.Id+ ";  BEGIN INSERT INTO Login(log_user, log_username ,log_password , log_admin_lvl ) output INSERTED.log_idnt VALUES (@userid, @username , @password , @adminlvl ) END");

            return users;
        }



    }
}
