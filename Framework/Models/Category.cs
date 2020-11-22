using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Category
    {
        [Key]
        public int CATE_ID { get; set; }
        [MaxLength(100)]
        [Column(TypeName ="NVARCHAR")]
        public string CATE_NAME { get; set; }

        public string CATE_IMG { get; set; }

        public string CATE_DESCRIPTION { get; set; }

        public int MARK { get; set; }
    }
}
