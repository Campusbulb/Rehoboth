using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rehoboth.Helper;
using Rehoboth.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rehoboth.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public INotyfService _notifyService;


        public ContactController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment, INotyfService notifyService)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _notifyService = notifyService;

        }


        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("send")]
        public IActionResult Send(Contact contact, IFormFile[] attachments)
        {
            var body = "Name: " + contact.Name +  "<br>Phone: " + contact.Phone + "<br>Email: " + contact.Email + "<br>Message: " + contact.Content + "<br>";
            var mailHelper = new MailHelper(_configuration);
            List<string> fileNames = null;
            if (attachments != null && attachments.Length > 0)
            {
                fileNames = new List<string>();
                foreach (IFormFile attachment in attachments)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", attachment.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        attachment.CopyToAsync(stream);
                    }
                    fileNames.Add(path);
                }
            }
            if (mailHelper.RegisterNur(contact.Email, _configuration["Gmail:Username"], contact.Subject, body, fileNames))
            {
                _notifyService.Success("Thank you for your email");
                return Redirect("~/");

            }
            else
            {
                _notifyService.Error("Error sending email, Try later");
                return Redirect("~/");
            }
        }
    }
}
