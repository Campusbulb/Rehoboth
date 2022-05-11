using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rehoboth.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Rehoboth.Controllers
{
    public class HomeController : Controller
    {
        private EmailAddress FromAndToEmailAddress;
        private IEmailService EmailService;
        public HomeController(EmailAddress _fromAddress,
            IEmailService _emailService)
        {
            FromAndToEmailAddress = _fromAddress;
            EmailService = _emailService;
        }
    
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Messeage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Messeage(MessageModel model)
        {
           
            if (ModelState.IsValid)
            {
                
                EmailMessage msgToSend = new EmailMessage
                {

                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Here is your message: Name: {model.Name}, " +
                        $"Email: {model.Email}, Message: {model.Message}",
                    Subject = "Contact Form - BasicContactForm App"
                };

                EmailService.Send(msgToSend);
                ViewBag.Message = "Email sent.";
                //return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }
            return View("Index");
        }
      

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Registernurse()
        {
            return View();
        }

        public IActionResult Registercompany()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
