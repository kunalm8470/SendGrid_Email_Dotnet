using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace SendGridEmailTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task Execute()
        {
            // Prepping metadata from environment variables
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_EMAIL_API_KEY", EnvironmentVariableTarget.Process);
            string fromEmail = Environment.GetEnvironmentVariable("FROM_EMAIL", EnvironmentVariableTarget.Process);
            string fromEmailFriendlyName = Environment.GetEnvironmentVariable("FROM_EMAIL_FRIENDLY_NAME", EnvironmentVariableTarget.Process);
            string toEmail = Environment.GetEnvironmentVariable("TO_EMAIL", EnvironmentVariableTarget.Process);
            string toEmailFriendlyName = Environment.GetEnvironmentVariable("TO_EMAIL_FRIENDLY_NAME", EnvironmentVariableTarget.Process);

            SendGridClient client = new(apiKey);
            EmailAddress from = new(fromEmail, fromEmailFriendlyName);
            EmailAddress to = new(toEmail, toEmailFriendlyName);

            string subject = "Send Grid Email Test";
            string plainTextContent = $"{GetGreeter()} {toEmailFriendlyName}!!!";
            string htmlContent = $"<strong>{GetGreeter()} {toEmailFriendlyName}!!!</strong>";
            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            Response response = await client.SendEmailAsync(msg);
            Console.WriteLine("Email sent!");
        }

        static string GetGreeter()
        {
            string greeting = "Welcome";
            int hour = DateTime.Now.Hour;

            if (hour < 12)
                greeting = "Good morning";
            else if (hour >= 12 && hour <= 17)
                greeting = "Good afternoon";
            else if (hour >= 17 && hour < 21)
                greeting = "Good evening";
            else if (hour >= 21 && hour <= 23)
                greeting = "Good night";

            return greeting;
        }
    }
}
