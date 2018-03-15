using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Reports_Generation
{
   public class Helper : INotifyPropertyChanged
   {
      OleDbConnection connection = null;
      OleDbDataReader reader = null;
      string LE = string.Empty;
      string PhyLoc = string.Empty;
      string SOR = string.Empty;
      string RAC = string.Empty;
      string function = string.Empty;
      string LOB = string.Empty;
      string SOLUTION = string.Empty;
      public delegate void WriteResult(string s);
      public event WriteResult WriteResultEvent;
      public event PropertyChangedEventHandler PropertyChanged;

      private void NotifyChangeEvent(string name)
      {
         if (PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
         }
      }

      private Model model;

     public Model Model
      {
         get
         {
            return model;
         }

         set
         {
            model = value;
            NotifyChangeEvent("Model");
         }
      }

     public  void OpenConnection(string PATH_OF_ACCESS_DATABASE)
      {
         string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + PATH_OF_ACCESS_DATABASE;
         try
         {
            connection = new OleDbConnection(connectionString);
            connection.Open();
         }
         catch (Exception e)
         {
            WriteResultEvent(e.Message);
         }
      }

      public void SetParameters(string LE ,string PhyLoc , string SOR ,string RAC ,string function, string LOB, string SOLUTION)
      {
         this.LE = LE;
         this.PhyLoc = PhyLoc;
         this.SOR = SOR;
         this.RAC = RAC;
         this.function = function;
         this.LOB = LOB;
         this.SOLUTION = SOLUTION;
      }

      public void CloseConnection()
      {
         try
         {
            if(connection!=null)
            connection.Dispose();
         }
         catch(Exception e)
         {
            WriteResultEvent(e.Message);
         }

      }

      public void GetDataFromDatabase(string queryString)
      {
         try
         {
            if (connection != null)
            {
               OleDbCommand command = new OleDbCommand(queryString, connection);
               command.Parameters.AddWithValue("LE", LE);
               command.Parameters.AddWithValue("PhyLoc", PhyLoc);
               command.Parameters.AddWithValue("SOR", SOR);
               command.Parameters.AddWithValue("RAC", RAC);
               command.Parameters.AddWithValue("function", function);
               command.Parameters.AddWithValue("LOB", LOB);
               command.Parameters.AddWithValue("SOLUTION", SOLUTION);
               OleDbDataReader reader = command.ExecuteReader();
               this.reader = reader;
            }
            else
            {
              // return null;
            }
         }
         catch (Exception e)
         {
            WriteResultEvent(e.Message);
         }
      }

      public void GenerateReport(string PATH_WHERE_REPORT_NEED_TO_BE_GENERATED)
      {
         string reportPath = @PATH_WHERE_REPORT_NEED_TO_BE_GENERATED + "\\Report.xlsx";
         try
         {
            if (!reader.Equals(null))
            {
               Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
               Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
               Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
               worksheet = workbook.Sheets["Sheet1"];
               worksheet = workbook.ActiveSheet;
               worksheet.Name = "Report";
               int i = 2;
               var table = reader.GetSchemaTable();
               var nameCol = table.Columns["ColumnName"];
               int l = 1;
               foreach (DataRow row in table.Rows)
               {

                  worksheet.Cells[1, l] = row[nameCol];
                  l++;
               }
               while (reader.Read())
               {

                  for (int j = 0; j < reader.FieldCount; j++)
                  {
                     if (!string.IsNullOrEmpty(reader[j].ToString()) || !string.IsNullOrWhiteSpace(reader[j].ToString()))
                     {
                        worksheet.Cells[i, j + 1] = reader[j];
                     }

                  }
                  i++;

               }
               reader.Close();
               if (File.Exists(reportPath))
                  File.Delete(reportPath);
               worksheet.SaveAs(reportPath);
               app.Quit();

               Marshal.ReleaseComObject(worksheet);
               Marshal.ReleaseComObject(workbook);
               Marshal.ReleaseComObject(app);
               WriteResultEvent("Report generated at: " + reportPath);
            }
            else
            {
               WriteResultEvent("Based on given filters, no data retrived.");
            }
         }
         catch(Exception e)
         {
            WriteResultEvent(e.Message);
         }

      }
   }
}
