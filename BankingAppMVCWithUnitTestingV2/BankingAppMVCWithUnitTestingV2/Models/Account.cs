using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankingAppMVCWithUnitTestingV2.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Account Type is required")]
        [DisplayName("Account Type")]
        public AccountType Type { get; set; }

        [DataType(DataType.Currency)]
        public double? Balance { get; set; }

        [Required]
        [ForeignKey("Person")]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<Transaction> TransHistory { get; set; }

        public enum AccountType
        {
            Savings,
            Checking,
            Credit
        }
    }
}