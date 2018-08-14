using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using RetailARQuickHelp.DataAccess.DataObject.Implementation;
using RetailARQuickHelp.DataAccess.Repository.Implementation;

namespace RetailARQuickHelp.WebApi.Controllers
{
    public class EmailNotificationController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage SendAspenTicket(string from, string message)
        {
            var json = string.Empty;
            try
            {
                var to = new AppSettingsRepository().GetByKey("HELPDESK_EMAIL").Value; //ConfigurationManager.AppSettings.Get("email_to");
                var subject = new AppSettingsRepository().GetByKey("HELPDESK_EMAIL_SUBJ").Value;//ConfigurationManager.AppSettings.Get("email_subject");

                var smtp = new SmtpClient();
                var arguments = new EmailArg
                {
                    From = from,
                    Tos = string.Join(",", to, from),
                    Subject = subject,
                    Body = message,
                    Host = smtp.Host,
                    EnableSsl = smtp.EnableSsl,
                    Port = smtp.Port,
                    DeliveryMethod = smtp.DeliveryMethod
                };

                SendEmail(arguments);
                json = JsonConvert.SerializeObject(arguments);
            }
            catch (Exception ex)
            {
                json = "{'result': 0, 'error':'" + ex.Message + "'}";
            }

            return new HttpResponseMessage {Content = new StringContent(json, Encoding.UTF8, "application/json")};
        }

        private void SendEmail(EmailArg emailArg)
        {
            string[] recievers = emailArg.Tos.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailArg.From),
                //CC = new MailAddress(emailArg.From),
                IsBodyHtml = true,
                Body = emailArg.Body,
                Subject = emailArg.Subject
            };

            foreach (var to in recievers)
                mailMessage.To.Add(new MailAddress(to));

            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.HeadersEncoding = Encoding.UTF8;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Host = emailArg.Host;
                smtpClient.DeliveryMethod = emailArg.DeliveryMethod;
                smtpClient.Port = emailArg.Port;
                smtpClient.EnableSsl = emailArg.EnableSsl;

                smtpClient.Send(mailMessage);
            }
        }
    }
}
