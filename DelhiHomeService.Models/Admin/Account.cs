using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DelhiHomeService.Models.Admin
{
    public class Account
    {
        public int AdminID { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage="Enter Username")]
        public string AdminUsername { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage="Enter Password")]
        public string AdminPassword { get; set; }

        public string ErrorMessage { get; set; }
    }
}
