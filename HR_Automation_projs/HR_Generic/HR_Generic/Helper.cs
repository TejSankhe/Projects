using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Word;
using PdfSharp.Pdf;
using System.Text.RegularExpressions;
using System.Configuration;

namespace HR_Generic
{
   class Helper
   {
      public static int count = 0;
      public static String result;
      public static int rw = 0;
      public static List<Employee> Read_excel_file(String path_of_excel_file)
      {
         List<Employee> Employee_List = new List<Employee>();
         try
         {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@path_of_excel_file);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range range = range = xlWorkSheet.UsedRange;

            rw = range.Rows.Count;
            int cl = range.Columns.Count;
            UpdateSetting("No_of_colums_in_excel", cl.ToString());
            for (int rCnt = 3; rCnt <= rw; rCnt++)
            {
               Employee_List.Add(new Employee());
               int No_of_colums_in_excel = int.Parse(ConfigurationSettings.AppSettings.Get("No_of_colums_in_excel"));

               for (int cCnt = 1; cCnt <= No_of_colums_in_excel; cCnt++)
               {
                  Employee_List[rCnt - 3].Fields["a" + cCnt] = (range.Cells[rCnt, cCnt] as Excel.Range).Value2.ToString();
               }
            }
           
         }
         catch(Exception e)
         {
            result = e.Message;
         }
         return Employee_List;
      }


      private static void UpdateSetting(string key, String value)
      {
         try
         {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
         }
         catch (Exception e)
         {
            result = e.Message;
         }
      }

      public static void Generate_PDF(List<Employee> Employee_List, String path_of_word_file,String text_append_to_filename)
      {
         
         count = 0;
         Object oMissing = System.Reflection.Missing.Value;
         Object oTrue = true;
         Object oFalse = false;
         Application oWord = new Application();
         Document oWordDoc = new Document();
         oWord.Visible = false;
         Object oTemplatePath = @path_of_word_file;
         string PDFDirectory = AppDomain.CurrentDomain.BaseDirectory + "PDF_Files";
         string WORDDirectory = AppDomain.CurrentDomain.BaseDirectory + "WORD_Files";
         Directory.CreateDirectory(PDFDirectory);
         Directory.CreateDirectory(WORDDirectory);
         string fileName = null;
         //  oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
         foreach (Employee emp_info in Employee_List)
         {
            try
            { 
               if (!string.IsNullOrEmpty(emp_info.Fields["a1"]) && !string.IsNullOrEmpty(emp_info.Fields["a2"]))
               {
                   fileName = emp_info.Fields["a1"] + " - " + emp_info.Fields["a2"] + text_append_to_filename;
               }
               else
               {
                  if (!string.IsNullOrEmpty(emp_info.Fields["a1"]) && string.IsNullOrEmpty(emp_info.Fields["a2"]))
                  {
                      fileName = emp_info.Fields["a1"] + text_append_to_filename;
                  }
                  else
                  {
                     if (string.IsNullOrEmpty(emp_info.Fields["a1"]) && !string.IsNullOrEmpty(emp_info.Fields["a2"]))
                     {
                         fileName = emp_info.Fields["a2"] + text_append_to_filename;
                     }
                  }
               }
               // Console.WriteLine("Processing {0} letter for {1}, request {2} of {3}", this.MI_Type, emp_info.EmployeeNam, counter++, employees.MI_list.Count);
               oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
               foreach (Field myMergeField in oWordDoc.Fields)
               {

                  Range rngFieldCode = myMergeField.Code;
                  String fieldText = rngFieldCode.Text;
                  if (fieldText.StartsWith(" MERGEFIELD"))
                  {
                     Int32 endMerge = fieldText.IndexOf("\\");
                     Int32 fieldNameLength = fieldText.Length - endMerge;
                     int No_of_colums_in_excel = int.Parse(ConfigurationSettings.AppSettings.Get("No_of_colums_in_excel"));
                     String fieldName = fieldText.Substring(11).Trim();
                     fieldName = fieldName.Trim();
                     bool result = Regex.IsMatch(fieldName, @"[""'\\]+");
                     if (result)
                     {
                        fieldName = fieldName.Trim('"');
                        fieldName = fieldName.Trim('\\');
                        //final = (fieldName.Substring((fieldName.Length - 1), (value.Length - 1)).Trim());
                     }
                     String anum = fieldName;
                     int Field_value;
                     if (int.Parse(anum.Substring(1, anum.Length - 1)) > 6)
                     {

                        if ((int.TryParse(emp_info.Fields[fieldName], out Field_value)))
                        {
                           emp_info.Fields[fieldName] = string.Format("{0:n0}", Field_value);
                        }
                     }
                     //fieldName = fieldName.Trim();

                     if (fieldName != "")
                     {
                        myMergeField.Select();
                        oWord.Selection.TypeText(emp_info.Fields[fieldName]);
                     }
                  }
               }
               String savePath_string_pdf = PDFDirectory + "\\" + fileName;
               Object savePathpdf = savePath_string_pdf;
               String savePath_string_word = WORDDirectory + "\\" + fileName;
               Object savePathword = savePath_string_word;
               object fileFormatpdf = WdSaveFormat.wdFormatPDF;
               object fileFormatword = WdSaveFormat.wdFormatDocument;
               object saveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
               //saving wordfiles
               oWordDoc.SaveAs2(ref savePathword, ref fileFormatword, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

               //saving pdfs
               oWordDoc.SaveAs2(ref savePathpdf, ref fileFormatpdf, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
               oWordDoc.Close(ref saveChanges, ref oMissing, ref oMissing);

               PdfDocument document = PdfSharp.Pdf.IO.PdfReader.Open(savePath_string_pdf + ".pdf");
               PdfSharp.Pdf.Security.PdfSecuritySettings securitySettings = document.SecuritySettings;

               // Setting one of the passwords automatically sets the security level to 
               // PdfDocumentSecurityLevel.Encrypted128Bit.
               if (!String.IsNullOrEmpty(emp_info.Fields["a6"]))
               {
                  securitySettings.UserPassword = emp_info.Fields["a6"];
               }
               else
               {
                  if (!String.IsNullOrEmpty(emp_info.Fields["a5"]))
                     securitySettings.UserPassword = emp_info.Fields["a5"];
               }
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
               document.Save(savePath_string_pdf + ".pdf");
               document.Close();
               count++;
               result = count.ToString();
            }
            catch (Exception e)
            {
               result += e.Message;
            }
         }
        
            
         }
      }
   }


