using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gig
{
   public partial class EditForm : Form
   {
      public EditForm( string name, string time )
      {
         InitializeComponent();
         NameText.Text = name;
         TimeText.Text = time;
      }

      private void EditForm_Load(object sender, EventArgs e)
      {
         
      }

      public long ResultTime
      {
         get
         {
            return Clock.ParseTimestamp(TimeText.Text.Trim());
         }
      }

      public string ResultName
      {
         get
         {
            return NameText.Text.Trim();
         }
      }

      private void CancelButton_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void EditForm_KeyDown(object sender, KeyEventArgs e)
      {
         // Not sure why the CancelButton doesn't do this automatically.
         if (e.KeyCode == Keys.Escape)
         {
            Close();
         }
      }

      private void OKButton_Click(object sender, EventArgs e)
      {
         if (ResultTime < 0)
         {
            DialogResult = DialogResult.None;
            MessageBox.Show("Invalid time. Should be minutes or minutes:seconds.");
         }
      }
   }
}
