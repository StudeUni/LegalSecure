using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LegalSecure.Models
{
    public class Solicitor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LatName { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string ContactPhone { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string PostCode { get; set; }

        public List<Activity> Activities { get; set; }

    }
}
