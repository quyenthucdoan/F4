using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Menu
    {
        [Key]
        public int MENU_ID { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string MENU_NAME { get; set; }

        [Required]
        public int MENU_SIZE { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required]
        public double MENU_PRICE { get; set; }
        [Required]
        public float CALORIES { get; set; }
        [Required]
        public string MENU_IMG { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string MENU_DESCRIPTION { get; set; }

        
        public int MARK { get; set; }


        public int? CATE_ID { get; set; }

        [ForeignKey("CATE_ID")]
        public Category category { get; set; }

    }
}
