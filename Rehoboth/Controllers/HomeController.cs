using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Rehoboth.Helper;
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
        private readonly IConfiguration _configuration;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public INotyfService _notifyService;
        public HomeController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment, INotyfService notifyService)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _notifyService = notifyService;

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
        public IActionResult Send(Contact contact)
        {
            var body = "This is a request for contact from Rehoboth website. Please find the details below from the user requesting to be contacted " +  "</br>Name: " + contact.Name + "<br>Address: " + "<br>Email: " + contact.Email + "<br>Subject of contact: " + contact.Subject + "<br>Message: " + contact.Content + "<br>";
            var mailHelper = new MailHelper2(_configuration);
            
            if (mailHelper.Send(contact.Email, _configuration["Gmail:Username"], contact.Subject, body))
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
        [HttpPost]
        public IActionResult Registercompany(RegisterCompanyModel contact)
        {
            var body = "This is a request to register as Employer from Rehoboth website. Please find the details below from the employer requesting to be Registered " 
                + "</br>Company Name: " + contact.CompanyName  
                + "<br>Email: " + contact.Email  +"<br>Phone Number: " + contact.PhoneNumber  +"<br>City: " + contact.City 
                + "<br>Country: " + contact.Country + "<br>Website: " + contact.Website + "<br>";
            var mailHelper = new MailHelper2(_configuration);

            if (mailHelper.Send(contact.Email, _configuration["Gmail:Username"], contact.Subject, body))
            {
                _notifyService.Success("We have received your application, our recruitment team will get bact to you soon");
                return Redirect("~/");

            }
            else
            {
                _notifyService.Error("Couldn't send your application, Try later");
                return Redirect("~/");
            }
        }

        [HttpPost]     
        public IActionResult RegisterNur(Register contact, IFormFile[] attachments)
        {
            var body = "This is a request to register as Nurse from Rehoboth website. Please find the details below from the employer requesting to be Registered " + "</br>First Name: " + contact.FirstName + "<br>Last Name: " + contact.LastName + "<br>Other Name: "
                + contact.Othername +"<br>Email: " + contact.Email + "<br>Phone Number: " + contact.PhoneNumber + "<br>Year of Experience: " 
                + contact.YearOfExperience + "<br>City: " + contact.City + "<br>Country: " + contact.Country + "<br>Qualification: " + 
                contact.Qualification + "<br>Last worked: " + contact.LastWork + "<br>Current Location: " + contact.CurrentLocation + "<br>";
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
                _notifyService.Success("We have received your application, our recruitment team will get bact to you soon");
                return RedirectToAction("Index");

            }
            else
            {
                _notifyService.Error("Couldn't send your application, Try later");
                return Redirect("~/");
            }
        }

        [HttpPost]
        public IActionResult RegisterSocWorker(Register contact, IFormFile[] attachments)
        {
            var body = "This is a request to register as Social Worker from Rehoboth website. Please find the details below from the employer requesting to be Registered " + "</br>First Name: " + contact.FirstName + "<br>Last Name: " + contact.LastName + "<br>Other Name: "
                + contact.Othername + "<br>Email: " + contact.Email + "<br>Phone Number: " + contact.PhoneNumber + "<br>Year of Experience: "
                + contact.YearOfExperience + "<br>City: " + contact.City + "<br>Country: " + contact.Country + "<br>Qualification: " +
                contact.Qualification + "<br>Last worked: " + contact.LastWork + "<br>Current Location: " + contact.CurrentLocation + "<br>";
            var mailHelper = new MailHelper3(_configuration);
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
                _notifyService.Success("We have received your application, our recruitment team will get bact to you soon");
                return RedirectToAction("Index");

            }
            else
            {
                _notifyService.Error("Couldn't send your application, Try later");
                return Redirect("~/");
            }
        }

        [HttpPost]
        public IActionResult RegisterVol(Register contact, IFormFile[] attachments)
        {
            var body = "This is a request to register as Volunteer Worker from Rehoboth website. Please find the details below from the employer requesting to be Registered " + "</br>First Name: " + contact.FirstName + "<br>Last Name: " + contact.LastName + "<br>Other Name: "
                + contact.Othername + "<br>Email: " + contact.Email + "<br>Phone Number: " + contact.PhoneNumber + "<br>Year of Experience: "
                + contact.YearOfExperience + "<br>City: " + contact.City + "<br>Country: " + contact.Country + "<br>Qualification: " +
                contact.Qualification + "<br>Last worked: " + contact.LastWork + "<br>Current Location: " + contact.CurrentLocation + "<br>";
            var mailHelper = new MailHelper4(_configuration);
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
                _notifyService.Success("We have received your application, our recruitment team will get bact to you soon");
                return RedirectToAction("Index");

            }
            else
            {
                _notifyService.Error("Couldn't send your application, Try later");
                return Redirect("~/");
            }
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
