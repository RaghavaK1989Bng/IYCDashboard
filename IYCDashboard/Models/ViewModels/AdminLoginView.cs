using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IYCDashboard.Models.ViewModels
{
   public class AdminLoginView
    {
        [Required(ErrorMessage ="Username is required")]
        [Display(Name = "Username")]
        [DataType(DataType.Text)]

        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
