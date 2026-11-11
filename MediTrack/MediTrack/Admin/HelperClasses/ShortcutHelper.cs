using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediTrack.Admin
{
    public static class ShortcutHelper
    {
        // Attach keyboard navigation (Up/Down arrows) to controls with custom navigation logic
        public static void AttachCustomKeyNavigation(Control control, Action<object, KeyEventArgs> keyDownHandler)
        {
            control.KeyDown += (s, e) => keyDownHandler(s, e);
        }

        // Attach function shortcuts (F1-F12, Escape, etc.)
        public static void AttachFunctionShortcuts(Form form,
            Action<object, EventArgs> onEscape,
            Action<object, EventArgs> onF1,
            Action<object, EventArgs> onF2,
            Action<object, EventArgs> onF3,
            Action<object, EventArgs> onF4)
            
        {
            form.KeyPreview = true;
            form.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    onEscape?.Invoke(s, e);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.F1)
                {
                    onF1?.Invoke(s, e);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.F2)
                {
                    onF2?.Invoke(s, e);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.F3)
                {
                    onF3?.Invoke(s, e);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.F4)
                {
                    onF4?.Invoke(s, e);
                    e.Handled = true;
                }
               
            };
        }

        // Setup tooltips for buttons
        public static void SetupTooltips(Control parent, params (Button button, string shortcut)[] buttonShortcuts)
        {
            var toolTip = new ToolTip { InitialDelay = 200, ShowAlways = true };
            foreach (var (button, shortcut) in buttonShortcuts)
            {
                toolTip.SetToolTip(button, shortcut);
            }
        }

        // Attach hover effect to button
        public static void AttachHoverEffect(Button btn, string defaultText, string shortcut)
        {
            Point originalLocation = btn.Location;
            btn.MouseEnter += (s, e) =>
            {
                btn.Text = $"{defaultText}\n({shortcut})";
                btn.Location = new Point(originalLocation.X, originalLocation.Y - 3);
                btn.Padding = new Padding(0, 0, 0, 6);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.Text = defaultText;
                btn.Location = originalLocation;
                btn.Padding = new Padding(0);
            };
        }
    }
}