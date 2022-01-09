namespace Gig
{
   partial class ControllerForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
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
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerForm));
         this.GigList = new System.Windows.Forms.ListBox();
         this.AddGigButton = new System.Windows.Forms.Button();
         this.RemoveGigButton = new System.Windows.Forms.Button();
         this.ResumeButton = new System.Windows.Forms.Button();
         this.SetTimeButton = new System.Windows.Forms.Button();
         this.ExitButton = new System.Windows.Forms.Button();
         this.Config = new System.Windows.Forms.Button();
         this.PausedLabel = new System.Windows.Forms.Label();
         this.PausedTimer = new System.Windows.Forms.Timer(this.components);
         this.SuspendLayout();
         // 
         // GigList
         // 
         this.GigList.FormattingEnabled = true;
         this.GigList.ItemHeight = 12;
         this.GigList.Location = new System.Drawing.Point(8, 9);
         this.GigList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.GigList.Name = "GigList";
         this.GigList.Size = new System.Drawing.Size(122, 136);
         this.GigList.TabIndex = 0;
         this.GigList.SelectedIndexChanged += new System.EventHandler(this.GigList_SelectedIndexChanged);
         this.GigList.DoubleClick += new System.EventHandler(this.GigList_DoubleClick);
         // 
         // AddGigButton
         // 
         this.AddGigButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.AddGigButton.Location = new System.Drawing.Point(134, 31);
         this.AddGigButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.AddGigButton.Name = "AddGigButton";
         this.AddGigButton.Size = new System.Drawing.Size(60, 23);
         this.AddGigButton.TabIndex = 2;
         this.AddGigButton.Text = "Add (A)";
         this.AddGigButton.UseVisualStyleBackColor = true;
         this.AddGigButton.Click += new System.EventHandler(this.AddGigButton_Click);
         // 
         // RemoveGigButton
         // 
         this.RemoveGigButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.RemoveGigButton.Location = new System.Drawing.Point(134, 54);
         this.RemoveGigButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.RemoveGigButton.Name = "RemoveGigButton";
         this.RemoveGigButton.Size = new System.Drawing.Size(60, 23);
         this.RemoveGigButton.TabIndex = 3;
         this.RemoveGigButton.Text = "Remove";
         this.RemoveGigButton.UseVisualStyleBackColor = true;
         this.RemoveGigButton.Click += new System.EventHandler(this.RemoveGigButton_Click);
         // 
         // ResumeButton
         // 
         this.ResumeButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.ResumeButton.Location = new System.Drawing.Point(134, 8);
         this.ResumeButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ResumeButton.Name = "ResumeButton";
         this.ResumeButton.Size = new System.Drawing.Size(60, 23);
         this.ResumeButton.TabIndex = 1;
         this.ResumeButton.Text = "Play (Esc)";
         this.ResumeButton.UseVisualStyleBackColor = true;
         this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
         // 
         // SetTimeButton
         // 
         this.SetTimeButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.SetTimeButton.Location = new System.Drawing.Point(134, 77);
         this.SetTimeButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.SetTimeButton.Name = "SetTimeButton";
         this.SetTimeButton.Size = new System.Drawing.Size(60, 23);
         this.SetTimeButton.TabIndex = 4;
         this.SetTimeButton.Text = "Edit (E)";
         this.SetTimeButton.UseVisualStyleBackColor = true;
         this.SetTimeButton.Click += new System.EventHandler(this.SetTimeButton_Click);
         // 
         // ExitButton
         // 
         this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.ExitButton.Location = new System.Drawing.Point(134, 123);
         this.ExitButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.ExitButton.Name = "ExitButton";
         this.ExitButton.Size = new System.Drawing.Size(60, 23);
         this.ExitButton.TabIndex = 6;
         this.ExitButton.Text = "Exit";
         this.ExitButton.UseVisualStyleBackColor = true;
         this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
         // 
         // Config
         // 
         this.Config.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.Config.Location = new System.Drawing.Point(134, 100);
         this.Config.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.Config.Name = "Config";
         this.Config.Size = new System.Drawing.Size(60, 23);
         this.Config.TabIndex = 5;
         this.Config.Text = "Config";
         this.Config.UseVisualStyleBackColor = true;
         this.Config.Click += new System.EventHandler(this.Config_Click);
         // 
         // PausedLabel
         // 
         this.PausedLabel.AutoSize = true;
         this.PausedLabel.ForeColor = System.Drawing.Color.White;
         this.PausedLabel.Location = new System.Drawing.Point(8, 151);
         this.PausedLabel.Name = "PausedLabel";
         this.PausedLabel.Size = new System.Drawing.Size(11, 12);
         this.PausedLabel.TabIndex = 7;
         this.PausedLabel.Text = "...";
         // 
         // PausedTimer
         // 
         this.PausedTimer.Enabled = true;
         this.PausedTimer.Interval = 1000;
         this.PausedTimer.Tick += new System.EventHandler(this.PausedTimer_Tick);
         // 
         // ControllerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Crimson;
         this.ClientSize = new System.Drawing.Size(201, 169);
         this.Controls.Add(this.PausedLabel);
         this.Controls.Add(this.Config);
         this.Controls.Add(this.ExitButton);
         this.Controls.Add(this.SetTimeButton);
         this.Controls.Add(this.ResumeButton);
         this.Controls.Add(this.RemoveGigButton);
         this.Controls.Add(this.AddGigButton);
         this.Controls.Add(this.GigList);
         this.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.KeyPreview = true;
         this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ControllerForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Gig";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControllerForm_FormClosed);
         this.Load += new System.EventHandler(this.ControllerForm_Load);
         this.Shown += new System.EventHandler(this.ControllerForm_Shown);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControllerForm_KeyDown);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private ListBox GigList;
      private Button AddGigButton;
      private Button RemoveGigButton;
      private Button ResumeButton;
      private Button SetTimeButton;
      private Button ExitButton;
      private Button Config;
      private Label PausedLabel;
      private System.Windows.Forms.Timer PausedTimer;
   }
}