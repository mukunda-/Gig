namespace Gig
{
   partial class EditForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
         this.label1 = new System.Windows.Forms.Label();
         this.NameText = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.TimeText = new System.Windows.Forms.TextBox();
         this.OKButton = new System.Windows.Forms.Button();
         this.MyCancelButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(39, 15);
         this.label1.TabIndex = 0;
         this.label1.Text = "Name";
         // 
         // NameText
         // 
         this.NameText.Location = new System.Drawing.Point(12, 27);
         this.NameText.Name = "NameText";
         this.NameText.Size = new System.Drawing.Size(156, 23);
         this.NameText.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 53);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(33, 15);
         this.label2.TabIndex = 2;
         this.label2.Text = "Time";
         // 
         // TimeText
         // 
         this.TimeText.Location = new System.Drawing.Point(12, 71);
         this.TimeText.Name = "TimeText";
         this.TimeText.Size = new System.Drawing.Size(156, 23);
         this.TimeText.TabIndex = 3;
         this.TimeText.Text = "0:00";
         // 
         // OKButton
         // 
         this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.OKButton.Location = new System.Drawing.Point(12, 100);
         this.OKButton.Name = "OKButton";
         this.OKButton.Size = new System.Drawing.Size(75, 23);
         this.OKButton.TabIndex = 4;
         this.OKButton.Text = "Save";
         this.OKButton.UseVisualStyleBackColor = true;
         this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
         // 
         // MyCancelButton
         // 
         this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.MyCancelButton.Location = new System.Drawing.Point(93, 100);
         this.MyCancelButton.Name = "MyCancelButton";
         this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
         this.MyCancelButton.TabIndex = 5;
         this.MyCancelButton.Text = "Cancel";
         this.MyCancelButton.UseVisualStyleBackColor = true;
         this.MyCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
         // 
         // EditForm
         // 
         this.AcceptButton = this.OKButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(181, 135);
         this.Controls.Add(this.MyCancelButton);
         this.Controls.Add(this.OKButton);
         this.Controls.Add(this.TimeText);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.NameText);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.KeyPreview = true;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EditForm";
         this.Text = "Edit Timer";
         this.Load += new System.EventHandler(this.EditForm_Load);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditForm_KeyDown);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private TextBox NameText;
      private Label label2;
      private TextBox TimeText;
      private Button OKButton;
      private Button MyCancelButton;
   }
}