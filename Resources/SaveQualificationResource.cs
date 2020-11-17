using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Resources
{
    public class SaveQualificationResource
    {
        [Required]
        [MaxLength(50)]
        public string Comment { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        [MaxLength(8)]
        public string Author { get; set; }
    }
}
