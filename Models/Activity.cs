using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegalSecure.Models
{
    public class Activity
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }

        [Required, DisplayName("Date"), DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal? HoursSpent { get; set; }

        public int CaseID { get; set; }
        public Case Case { get; set; }

        public int SolicitorID { get; set; }

        public Solicitor Solicitor { get; set; }

        public int RateID { get; set; }

        public Rate Rate { get; set; }



    }
}
