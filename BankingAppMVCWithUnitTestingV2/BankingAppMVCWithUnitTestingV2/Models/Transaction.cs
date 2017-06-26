using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingAppMVCWithUnitTestingV2.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventTime { get; set; }

        [Required]
        public EventType Type { get; set; }

        public virtual ICollection<Account> Account { get; set; }

        public enum EventType
        {
            Deposit,
            WithDrawl
        }
    }
}