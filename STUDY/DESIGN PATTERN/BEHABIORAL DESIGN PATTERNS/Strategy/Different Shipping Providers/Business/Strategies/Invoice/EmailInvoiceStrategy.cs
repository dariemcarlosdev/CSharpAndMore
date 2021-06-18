using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.Invoice
{
    //Send a simple email with our text representation of an invoice.
    public class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var body = GenerateTextInvoice(order);
            using (SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
            {
                //Logic to send email using Sendgrid API.

                NetworkCredential credentials = new NetworkCredential("darneder", "", "");
                client.Credentials = credentials;

                MailMessage mail = new MailMessage("softevolutionsl@dariem.dev", "softevolutionsl@gmail.com", "dasdadasd.", "dasdadasd.")
                {
                    Body = body,
                    Subject = "dasdadasd"

                };

                client.Send(mail);
                
            }
            
        }
    }
}
