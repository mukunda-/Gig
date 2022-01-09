namespace Gig
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.TimeLabel = new System.Windows.Forms.Label();
         this.LineTexture = new System.Windows.Forms.Label();
         this.TickTimer = new System.Windows.Forms.Timer(this.components);
         this.SuspendLayout();
         // 
         // TimeLabel
         // 
         this.TimeLabel.Location = new System.Drawing.Point(0, 0);
         this.TimeLabel.Name = "TimeLabel";
         this.TimeLabel.Size = new System.Drawing.Size(146, 37);
         this.TimeLabel.TabIndex = 0;
         this.TimeLabel.Text = "0:00";
         this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         this.TimeLabel.Click += new System.EventHandler(this.TimeLabel_Click);
         this.TimeLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.TimeLabel_Paint);
         this.TimeLabel.DoubleClick += new System.EventHandler(this.TimeLabel_DoubleClick);
         // 
         // LineTexture
         // 
         this.LineTexture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.LineTexture.BackColor = System.Drawing.Color.White;
         this.LineTexture.Location = new System.Drawing.Point(0, 61);
         this.LineTexture.Name = "LineTexture";
         this.LineTexture.Size = new System.Drawing.Size(504, 2);
         this.LineTexture.TabIndex = 1;
         // 
         // TickTimer
         // 
         this.TickTimer.Enabled = true;
         this.TickTimer.Interval = 1000;
         this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Black;
         this.ClientSize = new System.Drawing.Size(198, 75);
         this.ControlBox = false;
         this.Controls.Add(this.LineTexture);
         this.Controls.Add(this.TimeLabel);
         this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.ForeColor = System.Drawing.Color.White;
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "Gig";
         this.TopMost = true;
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Shown += new System.EventHandler(this.MainForm_Shown);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
         this.ResumeLayout(false);

        }

        #endregion

        private Label TimeLabel;
        private Label LineTexture;
      private System.Windows.Forms.Timer TickTimer;
   }
}