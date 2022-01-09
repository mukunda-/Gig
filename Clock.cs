using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig
{
   internal class Clock
   {
      public string name;
      private long totalTime;
      private long startTime;
      public ClockManager? parent;

      public Clock( string name )
      {
         totalTime = 0;
         startTime = 0;
         this.name = name;
      }

      public void Start()
      {
         long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
         startTime = now;
      }

      public void Stop()
      {
         if (startTime == 0) return;

         long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

         totalTime += now - startTime;
         startTime = 0;
      }

      public long GetTime()
      {
         long time = totalTime;
         if (startTime > 0)
         {
            long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            time += now - startTime;
         }
         return time;
      }

      public long GetMinutes()
      {
         long time = GetTime();
         return (long)Math.Round(time / 1000.0 / 60.0);
      }

      public void SetTime( long time )
      {
         totalTime = time;
         long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
         startTime = 0;
         parent?.FireClockChanged();
      }

      public string GetTimestamp()
      {
         string prefix = "";
         var time = GetTime();
         if (time < 0)
         {
            time = -time;
            prefix = "-";
         }
         int seconds = (int)Math.Round(time / 1000.0);
         int minutes = seconds / 60;
         seconds %= 60;
         return $"{prefix}{minutes}:{seconds:00}";
      }

      public static long ParseTimestamp( string input )
      {
         try
         {
            input = input.Trim();
            if (input == "") return 0;
            string[] sp = input.Split(":");
            int mins = int.Parse(sp[0]);
            int secs = 0;
            if (sp.Length > 1)
            {
               secs = int.Parse(sp[1]);
            }
            return (mins * 60 + secs) * 1000;
         }
         catch( Exception )
         {
            return -1;
         }
      }
   }
}
