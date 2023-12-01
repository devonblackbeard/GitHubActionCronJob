using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Scheduled Task Logic
        Console.Write("STARTING MAIN");
        //await QueryApiAndSendEmail();

        // Other cleanup or logging tasks if needed
    }

    static async Task QueryApiAndSendEmail()
    {
        try
        {
            // Make API Request
            using (var httpClient = new HttpClient())
            {
                //var apiResponse = await httpClient.GetStringAsync("https://api.example.com/data");

                // Process API response and determine if email should be sent

                // Send Email
                await SendEmail("devon.blackbeard@gmail.com", "API Alert", "Hello devon!");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions, log errors, or send error emails
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task SendEmail(string to, string subject, string body)
    {
        using (var smtpClient = new SmtpClient("smtp.gmail.com"))
        {

            try
            {
                string oneTimeAppPasswordGoogle = "klyp rifd vbui jhsc";
                // Set your credentials if the SMTP server requires authentication
                smtpClient.Credentials = new NetworkCredential("devon.blackbeard@gmail.com", oneTimeAppPasswordGoogle);

                // Set the port number (adjust accordingly based on your SMTP server's configuration)
                smtpClient.Port = 587; // Example port, adjust based on your SMTP server's requirements

                // Enable SSL if your SMTP server requires a secure connection
                smtpClient.EnableSsl = true;               

                var mailMessage = new MailMessage("no-reply@gmail.com", to, subject, body);

                // Additional email settings if needed
                await smtpClient.SendMailAsync(mailMessage);

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
