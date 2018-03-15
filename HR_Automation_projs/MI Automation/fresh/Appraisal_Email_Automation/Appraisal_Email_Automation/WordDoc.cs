using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Outlook;
using System.Configuration;
using System.IO;
using PdfSharp.Pdf;


namespace Appraisal_Email_Automation
{
    using WordApplication = Microsoft.Office.Interop.Word.Application;
    public class WordDoc
    {
        public string fileName { get; set; }
        public string file { get; set; }
        public string CurDir { get; set; }
        public string WordDir { get; set; }
        public string PdfDir { get; set; }
        public string MI_Type { get; set; }
        SendEmail email = new SendEmail();
        Outlook_Wtapper outlook;

        public WordDoc(string MI_Type)
        {
            try
            {
                this.MI_Type = MI_Type;
                if (this.MI_Type == "Promo")
                {
                    fileName = ConfigurationSettings.AppSettings["Word_Template"];
                }
                else if (this.MI_Type == "NonPromo")
                {
                    fileName = ConfigurationSettings.AppSettings["Word_Template_NonPromo"];
                }

                WordDir = ConfigurationSettings.AppSettings["Word_files_dir"];
                PdfDir = ConfigurationSettings.AppSettings["pdf_files_dir"];
                if (!Directory.Exists(WordDir))
                {
                    Directory.CreateDirectory(WordDir);
                }

                if (!Directory.Exists(PdfDir))
                {
                    Directory.CreateDirectory(PdfDir);
                }

                CurDir = Directory.GetCurrentDirectory();
                file = CurDir + fileName;
                outlook = new Outlook_Wtapper();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
        public void Start(Employees employees)
        {
            try
            {
                Object oMissing = System.Reflection.Missing.Value;
                Object oTrue = true;
                Object oFalse = false;
                WordApplication oWordApp = new WordApplication();
                Document oWordDoc = new Document();
                int counter = 1;

                oWordApp.Visible = false;
                Object oTemplatePath = file;
                foreach (EmployeeInfo emp_info in employees.MI_list)
                {
                    string fileName = emp_info.EmployeeCode + " - " + emp_info.EmployeeName + " – Merit Increase Letter 2017.pdf";
                    string path = PdfDir + fileName;

                    
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Processing {0} letter for {1}, request {2} of {3}", this.MI_Type, emp_info.EmployeeName, counter++, employees.MI_list.Count);
                        oWordDoc = oWordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
                        foreach (Field myMergeField in oWordDoc.Fields)
                        {
                            Range rngFieldCode = myMergeField.Code;
                            String fieldText = rngFieldCode.Text;
                            if (fieldText.StartsWith("INCLUDEPICTURE"))
                            {

                                myMergeField.Select();
                                oWordApp.Selection.TypeText(emp_info.EmployeeCode);
                            }
                            //INCLUDEPICTURE MERGEFIELD "Picture"   \*MERGEFIELD

                            if (fieldText.StartsWith(" MERGEFIELD"))
                            {
                                //Int32 endMerge = fieldText.IndexOf("\\");
                                //Int32 fieldNameLength = fieldText.Length - endMerge;
                                String fieldName = fieldText.Substring(11).Trim();
                                String[] fields = fieldName.Split(' ');

                                //fieldName = fieldName.Trim();
                                if (fields[0] != "")
                                {
                                    switch (fields[0])
                                    {
                                        case "Emp_Code":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.EmployeeCode);
                                            break;
                                        case "Oracle_Id":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.Oracle_Id);
                                            break;
                                        case "Full_Name":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.EmployeeName);
                                            break;
                                        case "Basic_Salary":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.Basic_Salary);
                                            break;
                                        case "House_Rent_Allowance":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.HRA);
                                            break;
                                        case "Fitment_Allowance_":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.Fitment_Allowance);
                                            break;
                                        case "ANNUAL_BASE_PAY_a":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.Annual_Base);
                                            break;
                                        case "Target_Incentive__of_Annual_Base_Pay":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.Target_Incentive);
                                            break;
                                        case "ANNUAL_INCENTIVE_AT_TARGET_b":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.Annual_Target_Incentive);
                                            break;
                                        case "ANNUAL_TOTAL_TARGET_COMPENSATION_c_ab":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.Annual_Total_Comp);
                                            break;
                                        case "Designation":
                                            myMergeField.Select();
                                            oWordApp.Selection.TypeText(emp_info.Designation);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                        object savePath = path;
                      
                        object fileFormat = WdSaveFormat.wdFormatPDF;
                       
                        oWordDoc.SaveAs2(ref savePath, ref fileFormat, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                        //email.Send(emp_info.Email, emp_info.CC_Email, path, string.Empty);
                        object saveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                        oWordDoc.Close(ref saveChanges, ref oMissing, ref oMissing);

                        PdfDocument document = PdfSharp.Pdf.IO.PdfReader.Open(path);
                        PdfSharp.Pdf.Security.PdfSecuritySettings securitySettings = document.SecuritySettings;

                        // Setting one of the passwords automatically sets the security level to 
                        // PdfDocumentSecurityLevel.Encrypted128Bit.
                        securitySettings.UserPassword = emp_info.Password;
                        securitySettings.OwnerPassword = "owner";

                        // Don't use 40 bit encryption unless needed for compatibility reasons
                        //securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

                        // Restrict some rights.
                        securitySettings.PermitAccessibilityExtractContent = false;
                        securitySettings.PermitAnnotations = false;
                        securitySettings.PermitAssembleDocument = false;
                        securitySettings.PermitExtractContent = false;
                        securitySettings.PermitFormsFill = true;
                        securitySettings.PermitFullQualityPrint = true;
                        securitySettings.PermitModifyDocument = true;
                        securitySettings.PermitPrint = true;

                        // Save the document...
                        document.Save(path);
                        document.Close();




                        outlook.SendEMail(emp_info.Email, emp_info.EmployeeName, path);
                    }
                    else
                    {
                        Console.WriteLine("Couldn't Process {0} letter for {1}, request {2} of {3}", this.MI_Type, emp_info.EmployeeName, counter++, employees.MI_list.Count);
                    }
                }

                oWordApp.Quit();

                if (this.MI_Type == "NonPromo")
                {
                    Console.WriteLine("All letters processed as mentioned above. Press any key to exit...");
                    Console.ReadKey();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
           
        }
    }
}
