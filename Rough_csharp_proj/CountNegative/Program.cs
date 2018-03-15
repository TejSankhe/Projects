using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNegative
{
   class Program
   {
      static void Main(string[] args)
      {
         int m = 4;
         int n = 4;
         int count = 0;
         int[,] a = new int[m, n];
         for (int i = 0; i < m; i++)
         {
            for (int j = 0; j < m; j++)
               a[i, j] = int.Parse(Console.ReadLine());
         }
         for (int i = 0; i < m; i++)
         {
            for (int j = 0; j < n; j++)
            {
               if (a[i, j] >= 0)
               {
                  n = j;
                  break;
               }
               count++;
            }
         }
         Console.WriteLine(count);
         Console.ReadLine();
   }
   }
}
