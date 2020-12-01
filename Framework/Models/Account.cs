using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Account
    {
        [Key]
        public int ADMIN_ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username required")]
        [EmailAddress]
        
        public string USERNAME { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Password required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PASSWD { get; set; }


        /*[Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }*/
       /* public int MARK { get; set; }*/
    }
}
