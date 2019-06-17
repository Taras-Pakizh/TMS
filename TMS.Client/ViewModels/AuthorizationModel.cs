using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Client.Validation;

namespace TMS.Client.ViewModels
{
    class AuthorizationModel
    {
        [Required(ErrorMessage = "Login is required")]
        [MinLength(1), MaxLength(50, ErrorMessage = "Login max length is 50 symbols")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Password]
        public string password { get; set; }
    }
}
