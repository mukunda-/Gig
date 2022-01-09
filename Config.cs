using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gig
{
   internal class Config
   {
      private static string configExample = @"

{
   ""title"": ""L2"",
   ""defaultColor"": ""red"",
   ""sla"": [
      {
         ""period"": 3600,
         ""color"": ""ff0000""
      }
   ]
}

      ".Trim();

      public struct SLA
      {
         public long period = 0;
         public Color color = Color.Black;
      }

      public dynamic? configData;
      public Color defaultColor = Color.Black;
      public string title = "";
      public List<SLA> slas = new();

      public Config()
      {
         Reload();
      }

      //-------------------------------------------------------------------------------
      // Returns the path to %appdata%/Roaming/Gig/config.json
      private string ConfigFilePath
      {
         get
         {
            return Path.Combine(Util.AppDataFolder, "config.json");
         }
      }

      public void SaveExample()
      {
         if (File.Exists(ConfigFilePath)) return;
         File.WriteAllText(ConfigFilePath, configExample);
      }

      //-------------------------------------------------------------------------------
      // Opens the default text editor with the config json file.
      public void OpenEditor()
      {
         SaveExample();

         new Process
         {
            StartInfo = new ProcessStartInfo(ConfigFilePath)
            {
               UseShellExecute = true
            }
         }.Start();
      }

      //-------------------------------------------------------------------------------
      public void Reload()
      {
//         dynamic test = JsonConvert.DeserializeObject(
//            @"{
//""a"": 5,
//""b"": 6,
//""c"": 7,
//""de"": {
//  ""e"":55
//}

//}");
//         Debug.Print($"{test.a}");
//         Debug.Print($"{test.b}");
//         Debug.Print($"{test.c??1}");
//         Debug.Print($"{test.d?.e??1}");
//         return;
         if (!File.Exists(ConfigFilePath)) return;
         try
         {
            configData = JsonConvert.DeserializeObject(File.ReadAllText(ConfigFilePath));
         
            if (configData == null) return;

            title = configData.title ?? "";
            string defaultColorHex = configData.defaultColor ?? "000000";
            defaultColor = HexColor(defaultColorHex);
            if ((configData.sla ?? null) != null)
            {
               slas.Clear();
               foreach (dynamic item in configData.sla)
               {
                  SLA sla = new();
                  string col = item.color ?? "000000";
                  sla.color  = HexColor(col);
                  sla.period = item.period ?? 0;
                  slas.Add(sla);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error loading config.json: " + ex.ToString());
            return;
         }
      }

      public long GetLongestSLAPeriod()
      {
         if (slas.Count == 0) return 0;
         return slas[^1].period;
      }

      //-------------------------------------------------------------------------------
      public static Color HexColor(string hex)
      {
         try
         {
            return Color.FromArgb(
               int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber),
               int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber),
               int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber));
         }
         catch (Exception)
         {
            return Color.Black;
         }
      }
   }
}
