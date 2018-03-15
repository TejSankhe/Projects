using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;

namespace Appraisal_Email_Automation
{
    public class SendEmail
    {
        bool send = false;
        string from;
        string cc;
        string[] CC_Adds;
        SmtpClient smtpClient = new SmtpClient();
        StringBuilder emailBody = new StringBuilder();

        public SendEmail()
        {
            try
            {
                send = Convert.ToBoolean(ConfigurationSettings.AppSettings["Email_Send_Flag"]);
                from = ConfigurationSettings.AppSettings["Email_From"];
                cc = ConfigurationSettings.AppSettings["Email_CC"];

                if (string.IsNullOrEmpty(from))
                {
                    Console.WriteLine("From email address not configured.");
                    throw new Exception("From address for Email not configured");
                }

                if (!string.IsNullOrEmpty(cc))
                {
                    CC_Adds = cc.Split(new char[] { ';' });
                }

                smtpClient = new SmtpClient();
                smtpClient.Host = ConfigurationSettings.AppSettings["SMTP_Server"];
                smtpClient.Timeout = 60 * 1000;


                if (send)
                {
                    //Console.WriteLine("Please enter your User name:");
                    //string userName = Console.ReadLine();
                    //Console.WriteLine("Please enter your Password:");

                    //SecureString pwdString = Secure_String.ReadSecureString();
                    //NetworkCredential basicCred = new System.Net.NetworkCredential(userName, pwdString);
                    //smtpClient.Credentials = basicCred;

                    smtpClient.UseDefaultCredentials = false;
                }
                else
                {
                    smtpClient.UseDefaultCredentials = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void Send(string to, string cc, string file, string emailType)
        {
            try
            {
                if (send)
                {
                    MailMessage mailMsg = new MailMessage(from, to);
                    if (!string.IsNullOrEmpty(cc))
                    {
                        mailMsg.CC.Add(cc);
                    }

                    if (CC_Adds.Length > 0)
                    {
                        foreach (string ccAdd in CC_Adds)
                        {
                            mailMsg.CC.Add(ccAdd);
                        }
                    }
                    Attachment attachment = new Attachment(file);
                    mailMsg.Attachments.Add(attachment);
                    mailMsg.Subject = "Add Subject";
                    mailMsg.Body = "Test";

                    smtpClient.Send(mailMsg);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }
}
