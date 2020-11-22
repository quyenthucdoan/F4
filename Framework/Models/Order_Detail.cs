using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Order_Detail
    {
        [Key,Column(Order = 0)]
        public int? ORDER_ID { get; set; }
        [ForeignKey("ORDER_ID")]
        public Orders Order { get; set; }

        [Key, Column(Order = 1)]
        public int? MENU_ID { get; set; }
        [ForeignKey("MENU_ID")]
        public Menu Menu { get; set; }

        [Required]
        public int AMOUNT { get; set; }

        
        public string CODE_ID { get; set; }

        [ForeignKey("CODE_ID")]
        public Discount_Code Discount { get; set; }

        public int MARK { get; set; }
    }
}
