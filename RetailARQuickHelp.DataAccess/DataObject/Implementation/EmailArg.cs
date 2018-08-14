using System.Net.Mail;

namespace RetailARQuickHelp.DataAccess.DataObject.Implementation
{
    public class EmailArg
    {
        public EmailArg()
        {

        }
        public EmailArg(string from, string tos, string body, string subject, string host, bool useDefaultCredentials, SmtpDeliveryMethod deliveryMethod, int port)
        {
            From = from;
            Tos = tos;
            Body = body;
            Subject = subject;
            Host = host;
            UseDefaultCredentials = useDefaultCredentials;
            DeliveryMethod = deliveryMethod;
            Port = port;
        }

        public string From { get; set; }
        public string Tos { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Host { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public SmtpDeliveryMethod DeliveryMethod { get; set; }
        public int Port { get; set; }
    }
}
