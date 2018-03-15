using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net.Mail;
using System.Net;
using Microsoft.Office.Interop.Outlook;
using OutlookApp = Microsoft.Office.Interop.Outlook.Application;
using System.Configuration;
using System.IO;

namespace Appraisal_Email_Automation
{
    public class Outlook_Wtapper
    {
        bool send = false;
        string from;
        string cc;
        string[] CC_Adds;
        StringBuilder emailBody = new StringBuilder();
        string bodyfile;
        string subject;
        OutlookApp oApp;
        public Outlook_Wtapper()
        {
            try
            {
                send = Convert.ToBoolean(ConfigurationSettings.AppSettings["Email_Send_Flag"]);
                from = ConfigurationSettings.AppSettings["Email_From"];
                cc = ConfigurationSettings.AppSettings["Email_CC"];
                subject = ConfigurationSettings.AppSettings["Email_Subject"];
                bodyfile = ConfigurationSettings.AppSettings["Email_Body_File"];

                // Create the Outlook application.
                oApp = new OutlookApp();

                if (string.IsNullOrEmpty(from))
                {
                    Console.WriteLine("From email address not configured.");
                    throw new System.Exception("From address for Email not configured");
                }

                if (!string.IsNullOrEmpty(cc))
                {
                    CC_Adds = cc.Split(new char[] { ';' });
                }

                RefreshEmailBody();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        /// <summary>
        /// Method to refresh email body  contents
        /// </summary>
        public void RefreshEmailBody()
        {
            try
            {
                emailBody.Clear();
                if (!string.IsNullOrEmpty(bodyfile))
                {
                    if (File.Exists(bodyfile))
                    {
                        using (TextReader tr = new StreamReader(bodyfile, Encoding.UTF8))
                        {
                            emailBody.Append(tr.ReadToEnd());
                        }
                    }
                }
            }
            catch(System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        /// <summary>
        /// Method to send email to outlook
        /// </summary>
        public void SendEMail(string to, string name, string attachment)
        {
            try
            {
                // Create a new mail item.
                MailItem oMsg = (MailItem)oApp.CreateItem(OlItemType.olMailItem);
                // Set HTMLBody. 
                //add the body of the email
                RefreshEmailBody();
                emailBody.Replace("{Name}",name);
                oMsg.HTMLBody = emailBody.ToString();
                oMsg.HTMLBody += ReadSignature();
                //Add an attachment.
                String sDisplayName = "Appraisal Letter";
                int iPosition = (int)oMsg.Body.Length + 1;
                int iAttachType = (int)OlAttachmentType.olByValue;
                //now attached the file
                Microsoft.Office.Interop.Outlook.Attachment oAttach = oMsg.Attachments.Add(attachment, iAttachType, iPosition, sDisplayName);
                //Subject line
                oMsg.Subject = subject;
                // Add a recipient.
                Recipients oRecips = (Recipients)oMsg.Recipients;
                // Change the recipient in the next line if necessary.
                Recipient oRecip = (Recipient)oRecips.Add(to);
                oMsg.CC = this.cc;
                oRecip.Resolve();
                // Send.
                oMsg.Send();
                // Clean up.
                oRecip = null;
                oRecips = null;
                oMsg = null;
                //oApp = null;
            }//end of try block
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//end of catch
        }//end of Email Method

        private string ReadSignature()
        {
            try
            {
                string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
                string signature = string.Empty;
                DirectoryInfo diInfo = new DirectoryInfo(appDataDir);

                if (diInfo.Exists)
                {
                    FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

                    if (fiSignature.Length > 0)
                    {
                        StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                        signature = sr.ReadToEnd();

                        if (!string.IsNullOrEmpty(signature))
                        {
                            string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                            signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                        }
                    }
                }
                return signature;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

            
        }
    }
}
