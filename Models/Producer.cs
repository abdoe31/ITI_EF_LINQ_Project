using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_LINQ_PROJECT.Models
{
    public class Producer
    {

        public int Id { get; set; }
        public string CompanyName { get; set; } = "";    
        public string Country { get; set; } = "";

        public List<Movie>? Movies { get; set; } 


     }
}
