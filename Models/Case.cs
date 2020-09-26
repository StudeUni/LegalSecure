using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegalSecure.Models
{
    public class Case
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
