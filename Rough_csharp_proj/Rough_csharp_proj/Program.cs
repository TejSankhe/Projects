using Jil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rough_csharp_proj
{
   public class Customer
   {
      public Dictionary<string, string> Parameters = new Dictionary<string, string>();
   }
   class Program
   {
      private static string SerializeCustomer(Customer customer)
      {
         return JSON.SerializeDynamic(customer);
      }

      private static string DeserializeCustomer(string customerString)
      {
         return JSON.Deserialize<string>(customerString,null);
      }
      public static void Main()
      {
         dynamic requestmsg = "{\"Parameters\":{ \"FirstName\":\"P\",\"LastName\":\"BEACH\"}}";
         dynamic TGreq = "{\"header\": {\"uri\":\"/tg?method=request\",\"method\": \"POST\",\"sessionId\": \"2fe7efd0-d99a-4fbf-8158-eb6982fe4070\",\"userId\": \"Tej\",\"type\": \"REQUEST\"},\"body\": {\"data\": { \"HeaderRq\": {\"MessageType\": \"Request\",\"Function\": \"CustomerIdentify\",\"DateAndTimeLocalTransaction\": \"20170823143450\",\"DateAndTimeTransmission\": \"20170823143450\",\"Terminal\": {\"Id\": \"INIDC-SANKHT\",\"Name\": null,\"Type\": \"Teller\"},\"User\": {\"Id\": \"Tej\",\"Name\": \"Tej\"},\"TransactionRef\": \"67c56c2a-45d1-4b87-a74a-00869a591cf6\"},\"Parameters\": {\"Name\": {\"First\": \"P\",\"Last\": \"BEACH\"},\"IsOrganization\": false }} } }";
            string sr = "{\n\t\"header\": {\n\t\t\"uri\": \"/tg?method=request\",\n\t\t\"method\": \"POST\",\n\t\t\"sessionId\": \"2f5fa36b-8c60-4e2b-88a5-2287ad201606\",\n\t\t\"userId\": \"Tej\",\n\t\t\"type\": \"REQUEST\"\n\t},\n\t\"body\": {\n\t\t\"data\": {\n\t\t\t\"HeaderRq\": {\n\t\t\t\t\"MessageType\": \"Request\",\n\t\t\t\t\"Function\": \"CustomerIdentify\",\n\t\t\t\t\"DateAndTimeLocalTransaction\": \"20170823143450\",\n\t\t\t\t\"DateAndTimeTransmission\": \"20170823143450\",\n\t\t\t\t\"Terminal\": {\n\t\t\t\t\t\"Id\": \"INIDC-SANKHT\",\n\t\t\t\t\t\"Name\": null,\n\t\t\t\t\t\"Type\": \"Teller\"\n\t\t\t\t},\n\t\t\t\t\"User\": {\n\t\t\t\t\t\"Id\": \"Tej\",\n\t\t\t\t\t\"Name\": \"Tej\"\n\t\t\t\t},\n\t\t\t\t\"TransactionRef\": \"67c56c2a-45d1-4b87-a74a-00869a591cf6\"\n\t\t\t},\n\t\t\t\"Parameters\": {\n\t\t\t\t\"Name\": {\n\t\t\t\t\t\"First\": \"P\",\n\t\t\t\t\t\"Last\": \"BEACH\"\n\t\t\t\t},\n\t\t\t\t\"IsOrganization\": false\n\t\t\t}\n\t\t}\n\t}\n}";
            object s = JSON.Serialize<object>(sr);
            object c = JSON.Deserialize<object>(s.ToString()); 
                //DeserializeCustomer(TGreq);
        // Console.WriteLine(c.Parameters);
        // Console.WriteLine(SerializeCustomer(c));
         Console.ReadLine();
      }
   }



}


