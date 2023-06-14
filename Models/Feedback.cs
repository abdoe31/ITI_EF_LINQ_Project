using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_LINQ_PROJECT.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Descrition { get; set; }
        public int movieid { get; set; }
        public Movie Movie { get; set; }    
    }
}
