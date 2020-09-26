using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegalSecure.Models
{
    public class Rate
    {
        [Key]
        public int ID { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime RateStart { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime RateEnd { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public Decimal RateAnHour { get; set; }
        public Activity Activities { get; set; }
    }
}
