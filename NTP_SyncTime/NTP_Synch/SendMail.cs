using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NTP_Synch
{
    class SendMail
    {
        public async Task SendMailAuto(int hour, double min)
        {
            Console.WriteLine("Start send mail.");
            string hostMail = ConfigurationManager.AppSettings.Get("hostMail");
            string passEmail = ConfigurationManager.AppSettings.Get("passMail"); 
            string destEmail = ConfigurationManager.AppSettings.Get("destMail");
            try
            {
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("192.168.8.4");
                smtpClient.EnableSsl = false;

                smtpClient.Credentials = new System.Net.NetworkCredential(hostMail, passEmail);

                System.Net.Mail.MailMessage mailMsg = new System.Net.Mail.MailMessage();

                mailMsg.To.Add(destEmail);
                mailMsg.From = new System.Net.Mail.MailAddress(hostMail, hostMail);

                mailMsg.Subject = "CẢNH BÁO LỆCH THỜI GIAN VỚI SERVER NTP";

                string content = "Thời gian chênh lệch: " + hour + " giờ " + Math.Round(min) + " phút.";

                //mailMsg.Body = content;
                mailMsg.IsBodyHtml = true;
                mailMsg.Body = content;
                mailMsg.BodyEncoding = Encoding.Default;
                mailMsg.Priority = MailPriority.High;
                await smtpClient.SendMailAsync(mailMsg);
                Console.WriteLine("Send mail success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi gửi mail: " + ex);
                Console.Read();
            }
        }
    }
}
