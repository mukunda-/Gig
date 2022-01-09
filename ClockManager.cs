using System.IO;

namespace Gig
{
   internal class ClockManager
   {
      public static DateTime sessionStart = DateTime.Now;
      private readonly List<Clock> clocks = new();
      private Clock activeClock = new("");
      private readonly Clock pauseTimer = new("Paused/Misc");

      public delegate void ClockChangedEventHandler(object sender, EventArgs e);
      public event ClockChangedEventHandler? ClockChanged;

      public ClockManager()
      {
         clocks.Add(activeClock);
      }

      private string ConvertToCsvCell(string value)
      {
         var mustQuote = value.Any(x => x == ',' || x == '\"' || x == '\r' || x == '\n');

         if (!mustQuote) return value;

         value = value.Replace("\"", "\"\"");

         return $"\"{value}\"";
      }

      public void SaveLog()
      {
         string outputPath = Path.Combine(Util.DocumentsFolder, "gig-log.csv");
         string timestamp = sessionStart.ToShortDateString();
         if (!File.Exists(outputPath))
         {
            File.WriteAllText(outputPath, "Date,Timer,Minutes\n");
         }
         List<string> logLines = new();
         clocks.Add(pauseTimer);
         foreach( Clock clock in clocks )
         {
            if (clock.GetMinutes() <= 0) continue;
            string name = ConvertToCsvCell(clock.name);
            string minutes = ConvertToCsvCell(clock.GetMinutes().ToString());
            logLines.Add($"{timestamp},{name},{minutes}");
         }
         clocks.Remove(pauseTimer);

         File.AppendAllLines(outputPath, logLines);
      }

      //public Clock? GetClockByName(string name)
      //{
      //   foreach (Clock c in clocks)
      //   {
      //      if( c.name == name )
      //      {
      //         return c;
      //      }
      //   }
      //   return null;
      //}

      public void AddClock(Clock clock)
      {
         //if (GetClockByName(clock.name) != null)
         //{
         //   MessageBox.Show( "Clock name already exists." );
         //   return false;
         //}

         clocks.Add(clock);
         clock.parent = this;
      }

      public void RemoveClock(Clock clock)
      {
         if( clocks.Count == 1 )
         {
            MessageBox.Show("Cannot remove last clock.");
            return;
         }
         clocks.Remove(clock);
         clock.parent = null;
         if (clock == activeClock)
         {
            SetActiveClock(clocks[0]);
         }
      }

      public void SetActiveClock(Clock clock)
      {
         activeClock.Stop();
         activeClock = clock;
         FireClockChanged();
      }

      public Clock GetActiveClock()
      {
         return activeClock;
      }

      public List<Clock> GetClocks()
      {
         return clocks;
      }

      public void FireClockChanged()
      {
         ClockChanged?.Invoke(this, new EventArgs());
      }

      public void StartPause()
      {
         pauseTimer.Start();
      }

      public void StopPause()
      {
         pauseTimer.Stop();
      }

      public Clock GetPause()
      {
         return pauseTimer;
      }
   }
}
