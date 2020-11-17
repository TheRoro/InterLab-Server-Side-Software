using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Resources
{
    public class SaveCompanyResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(30)]
        public string Sector { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Phone { get; set; }

        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }
}
