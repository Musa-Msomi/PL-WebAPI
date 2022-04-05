using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Models
{
    public class Register
    {
        [Required]
        public string? Username { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password must contain an uppercase letter,number and special character")]
        
        public string? Password { get; set; }
    }
}
