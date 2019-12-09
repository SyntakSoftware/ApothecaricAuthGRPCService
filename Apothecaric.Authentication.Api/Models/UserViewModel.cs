using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apothecaric.Authentication.Api.Models
{
    public class UserViewModel
    {
        [Required]
        public string AuthToken { get; set; }
        [Required]
        public string RefreshToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
