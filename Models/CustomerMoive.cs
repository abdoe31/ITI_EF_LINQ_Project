using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_LINQ_PROJECT.Models
{
    public class CustomerMoive
    {
        public int CustomerId { get; set; }
        public int  MovieId { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        
        public int ReaminDayes {
            get
            {

                if (DateTime.Now > Enddate)
                {

                    return -1;
                }
                else if (DateTime.Now < Startdate)
                {

                    return (int) (Enddate - Startdate).TotalDays;
                }

                else
                {
                    return (int)(Enddate - DateTime.Now).TotalDays;    

                }
                



                
            }
                
                
                }
        [Required]
        public Movie Movie { get; set; } 
        [Required]
        public Customer Customer { get; set; } 
    }
}
