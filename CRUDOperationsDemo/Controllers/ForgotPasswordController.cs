using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using CRUDOperationsDemo;
using System.Net.Http;
using System.Net.Mail;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace School.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;

        public ForgotPasswordController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(string email)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("office@reenasby.org", "office@reenasby.org"),
                Subject = "Forgot password from office@reenaby.org",
                PlainTextContent = "and easy to do anywhere, especially with C#"
            };

            msg.AddTo(new EmailAddress(email, email));
            var response = await client.SendEmailAsync(msg);

            // A success status code means SendGrid received the email request and will process it.
            // Errors can still occur when SendGrid tries to send the email. 
            // If email is not received, use this URL to debug: https://app.sendgrid.com/email_activity 
            Console.WriteLine(response.IsSuccessStatusCode ? "Email queued successfully!" : "Something went wrong!");
            return View("Index");
        }
    }
}
