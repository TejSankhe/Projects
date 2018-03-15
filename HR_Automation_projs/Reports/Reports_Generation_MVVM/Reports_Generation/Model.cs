using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_Generation
{
   public class Model : INotifyPropertyChanged
   {
      private string legalEntity;

      public string LegalEntity
      {
         get
         {
            return legalEntity;
         }

         set
         {
            legalEntity = value;
            NotifyChangeEvent("LegalEntity");
         }
      }

      public event PropertyChangedEventHandler PropertyChanged;

      private void NotifyChangeEvent(string name)
      {
         if(PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
         }
      }
   }
}
