using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Discount_Code
    {
        [Key]
        [StringLength(15)]
        [Column(TypeName = "VARCHAR")]
        public string CODE_ID { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string CODE_NAME { get; set; }
        
        public int PERCENTS { get; set; }
        
        public int MARK { get; set; }
    }
}
