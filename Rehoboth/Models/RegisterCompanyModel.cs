using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rehoboth.Models
{
    public class RegisterCompanyModel
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string CurrentLocation { get; set; }
        public string ZipCode { get; set; }
        public string Website { get; set; }
    }
}
