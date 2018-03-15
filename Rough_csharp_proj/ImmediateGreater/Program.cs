using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmediateGreater
{
   class Program
   {
      static void Main(string[] args)
      {
         string s = "5674";
         int [] a = s.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
         foreach(int temp in a)
         Console.WriteLine(s[1]);

         Console.ReadLine();
      }
   }
}
