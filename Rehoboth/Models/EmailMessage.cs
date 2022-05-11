using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehoboth.Models
{
    public class EmailMessage
    {
        public List<EmailAddress> ToAddresses { get; set; } = new List<EmailAddress>();
        public List<EmailAddress> FromAddresses { get; set; } = new List<EmailAddress>();
        public string Subject { get; set; }
        public string Content { get; set; }
        public IFormFile Attachment { get; set; }
        public IFormFile Photo { get; set; }
}
}
