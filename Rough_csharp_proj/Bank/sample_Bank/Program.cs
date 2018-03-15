using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountNS;

namespace sample_Bank
{
   class Program
   {
      static void Main(string[] args)
      {
         double beginningBalance = 11.99;
         double debitAmount = 4.55;
         double expected = 7.44;
         BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

         // act  
         account.Debit(debitAmount);

         // assert  
         double actual = account.Balance;
      }
   }
}
