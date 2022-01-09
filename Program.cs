namespace Gig
{
   internal static class Program
   {
      // I wonder what is the proper way to have static classes like this for the program.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
      public static ClockManager clockManager;
      public static Config config;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
      /// <summary>
      ///  The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         clockManager = new();
         config = new();
         
         // To customize application configuration such as set high DPI settings or default font,
         // see https://aka.ms/applicationconfiguration.
         ApplicationConfiguration.Initialize();
         Directory.CreateDirectory(Util.AppDataFolder);
         Application.ApplicationExit += new EventHandler(OnApplicationExit);
         Application.Run(new MainForm());
      }

      private static void OnApplicationExit(object? sender, EventArgs e)
      {
         clockManager.SaveLog();

      }

      public static void Exit()
      {
         // Save log
         Application.Exit();
      }
   }
}