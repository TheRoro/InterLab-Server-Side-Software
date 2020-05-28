using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Resources
{
    public class SaveRequestResource
    {
        [Required]
        [MaxLength(20)]
        public string State { get; set; }
        [Required]
        [MaxLength(20)]
        public DateTime CreationDate { get; set; }
    }
}
