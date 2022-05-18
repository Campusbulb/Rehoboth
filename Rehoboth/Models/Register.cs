using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rehoboth.Models
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Othername { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string YearOfExperience { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string LastWork { get; set; }

        public string CurrentLocation { get; set; }
        public string ZipCode { get; set; }
        public string PortfolioLink { get; set; }
        public IFormFileCollection UploadCV { get; set; }
        public IFormFileCollection OET { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Subject { get; set; }
        public string Website { get; set; }
    }
}
