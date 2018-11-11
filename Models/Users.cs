using hrhdashboard.Services;
using System;
namespace hrhdashboard.Models
{
    public class Users
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public Boolean Enabled { get; set; }
        public Boolean ToChange { get; set; }
        public int AdminLevel { get; set; }
        public int AccessLevel { get; set; }
        public string Message { get; set; }
        public  Roles Role { get; set; }

        public Users()
        {
            Id = 0;
            Name = "";
            Email = "";
            Username = "";
            Password = "";
            Enabled = true;
            ToChange = false;
            AdminLevel = 0;
            AccessLevel = 0;
            Message = "";

            Role = new Roles();
        }

        public Users Save() {
            return new UserServices().SaveUsers(this);
        }

    }
}
