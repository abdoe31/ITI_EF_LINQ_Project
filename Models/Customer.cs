using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_LINQ_PROJECT.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = "";
        [Required]

        public string LastName { get; set; } = "";
        public string? Address { get; set; } = "";
        [AllowNull]
        public string? PhoneNumber { get; set; }
        [AllowNull]

        public List<CustomerMoive> Moives { get; set; }

        public override string ToString()
        {
            return $" name : {FirstName}:{LastName}:   adress:  {Address}:  number :{PhoneNumber}";
        }
    }
}
