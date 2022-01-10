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
   public partial class ControllerForm : Form
   {
      private bool suppressEvents;
      private Dragger dragger;

      struct ListRecord
      {
         public string label;
         public Clock clock;
         public override string ToString()
         {
            return label;
         }
      }

      public void RefreshClockList()
      {
         suppressEvents = true;
         GigList.Items.Clear();
         foreach (Clock c in Program.clockManager.GetClocks())
         {
            ListRecord record = new();
            if (c.name != "")
            {
               record.label = $"{c.name} - {c.GetTimestamp()}";
            }
            else
            {
               record.label = $"{c.GetTimestamp()}";
            }
            record.clock = c;
            var itemIndex = GigList.Items.Add(record);
            
            if (c == Program.clockManager.GetActiveClock())
            {
               GigList.SelectedIndex = itemIndex;
            }
         }

         RemoveGigButton.Enabled = Program.clockManager.GetClocks().Count > 1;

         suppressEvents = false;
      }

      public ControllerForm()
      {
         InitializeComponent();
         dragger = new(this, this);
      }

      private void AdjustPositionToOwner()
      {

         Screen? screen = Util.FindScreen(this);

         if (screen == null || Owner == null) return;

         if ((Top + Height / 2) < (screen.Bounds.Top + screen.Bounds.Bottom) / 2)
         {
            // Anchor to bottom
            Top = Owner.Bottom + 20;

         }
         else
         {
            // Anchor to top
            Top = Owner.Top - Height - 20;
         }
      }

      private void ControllerForm_Load(object sender, EventArgs e)
      {
         GigList.Focus();
         AdjustPositionToOwner();

         Program.clockManager.GetActiveClock().Stop();
         Program.clockManager.StartPause();
         UpdatePausedLabel();
         RefreshClockList();
      }

      private void ResumeButton_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void ControllerForm_FormClosed(object sender, FormClosedEventArgs e)
      {
         Program.clockManager.GetActiveClock().Start();
         Program.clockManager.StopPause();
      }

      private void AddGigButton_Click(object sender, EventArgs e)
      {
         EditForm editForm = new( "", "0" );
         editForm.Text = "Add Timer";
         DialogResult result = editForm.ShowDialog();
         if (result == DialogResult.Cancel) return;

         Clock clock = new(editForm.ResultName);
         clock.SetTime(editForm.ResultTime);

         // Add this lost time to the paused/misc timer.
         Clock paused = Program.clockManager.GetPause();
         paused.SetTime(paused.GetTime() - clock.GetTime());
         paused.Start();

         Program.clockManager.AddClock(clock);
         Program.clockManager.SetActiveClock(clock);
         UpdatePausedLabel();
         RefreshClockList();
         GigList.Focus();
      }

      private void GigList_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (suppressEvents) return;

         ListRecord record = (ListRecord)GigList.SelectedItem;
         Program.clockManager.SetActiveClock(record.clock);
         
      }

      private void RemoveGigButton_Click(object sender, EventArgs e)
      {
         if (Program.clockManager.GetActiveClock().GetTime() > 5000)
         {
            // Prompt them if this clock has more than 5 seconds on it.
            var result = MessageBox.Show("Are you sure?", "Remove Clock", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
               return;
            }
         }
         Clock activeClock = Program.clockManager.GetActiveClock();
         Program.clockManager.RemoveClock(activeClock);

         // Add this lost time to the paused/misc timer.
         Clock paused = Program.clockManager.GetPause();
         paused.SetTime(paused.GetTime() + activeClock.GetTime());
         paused.Start();
         UpdatePausedLabel();
         RefreshClockList();
         GigList.Focus();
      }

      private void SetTimeButton_Click(object sender, EventArgs e)
      {
         Clock c = Program.clockManager.GetActiveClock();
         EditForm editForm = new( c.name, c.GetTimestamp() );
         editForm.Text = "Edit Timer";
         DialogResult result = editForm.ShowDialog();
         if (result == DialogResult.Cancel) return;

         long newTime = editForm.ResultTime;
         string newName = editForm.ResultName;

         c.name = newName;
         long difference = newTime - c.GetTime();
         c.SetTime(newTime);

         Clock paused = Program.clockManager.GetPause();
         paused.SetTime(paused.GetTime() - difference);
         paused.Start();

         UpdatePausedLabel();
         RefreshClockList();
         GigList.Focus();
      }

      private void ControllerForm_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
         {
            Close();
         } 
         else if (e.KeyCode == Keys.E)
         {
            SetTimeButton.PerformClick();
         }
         else if (e.KeyCode == Keys.A )
         {
            AddGigButton.PerformClick();
         }

      }

      private void Config_Click(object sender, EventArgs e)
      {
         Program.config.OpenEditor();
      }

      private void ExitButton_Click(object sender, EventArgs e)
      {
         var result = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo);
         if (result == DialogResult.Yes)
         {
            Program.Exit();
         }
      }

      private void UpdatePausedLabel()
      {
         PausedLabel.Text = "Paused/Misc: " + Program.clockManager.GetPause().GetTimestamp();

      }

      private void PausedTimer_Tick(object sender, EventArgs e)
      {
         UpdatePausedLabel();
      }

      private void GigList_DoubleClick(object sender, EventArgs e)
      {
         Close();
      }

      private void ControllerForm_Shown(object sender, EventArgs e)
      {
         
      }
   }
}
