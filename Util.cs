using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig
{
   internal class Util
   {

      public static string GetInput(string prompt, string initialText = "")
      {
         System.Drawing.Size size = new System.Drawing.Size(200, 70);
         Form inputBox = new Form();

         inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         inputBox.MaximizeBox = false;
         inputBox.MinimizeBox = false;
         inputBox.ClientSize = size;
         inputBox.Text = prompt;

         System.Windows.Forms.TextBox textBox = new TextBox();
         textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
         textBox.Location = new System.Drawing.Point(5, 5);
         textBox.Text = initialText;
         inputBox.Controls.Add(textBox);

         Button okButton = new Button();
         okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         okButton.Name = "okButton";
         okButton.Size = new System.Drawing.Size(75, 23);
         okButton.Text = "&OK";
         okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
         inputBox.Controls.Add(okButton);

         Button cancelButton = new Button();
         cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         cancelButton.Name = "cancelButton";
         cancelButton.Size = new System.Drawing.Size(75, 23);
         cancelButton.Text = "&Cancel";
         cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
         inputBox.Controls.Add(cancelButton);

         inputBox.AcceptButton = okButton;
         inputBox.CancelButton = cancelButton;

         DialogResult result = inputBox.ShowDialog();
         string input = textBox.Text;
         if (result != DialogResult.OK) return "";
         return input.Trim();
      }

      //----------------------------------------------------------------------------------
      // Returns the path to User/AppData/Roaming/Marbles.
      public static string AppDataFolder
      {
         get
         {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "Gig");
         }
      }

      //----------------------------------------------------------------------------------
      // Returns the path to User/AppData/Roaming/Marbles.
      public static string DocumentsFolder
      {
         get
         {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
         }
      }

      public static Screen? FindScreen(int x, int y)
      {
         foreach (Screen screen in Screen.AllScreens)
         {
            if (x >= screen.Bounds.Left && y >= screen.Bounds.Top
                && x < screen.Bounds.Right && y < screen.Bounds.Bottom)
            {
               return screen;
            }
         }
         return null;
      }

      public static Screen? FindScreen( Control control )
      {
         return FindScreen( control.Left + control.Width / 2, control.Top + control.Height / 2 );
      }

   }

}
