﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rehoboth.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Service { get; set; }
    }
}
