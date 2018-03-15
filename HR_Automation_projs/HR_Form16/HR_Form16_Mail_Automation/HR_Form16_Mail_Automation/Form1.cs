using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using System.IO;

namespace HR_Form16_Mail_Automation
{
   public partial class form16mailautomation : Form
   {
      public form16mailautomation()
      {
         InitializeComponent();
         errorsValue.Visible = false;
         generate_emails.Enabled = false;
         Error.Visible = false;
         EmailSent.Visible = false;
         emailsentcounter.Visible = false;
         FormBorderStyle = FormBorderStyle.FixedSingle;
      }

      private void generate_emails_Click(object sender, EventArgs e)
      {
         EmailSent.Value = 0;
         int val = 0;
         string error = "";
         string Email_id = "";
         string File_name = "";
         string Employee_name = "";
         String Email_idCC = "";
         String Email_idBCC = "";
         string signature = "";
         StringBuilder emailBody = new StringBuilder();

         string directory_Form16PDF = pdffolderpathvalue.Text;
         string Eployee_Details = excelfilepathvalue.Text;
         emailsentcounter.Visible = true;
         EmailSent.Visible = true;

         Excel.Application xlApp = new Excel.Application();
         Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@Eployee_Details);
         Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
         Excel.Range range = range = xlWorkSheet.UsedRange;

         int rw = range.Rows.Count;
         int cl = range.Columns.Count;
         Outlook.Application oApp;
         Outlook.MailItem oMsg;
         Outlook.Attachment oAttach;
         Outlook.Recipients oRecips;
         Outlook.Recipient oRecip;
         Outlook.Recipient recipTo = null;
         Outlook.Recipient recipCc = null;
         Outlook.Recipient recipBcc = null;
         EmailSent.Minimum = 0;
         EmailSent.Maximum = rw - 1;
         createlogfile();
         for (int rCnt = 2; rCnt <= rw; rCnt++)
         {
            Email_id = (string)(range.Cells[rCnt, 3] as Excel.Range).Value2;
            File_name = (string)(range.Cells[rCnt, 4] as Excel.Range).Value2;
            Employee_name= (string)(range.Cells[rCnt, 2] as Excel.Range).Value2;
            Email_idCC = (string)(range.Cells[rCnt, 5] as Excel.Range).Value2;
            Email_idBCC = (string)(range.Cells[rCnt, 6] as Excel.Range).Value2;
            EmailSent.Value++;
            // Create the Outlook application.
            try
            {
               oApp = new Outlook.Application();
               // Create a new mail item.
               oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
               // Set HTMLBody. 
               //add the body of the email
               emailBody =  reademailtext();
               emailBody.Replace("{Name}", Employee_name);
               signature = ReadSignature();
               oMsg.HTMLBody = emailBody.ToString() + " " + signature;
               //Add an attachment.
               String filepath = @directory_Form16PDF + "\\" + File_name;
               oAttach = oMsg.Attachments.Add(filepath);
               //Subject line
               oMsg.Subject = emailsubjectvalue.Text;
               // Add a recipient For To.
               if (!string.IsNullOrEmpty(Email_id))
               {
                  String[] EmailidTos = Email_id.Split(',');

                  foreach (String EmailidTo in EmailidTos)
                  {
                     recipTo = oMsg.Recipients.Add(EmailidTo);
                     recipTo.Type = (int)Outlook.OlMailRecipientType.olTo;
                     recipTo.Resolve();
                  }
               }
               if (!string.IsNullOrEmpty(Email_idCC))
               {
                  String[] EmailidCCs = Email_idCC.Split(',');

                  foreach (String EmailidCC in EmailidCCs)
                  {
                     recipCc = oMsg.Recipients.Add(EmailidCC);
                     recipCc.Type = (int)Outlook.OlMailRecipientType.olCC;
                     recipCc.Resolve();
                  }
               }
               if (!string.IsNullOrEmpty(Email_idBCC))
               {
                  String[] EmailidBCCs = Email_idBCC.Split(',');

                  foreach (String EmailidBCC in EmailidBCCs)
                  {
                     recipBcc = oMsg.Recipients.Add(EmailidBCC);
                     recipBcc.Type = (int)Outlook.OlMailRecipientType.olBCC;
                     recipBcc.Resolve();
                  }
               }
               if (recipTo.Resolved || recipCc.Resolved || recipBcc.Resolved)
               {
                  // Send.
                  oMsg.Send();
                  val++;
                  emailsentcounter.Text = val + "/" + (rw - 1) + " Emails Sent";
               }
            }
            catch (Exception exp)
            {
               error += DateTime.Now.ToString()+" " + Employee_name +": "+ exp.Message +"\n";
               Error.Visible = true;
               errorsValue.Visible = true;
               errorsValue.Text = error;
            }

            
         }
         generatelogfile(error);
         // Clean up.
         oRecip = null;
         oRecips = null;
         oMsg = null;
         oApp = null;
         xlWorkBook.Close(true, null, null);
         xlApp.Quit();
         Marshal.ReleaseComObject(xlWorkSheet);
         Marshal.ReleaseComObject(xlWorkBook);
         Marshal.ReleaseComObject(xlApp);
         Console.ReadLine();

      }

      private void createlogfile()
      {
         string fileName = AppDomain.CurrentDomain.BaseDirectory +"log.txt";
         try
         {
            // Check if file already exists. If yes, delete it. 
            if (File.Exists(@fileName))
            {
               File.Delete(@fileName);
            }
            FileStream fs = File.Create(@fileName);
            fs.Close();
         }
         catch (Exception Ex)
         {
            Console.WriteLine(Ex.ToString());
         }

      }

      private void generatelogfile(string error)
      {
         string fileName = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
         try
         {
            using (System.IO.StreamWriter file =
              new System.IO.StreamWriter(@fileName))
            {
               file.WriteLine(error);
               file.Close();
            }
         }
         catch(Exception e)
         {

         }
      }
   

      private StringBuilder reademailtext()
      {
         //emailbodytext.Clear();
         StringBuilder emailbodytext = new StringBuilder();
         String line;
         // Read the file and display it line by line.
         System.IO.StreamReader file =
            new System.IO.StreamReader(@emailtemplatepath.Text);
         while ((line = file.ReadLine()) != null)
         {
            emailbodytext.Append(line);
         }
         file.Close();
         return emailbodytext;
      }

      private void excelfilepathvalue_TextChanged(object sender, EventArgs e)
      {
         emailsentcounter.Visible = false;
         EmailSent.Visible = false;
         Error.Visible = false;
         errorsValue.Visible = false;
         generate_emails.Enabled = false;
         if (!string.IsNullOrEmpty(pdffolderpathvalue.Text) && !string.IsNullOrEmpty(excelfilepathvalue.Text) && !string.IsNullOrEmpty(emailtemplatepath.Text) && !string.IsNullOrEmpty(emailsubjectvalue.Text))
         {
            generate_emails.Enabled = true;
         }
      }

      private void pdffolderpathvalue_TextChanged(object sender, EventArgs e)
      {
         emailsentcounter.Visible = false;
         EmailSent.Visible = false;
         Error.Visible = false;
         errorsValue.Visible = false;
         generate_emails.Enabled = false;
         if (!string.IsNullOrEmpty(pdffolderpathvalue.Text) && !string.IsNullOrEmpty(excelfilepathvalue.Text) && !string.IsNullOrEmpty(emailtemplatepath.Text) && !string.IsNullOrEmpty(emailsubjectvalue.Text))
         {
            generate_emails.Enabled = true;
         }
      }

      private void browse_excelfilepath_Click(object sender, EventArgs e)
      {
         OpenFileDialog fdlg = new OpenFileDialog();
         fdlg.Title = "Excel File Open File Dialog";
         fdlg.InitialDirectory = @"c:\";
         fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
         fdlg.FilterIndex = 2;
         fdlg.RestoreDirectory = true;
         if (fdlg.ShowDialog() == DialogResult.OK)
         {
            excelfilepathvalue.Text = fdlg.FileName;
         }
      }

      private void browse_pdffolderpath_Click(object sender, EventArgs e)
      {
         if (folderBrowserDialogPDFFolder.ShowDialog() == DialogResult.OK)
         {
            pdffolderpathvalue.Text = folderBrowserDialogPDFFolder.SelectedPath;
         }
      }

      private void errors_TextChanged(object sender, EventArgs e)
      {
      }

      private void Error_Click(object sender, EventArgs e)
      {
         
      }

      private void emailtemplatebrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog text = new OpenFileDialog();
         text.Title = "Excel File Open File Dialog";
         text.InitialDirectory = @"c:\";
         text.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
         text.FilterIndex = 2;
         text.RestoreDirectory = true;
         if (text.ShowDialog() == DialogResult.OK)
         {
            emailtemplatepath.Text = text.FileName;
         }
      }

      private void emailtemplatepath_TextChanged(object sender, EventArgs e)
      {
         emailsentcounter.Visible = false;
         EmailSent.Visible = false;
         Error.Visible = false;
         errorsValue.Visible = false;
         generate_emails.Enabled = false;
         if (!string.IsNullOrEmpty(pdffolderpathvalue.Text) && !string.IsNullOrEmpty(excelfilepathvalue.Text) && !string.IsNullOrEmpty(emailtemplatepath.Text) && !string.IsNullOrEmpty(emailsubjectvalue.Text))
         {
            generate_emails.Enabled = true;
         }
      }

      private string ReadSignature()
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

      private void emailsubjectvalue_TextChanged(object sender, EventArgs e)
      {
         emailsentcounter.Visible = false;
         EmailSent.Visible = false;
         Error.Visible = false;
         errorsValue.Visible = false;
         generate_emails.Enabled = false;
         if (!string.IsNullOrEmpty(pdffolderpathvalue.Text) && !string.IsNullOrEmpty(excelfilepathvalue.Text) && !string.IsNullOrEmpty(emailtemplatepath.Text) && !string.IsNullOrEmpty(emailsubjectvalue.Text))
         {
            generate_emails.Enabled = true;
         }
      }
   }
}
