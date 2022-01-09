using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;

namespace Gig
{
   internal class SLAManager
   {
      public List<SLA> slas = new();

      public SLAManager()
      {
         UseDefault();
      }

      public void UseDefault()
      {
         slas.Clear();
         SLA sla = new();
         sla.color = "333333";
         sla.period = 60*60;
         slas.Add(sla);
      }

      public bool LoadJSON(string json)
      {
         // Todo : load default on failure.
         slas.Clear();
         dynamic? list = JsonConvert.DeserializeObject(json);
         if (list == null)
         {
            UseDefault();
            return false;
         }

         foreach (dynamic item in list)
         {
            SLA sla = new();
            sla.color = item.color;
            sla.period = item.period;

            slas.Add(sla);
         }

         if (slas.Count == 0)
         {
            UseDefault();
         }

         return true;
      }

   }
}
