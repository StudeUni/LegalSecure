using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LegalSecure.Models
{
    public class Solicitor
    {
        [Key]
        public int ID { get; set; }
        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required, DisplayName("Birth Date"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required, DisplayName("Contact Phone"), Phone]
        public string ContactPhone { get; set; }

        [Required, DisplayName("Email Address"), EmailAddress]
        public string EmailAddress { get; set; }
        [Required, DisplayName("Street Address")]
        public string StreetAddress { get; set; }
        [Required, DisplayName("Post Code")]
        public string PostCode { get; set; }

        public List<Activity> Activities { get; set; }

    }
}
