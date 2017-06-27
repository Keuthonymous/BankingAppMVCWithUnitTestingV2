using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingAppMVCWithUnitTestingV2.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [MaxLength(140, ErrorMessage = "Name is too long, try again")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [MaxLength(140, ErrorMessage = "Name is too long, try again")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Personal Number is required")]
        [DisplayName("Person Nummer")]
        public string PersonNum { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}