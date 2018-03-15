using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_Email_Automation
{
    public class Employees
    {
        public List<EmployeeInfo> MI_list { get; set; }
        public string filename { get; set; }

        public Employees(string MI_Type)
        {
            try
            {
                MI_list = new List<EmployeeInfo>();
                Load(MI_Type);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        void Load(string MI_Type)
        {
            try
            {
                if (MI_Type == "Promo")
                {
                    filename = ConfigurationSettings.AppSettings.Get("MI_FileName");
                    Console.WriteLine("Processing Promo letters...");
                }
                else if (MI_Type == "NonPromo")
                {
                    filename = ConfigurationSettings.AppSettings.Get("MI_FileName_NonPromo");
                    Console.WriteLine("Processing NonPromo letters...");
                }

                using (TextReader reader = new StreamReader(filename))
                {
                    string empRecord = reader.ReadLine();
                    empRecord = string.IsNullOrEmpty(empRecord) ? null : reader.ReadLine();
                    while (!string.IsNullOrEmpty(empRecord))
                    {
                        empRecord = empRecord.Replace(@"""", "");
                        string[] tokens = empRecord.Split(new char[] { ',' });

                        if (tokens.Length == 18)
                        {
                            if (!string.IsNullOrEmpty(tokens[0]))
                            {
                                EmployeeInfo empInfo = new EmployeeInfo();
                                empInfo.Oracle_Id = tokens[0];
                                empInfo.EmployeeCode = tokens[1];
                                empInfo.EmployeeName = tokens[5];
                                empInfo.Basic_Salary = tokens[10];
                                empInfo.HRA = tokens[11];
                                empInfo.Fitment_Allowance = tokens[12];
                                empInfo.Annual_Base = tokens[13];
                                empInfo.Target_Incentive = tokens[14];
                                empInfo.Annual_Target_Incentive = tokens[15];
                                empInfo.Annual_Total_Comp = tokens[16];
                                empInfo.Email = tokens[7];
                                empInfo.Designation = tokens[6];
                                empInfo.Password = tokens[17];

                                MI_list.Add(empInfo);
                            }
                        }
                        empRecord = string.IsNullOrEmpty(empRecord) ? null : reader.ReadLine();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }
}
