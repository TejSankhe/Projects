using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rough_csharp_proj
{
   class CountNegative
   {
      public static void main()
      {
         int m = 2;
            int n=2;
         int[,] a = new int[m,n];
         for(int i=0;i<m; i++)
         {
            for (int j = 0; j < m; j++)
               a[i,j]=int.Parse( Console.ReadLine());
         }
         for (int i = 0; i < m; i++)
         {
            for (int j = 0; j < m; j++)
               Console.WriteLine(a[i,j]);
         }
      }
   }
}
