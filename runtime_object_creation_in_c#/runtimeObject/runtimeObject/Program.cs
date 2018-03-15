using System;
using System.Reflection;
namespace runtimeObject
{
    class Program
    {
        static void Main(string[] args)
        {
            string strshapeName = System.Configuration.ConfigurationManager.AppSettings["shapeName"];
            Console.WriteLine(strshapeName);
            Type t = Type.GetType(strshapeName);
            try
            {
                Shape obj = (Shape)Assembly.GetExecutingAssembly().CreateInstance(strshapeName);
                // Shape obj = (Shape)Activator.CreateInstance(t);
                obj.draw(5);
                Console.WriteLine(obj.ToString());
            }
            catch (Exception e) { };
            Console.Read();

        }
    }
}
