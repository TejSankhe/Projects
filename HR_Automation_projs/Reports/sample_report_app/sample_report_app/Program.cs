using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices;

namespace sample_report_app
{
   class Program
   {
      static void Main(string[] args)
      {
         string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\WORK\HR_Automation_projs\Reports\Sample_Database.accdb";
         string queryString = "select * from Employee";
         string empdata = "select [EMPLOYEE # (SYSTEM OF RECORD) in # format],[EMPLOYEE NAME],[ORACLE ID],[HIRE DATE (MM/DD/YYYY)],[BIRTH DATE (MM/DD/YYYY)],[EMPLOYYMENT STATUS],[STATUS DATE],[STREET ADDRESS],[STREET ADDRESSS (CONT)],[CITY],[CITY (CONT)],[STATE],[ZIP],[OFFICE PHONE NUMBER],[EMAIL ADDRESS],[FULL TIME/PART TIME],[POSITION TITLE],[SUPERVISOR],[SUPERVISOR  ORACLE  ID],[SUPERVISOR EMAIL ID],[NEW MATRIX SUPERVISOR],[HR PARTNER],[HR PARTNER ORACLE ID] from Employee where [LEGAL ENTITY] = @LE AND [PHYSICAL LOCATION (COUNTRY)] = @PhyLoc AND [SCOPE OF  RESP] = @SOR AND [REGION/AREA/COUNTRY FOR SCOPE] = @RAC AND [FUNCTION] = @function AND [LOB] = @LOB AND [SOLUTION] = @SOLUTION ";
        // string empdata = "select [EMPLOYEE # (SYSTEM OF RECORD) in # format],[EMPLOYEE NAME],[ORACLE ID],[HIRE DATE (MM/DD/YYYY)],[BIRTH DATE (MM/DD/YYYY)],[EMPLOYYMENT STATUS],[STATUS DATE],[STREET ADDRESS],[STREET ADDRESSS (CONT)],[CITY],[CITY (CONT)],[STATE],[ZIP],[OFFICE PHONE NUMBER],[EMAIL ADDRESS],[FULL TIME/PART TIME],[POSITION TITLE],[SUPERVISOR],[SUPERVISOR  ORACLE  ID],[SUPERVISOR EMAIL ID],[NEW MATRIX SUPERVISOR],[HR PARTNER],[HR PARTNER ORACLE ID] from Employee where [LEGAL ENTITY] = @LE";
         //  string compdata = "select [EMPLOYEE NAME],[ORACLE ID],[GRADE],[CUR],[BONUS ELIGIBLE SALARY LOCAL (ANNUAL BASE SALARY)],[ANNUAL FIXED SALARY LOCAL],[VARIABLE PLAN],[2017  VARIABLE TARGET % (COLUMN 'AN' AGAINGST ANNUAL BASE SALARY)],[VARIABLE TARGET LOCAL],[TOTAL CURRENT CASH COMP LOCAL],[2017 LTI TARGET %],[2017 LTI TARGET LOCAL],[TOTAL CURRENT DIRECT COMP LOCAL],[EFFECTIVE DATE OF VARIABLE PLAN ELIGIBILITY] from Employee";

         string compdata = "select [EMPLOYEE NAME],[ORACLE ID],[GRADE],[CUR],[BONUS ELIGIBLE SALARY LOCAL (ANNUAL BASE SALARY)],[ANNUAL FIXED SALARY LOCAL],[VARIABLE PLAN],[VARIABLE TARGET LOCAL],[TOTAL CURRENT CASH COMP LOCAL],[2017 LTI TARGET %],[2017 LTI TARGET LOCAL],[TOTAL CURRENT DIRECT COMP LOCAL],[EFFECTIVE DATE OF VARIABLE PLAN ELIGIBILITY],[2017  VARIABLE TARGET %(COLUMN 'AN' AGAINGST ANNUAL BASE SALARY)] from Employee where [LEGAL ENTITY] = @LE AND [PHYSICAL LOCATION (COUNTRY)] = @PhyLoc AND [SCOPE OF  RESP] = @SOR AND [REGION/AREA/COUNTRY FOR SCOPE] = @RAC AND [FUNCTION] = @function AND [LOB] = @LOB AND [SOLUTION] = @SOLUTION "; 
         try
         {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
               OleDbCommand command = new OleDbCommand(compdata, connection);
               connection.Open();
               string s = "WN";
               command.Parameters.AddWithValue("LE", s);
               command.Parameters.AddWithValue("PhyLoc", "MY");
               command.Parameters.AddWithValue("SOR", "AREA");
               command.Parameters.AddWithValue("RAC", "MY");
               command.Parameters.AddWithValue("function", "SALES");
               command.Parameters.AddWithValue("LOB", "SYSTEM");
               command.Parameters.AddWithValue("SOLUTION", "RETAIL");
               //command.Parameters["@LE"].Value = "WN";
               //command.Parameters["@PhyLoc"].Value = "MY";
               //command.Parameters["@SOR"].Value = "AREA";
               //command.Parameters["@RAC"].Value = "MY";
               //command.Parameters["@function"].Value = "SALES";
               //command.Parameters["@LOB "].Value = "SYSTEM";
               //command.Parameters["@SOLUTION"].Value = "Retail";


               OleDbDataReader reader = command.ExecuteReader();
               Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
               // creating new WorkBook within Excel application
               Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);// creating new Excelsheet in workbook
               Microsoft.Office.Interop.Excel._Worksheet worksheet = null; // see the excel sheet behind the program
               //app.Visible = true;
               // get the reference of first sheet. By default its name is Sheet1.
               // store its reference to worksheet
               worksheet = workbook.Sheets["Sheet1"];
               worksheet = workbook.ActiveSheet;
               //app.Visible = true;
               // changing the name of active sheet
               worksheet.Name = "Exported from gridview";
               int i = 2;
               var table = reader.GetSchemaTable();
               var nameCol = table.Columns["ColumnName"];
               int l = 1;
               foreach (DataRow row in table.Rows)
               {

                  worksheet.Cells[1, l] = row[nameCol];
                  l++;
                //  Console.WriteLine(row[nameCol]);
               }
               Console.ReadLine();
               while (reader.Read())
               {

                  for (int j = 0; j < reader.FieldCount; j++)
                  {
                     //string tmp = (string)reader[j];
                     if (!string.IsNullOrEmpty(reader[j].ToString()) || !string.IsNullOrWhiteSpace(reader[j].ToString()))
                     {
                        worksheet.Cells[i, j + 1] = reader[j];
                     }

                  }
                  i++;

               }

               reader.Close();
               worksheet.SaveAs(@"C:\WORK\HR_Automation_projs\Reports\sample_report_app\reports");
               Console.WriteLine("End");
               Console.ReadLine();
               app.Quit();

               Marshal.ReleaseComObject(worksheet);
               Marshal.ReleaseComObject(workbook);
               Marshal.ReleaseComObject(app);
               //while (reader.Read())
               //{
               //   Console.ReadLine();
               //   Console.WriteLine(reader[0].ToString() + reader[1].ToString());
               //}
               //reader.Close();
               //string queryString1 = "Delete *  from Employee where [VARIABLE TARGET LOCAL] = 0 ";
               //string queryString2 = "Delete *  from Employee where [TOTAL CURRENT DIRECT COMP LOCAL] = 0";
               //  string queryString = "Delete *  from Employee where SR >11";
               //Console.WriteLine(command1.ExecuteNonQuery());
               //Console.WriteLine(command2.ExecuteNonQuery());
               //OleDbCommand command1 = new OleDbCommand(queryString1, connection);
               //OleDbCommand command2 = new OleDbCommand(queryString2, connection);
               //int j = 1;
               //while (reader.Read())
               //{
               //   if (i == 5)
               //      i = 1;
               //   worksheet.Cells[j, i] = reader[i];
               //   i++;
               //   //worksheet.Cells[1, 2] = reader[2];
               //   //worksheet.Cells[1, 3] = reader[3];
               //   //worksheet.Cells[1, 4] = reader[4];
               //   //break;
               //   j++;
               //   if (j == 21)
               //      break;

               //}
               //while (reader.Read())
               //{

               //   for (int j = 0; j < reader.FieldCount; j++)
               //   {
               //      if (!string.IsNullOrEmpty(reader[j].ToString()) || !string.IsNullOrWhiteSpace(reader[j].ToString()))
               //      {
               //         Console.WriteLine(reader[j]);
               //         Console.ReadLine();
               //      }
               //   }
               //}
               // OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\WORK\HR_Automation_projs\Reports\Sample_Database.accdb");
               // OleDbCommand cmd = con.CreateCommand();
               // con.Open();
               // //cmd.CommandText = "UPDATE Employee SET ZIP = 3 WHERE SR=1 ";
               // //cmd.CommandText = "UPDATE Employee SET ZIP = 3 WHERE STATE = 'a' ";
               // cmd.CommandText = "UPDATE Employee SET ZIP = 4 WHERE [OFFICE PHONE NUMBER] = '1' "; 


               // cmd.Connection = con;
               //// SqlDataAdapter da = new SqlDataAdapter("data", con);
               // Console.WriteLine(cmd.ExecuteReader());

               // con.Close();
               // Console.ReadLine();

            }
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            Console.ReadLine();
         }
      }
   }

}
