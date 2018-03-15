using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_Email_Automation
{
    public class EmployeeInfo
    {
        private string m_Basic_Salary;
        private string m_HRA;
        private string m_Fitment_Allowance;
        private string m_Annual_Base;
        private string m_Target_Incentive;
        private string m_Annual_Total_Comp;
        private string m_Annual_Target_Incentive;

        public string EmployeeCode { get; set; }
        public string Oracle_Id { get; set; }
        public string EmployeeName { get; set; }
        public string Basic_Salary {
            get {
                
                return m_Basic_Salary;
            }
            set
            {
                if (value.Trim() == "-")
                {
                    this.m_Basic_Salary = value;
                }
                else
                {
                    this.m_Basic_Salary = String.Format("{0:#,##0}", Convert.ToInt32(value));
                }
            }
        }
        public string HRA
        {
            get
            {
                return m_HRA;
            }
            set
            {
                if (value.Trim() == "-")
                {
                    this.m_HRA = value;
                }
                else
                {
                    this.m_HRA = String.Format("{0:#,##0}", Convert.ToInt32(value));
                }
            }
        }
        public string Fitment_Allowance
        {
            get
            {
                return m_Fitment_Allowance;
            }
            set
            {
                if (value.Trim() == "-")
                {
                    this.m_Fitment_Allowance = value;
                }
                else
                {
                    this.m_Fitment_Allowance = String.Format("{0:#,##0}", Convert.ToInt32(value));
                }
            }
        }
        public string Annual_Base
        {
            get
            {
                return m_Annual_Base;
            }
            set
            {
                if (value.Trim() == "-")
                {
                    this.m_Annual_Base = value;
                }
                else
                {
                    this.m_Annual_Base = String.Format("{0:#,##0}", Convert.ToInt32(value));
                }
            }
        }
        public string Target_Incentive { get; set; }
      
        public string Annual_Target_Incentive
        {
            get
            {
                return m_Annual_Target_Incentive;
            }
            set
            {
                if(value.Trim() == "-")
                {
                    this.m_Annual_Target_Incentive = value;
                }
                else
                {
                    this.m_Annual_Target_Incentive = String.Format("{0:#,##0}", Convert.ToInt32(value));
                }
                
            }
        }
        public string Annual_Total_Comp
        {
            get
            {
                return m_Annual_Total_Comp;
            }
            set
            {
                if (value.Trim() == "-")
                {
                    this.m_Annual_Total_Comp = value;
                }
                else
                {
                    this.m_Annual_Total_Comp = String.Format("{0:#,##0}", Convert.ToInt32(value));

                }
            }
        }
        public string Email { get; set; }
        public string CC_Email { get; set; }
        public string Designation { get; set; }

        public string Password { get; set; }
    }
}
