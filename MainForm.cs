namespace Gig
{
   public partial class MainForm : Form
   {
      private Dragger dragger;

      public MainForm()
      {
         InitializeComponent();
         dragger = new(this, TimeLabel);
      }

      public void OpenMenu()
      {
         UpdateDisplay();
         TopMost = false;
         new ControllerForm().ShowDialog(this);
         UpdateDisplay();
         TopMost = true;
      }

      private void TimeLabel_Click(object sender, EventArgs e)
      {
         if (((MouseEventArgs)e).Button == MouseButtons.Right) OpenMenu();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Width = 120;
         Height = 30;
         LineTexture.Height = 2;
         LineTexture.Top = Height - 2;
         LineTexture.Left = 0;
         TimeLabel.Top = -1;
         TimeLabel.Left = 0;
         TimeLabel.Width = Width;
         TimeLabel.Height = Height;
         Program.clockManager.ClockChanged += OnClockChanged;
      }

      public void UpdateTimeLabel(int seconds)
      {
         Clock c = Program.clockManager.GetActiveClock();
         if (c.name != "")
         {
            TimeLabel.Text = $"{c.name} • {c.GetTimestamp()}";
         }
         else
         {
            TimeLabel.Text = c.GetTimestamp();
         }
         
      }

      public void UpdateLine(int seconds)
      {
         if (Program.config.GetLongestSLAPeriod() == 0)
         {
            LineTexture.Hide();
            return;
         } else
         {
            LineTexture.Show();
         }

         var delta = (double)seconds / Program.config.GetLongestSLAPeriod();

         delta = Math.Clamp(1.0 - delta, 0.0, 1.0);
         LineTexture.Width = (int)(Width * delta);
      }

      public void UpdateBackground(int seconds)
      {
         Color background = Program.config.defaultColor;
         foreach( Config.SLA sla in Program.config.slas )
         {
            if (seconds >= sla.period)
            {
               background = sla.color;
            }
         }
         BackColor = background;
      }

      //----------------------------------------------------------------------------------
      private void SynchronizeTimer(int nextTickSeconds)
      {
         Clock c = Program.clockManager.GetActiveClock();
         TickTimer.Enabled = false;

         double desiredInterval = nextTickSeconds * 1000 - c.GetTime();
         desiredInterval = Math.Clamp(desiredInterval, 100.0, 1100.0);

         TickTimer.Interval = (int)desiredInterval;
         TickTimer.Enabled = true;
      }

      //----------------------------------------------------------------------------------
      public void UpdateDisplay()
      {
         Clock c = Program.clockManager.GetActiveClock();
         int seconds = (int)Math.Round(c.GetTime() / 1000.0);
         UpdateTimeLabel(seconds);
         UpdateLine(seconds);
         UpdateBackground(seconds);
         SynchronizeTimer(seconds + 1);
      }

      /*
      {
         Clock c = Program.clockManager.GetActiveClock();
         double millis = (double)c.GetTime();
         millis = millis / 1000;
         double nextTick = Math.Ceiling(millis);


         int seconds = (int)Math.Round(c.GetTime() / 1000.0);
      }*/

      private void TickTimer_Tick(object sender, EventArgs e)
      {
         UpdateDisplay();
      }
      private void OnClockChanged(object sender, EventArgs e)
      {
         UpdateDisplay();
      }

      private void TimeLabel_DoubleClick(object sender, EventArgs e)
      {
         if (((MouseEventArgs)e).Button == MouseButtons.Left) OpenMenu();
      }

      private void MainForm_Shown(object sender, EventArgs e)
      {
         OpenMenu();
      }

      private void MainForm_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            OpenMenu();
         }
      }

      private void MainForm_Paint(object sender, PaintEventArgs e)
      {
      }

      private void TimeLabel_Paint(object sender, PaintEventArgs e)
      {
         Pen pen = new(Color.FromArgb(
            Math.Min((int)(BackColor.R * 1.4), 255),
            Math.Min((int)(BackColor.G * 1.4), 255),
            Math.Min((int)(BackColor.B * 1.4), 255)));
         e.Graphics.DrawRectangle(pen, new Rectangle(0, 1, Width - 1, Height - 2));

      }
   }
}