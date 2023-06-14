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
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        public int duaration { get; set; }
            [Range(0, 10)]
        public int? rating  { get; set; }
        [ForeignKey(nameof(Producer))]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        [AllowNull]
        public List<CustomerMoive> ?customers { get; set; }
        public List<Feedback> Feedbacks { get; set; }

    }
}
