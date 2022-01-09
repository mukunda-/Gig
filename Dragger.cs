using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig
{
   internal class Dragger
   {
      Form parent;
      Control control;
      Screen? lastScreen;

      private Point dragStart;
      private Point dragOrigin;
      private bool  dragActive;

      public Dragger( Form parent, Control control )
      {
         this.parent  = parent;
         this.control = control;
         control.MouseDown += new System.Windows.Forms.MouseEventHandler(OnMouseDown);
         control.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseMove);
         control.MouseUp   += new System.Windows.Forms.MouseEventHandler(OnMouseUp);
      }

      private void OnMouseDown(object? sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            dragActive = true;
            dragOrigin = new Point(parent.Left, parent.Top);
            dragStart  = Form.MousePosition;
         }
      }

      private (int, int) ClampToScreen( int left, int top )
      {
         int middleX = left + parent.Width / 2;
         int middleY = top + parent.Height / 2;
         Screen? screen = Util.FindScreen(middleX, middleY) ?? lastScreen;
         if (screen == null) return (left, top);
         lastScreen = screen;

         int right = left + parent.Width;
         int bottom = top + parent.Height;

         // This is our screen. Clamp to this area.
         if (left < screen.Bounds.Left)
         {
            left += screen.Bounds.Left - left;
         }
         else if (right > screen.Bounds.Right)
         {
            left -= right - screen.Bounds.Right;
         }

         if (top < screen.Bounds.Top)
         {
            top += screen.Bounds.Top - top;
         }
         else if (bottom > screen.Bounds.Bottom)
         {
            top -= bottom - screen.Bounds.Bottom;
         }

         return (left, top);
      }

      private void OnMouseMove(object? sender, MouseEventArgs e)
      {
         if (dragActive)
         {
            int offsetX, offsetY;
            (offsetX, offsetY) = (
               Control.MousePosition.X - dragStart.X,
               Control.MousePosition.Y - dragStart.Y);
            
            int left = dragOrigin.X + offsetX;
            int top  = dragOrigin.Y + offsetY;
            (left, top) = ClampToScreen(left, top);
            parent.Left = left;
            parent.Top = top;
         }
      }

      private void OnMouseUp(object? sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            dragActive = false;
         }
      }

   }
}
