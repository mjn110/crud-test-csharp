using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;


        [StringLength(9)]
        [RegularExpression("^([0-9])*$", ErrorMessage = "Bank account number does not have right pattern")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(18)]
        [RegularExpression("^([A-Z0-9]{4,})([A-Z]{4,})([0-9]{8,})*$", ErrorMessage = "Bank account number does not have right pattern")]
        public string BankAccountNumber { get; set; }
    }
}
