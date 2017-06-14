using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViralityTest.DataModels
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Roles { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
