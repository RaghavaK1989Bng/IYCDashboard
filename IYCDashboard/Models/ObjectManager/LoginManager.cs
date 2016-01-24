using IYCDashboard.Models.DB;
using IYCDashboard.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IYCDashboard.Models.ObjectManager
{
    public class LoginManager
    {
        private IYCEntities dbentites = new IYCEntities();

        public string GetAdminPassword(string userLogIn)
        {
            var user = from x in dbentites.AdminLogins where x.Username == userLogIn select x;
            if (user.ToList().Count > 0)
                return PasswordEncDec.DecodeFrom64(user.First().Password);
            else
                return string.Empty;
        }
    }
}
