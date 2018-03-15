using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;  
namespace runtimeObject
{
    class UnityMain
    {
       /* static void Main(string[] args)
        {
          //  String shp = "circle";
            

            //  objContainer.RegisterType<Shape, Rectangle>("rectangle");
            // objContainer.RegisterType<Shape, Circle>("circle");
           
           
           try
            {
                IUnityContainer objContainer = new UnityContainer();
                //  if (ConfigurationManager.GetSection("unity") != null)
                // {
               // console.readline();
                objContainer.LoadConfiguration();
                Shape s = objContainer.Resolve<Shape>("Rectangle");
                s.draw(5);
                Console.ReadLine();
                 }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }*/
    }
}
