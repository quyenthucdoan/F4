using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Orders
    {
        [Key]
        public int ORDER_ID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public int ORDER_DATE { get; set; }

        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(10)] // sets the maximum length isn't be entered more than 10 characters
        public string PHONE { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(10)]
        public string ADDRESS { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string EMAIL { get; set; }

        
        public int PAYMENT_TYPE { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public int TOTAL_PRICE { get; set; }
        
        public int RECEIVED { get; set; }


        public int DELIVERED { get; set; }

    }
}
