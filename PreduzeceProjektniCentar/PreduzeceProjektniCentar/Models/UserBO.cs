using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PreduzeceProjektniCentar.Models
{
    public class UserBO
    {
        public int UserID { get; set; }
        [DisplayName("Password: ")]
        [Required(ErrorMessage ="Molim vas unesite vasu lozinku.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "Molim vas unesite vas username.")]
        public string Username { get; set; }
        [DisplayName("Confirm Password: ")]
        [Required(ErrorMessage = "Molim vas potvrdite vasu lozinku.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}