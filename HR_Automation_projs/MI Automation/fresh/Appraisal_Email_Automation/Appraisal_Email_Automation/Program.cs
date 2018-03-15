using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_Email_Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //outlook.SendEMail();
                string MI_Type = "Promo";
                Employees Emp_list = new Employees(MI_Type);
                WordDoc doc = new WordDoc(MI_Type);
                doc.Start(Emp_list);

                MI_Type = "NonPromo";
                Emp_list = new Employees(MI_Type);
                doc = new WordDoc(MI_Type);
                doc.Start(Emp_list);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
