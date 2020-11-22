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

        [Required]
        [MaxLength(100)]
        [Column(TypeName ="VARCHAR")]
        public string USERNAME { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string PASSWD { get; set; }

        public int MARK { get; set; }
    }
}
