using System;
using hrhdashboard.Models;

namespace hrhdashboard.ViewModel
{
    public class LoginModel
    {
        public Users User { get; set; }
        public String Message { get; set; }

        public LoginModel()
        {
            User = new Users();
            Message = "";
        }
    }
}
