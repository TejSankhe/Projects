using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace Appraisal_Email_Automation
{
    /// <summary>
    /// Adds some nice help to the console for Password or secure strings
    /// </summary>
    static public class Secure_String
    {
        /// <summary>
        /// Like System.Console.ReadLine(), only with a mask.
        /// to convert to string use ConvertToString
        /// </summary>
        /// <param name="mask">a <c>char</c> representing your choice of console mask</param>
        /// <returns>the string the user typed in </returns>
        public static SecureString ReadSecureString(char mask)
        {
            try
            {
                const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
                int[] FILTERED = { 0, 27, 9, 10 /*, 32 space, if you care */ };

                var pass = new Stack<char>();
                char chr = (char)0;
                SecureString secureStr = new SecureString();
                while ((chr = System.Console.ReadKey(true).KeyChar) != ENTER)
                {
                    if (chr == BACKSP || chr == CTRLBACKSP)
                    {
                        if (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                            secureStr.RemoveAt(secureStr.Length - 1);
                        }
                    }
                    else if (FILTERED.Count(x => chr == x) > 0) { }
                    else
                    {
                        secureStr.AppendChar(chr);
                        pass.Push((char)chr);
                        System.Console.Write(mask);
                    }
                }

                System.Console.WriteLine();

                return secureStr;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        /// <summary>
        /// Like System.Console.ReadLine(), only with a default mask *.
        ///  for custom mask use ReadPassword(char mask)
        /// </summary>
        /// <returns>the SecureString the user typed in </returns>
        public static SecureString ReadSecureString()
        {
            try
            {
                return ReadSecureString('*');
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
    }
}