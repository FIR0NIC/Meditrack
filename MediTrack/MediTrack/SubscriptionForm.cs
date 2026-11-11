using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MediTrack
{
    public partial class SubscriptionForm : Form
    {
        public SubscriptionForm()
        {
            InitializeComponent();
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using var brush = new SolidBrush(Color.FromArgb(220, 230, 240));
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnBuyBasic_Click(object sender, EventArgs e)    { /* TODO */ }
        private void btnBuyStandard_Click(object sender, EventArgs e) { /* TODO */ }
        private void btnBuyPremium_Click(object sender, EventArgs e)  { /* TODO */ }

        public static GraphicsPath GetRoundedRect(Rectangle r, int radius)
        {
            int d    = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X,         r.Y,          d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y,          d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d,   0, 90);
            path.AddArc(r.X,         r.Bottom - d, d, d,  90, 90);
            path.CloseFigure();
            return path;
        }
    }

    // Rounded card panel
    public class RoundedPanel : Panel
    {
        public int   CornerRadius { get; set; } = 18;
        public Color BorderColor  { get; set; } = Color.Transparent;

        public RoundedPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                          ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var r    = new Rectangle(1, 1, Width - 2, Height - 2);
            var path = SubscriptionForm.GetRoundedRect(r, CornerRadius);

            using var shadow = new SolidBrush(Color.FromArgb(20, 0, 0, 0));
            e.Graphics.FillPath(shadow,
                SubscriptionForm.GetRoundedRect(new Rectangle(3, 5, Width - 2, Height - 2), CornerRadius));

            using var fill = new SolidBrush(BackColor);
            e.Graphics.FillPath(fill, path);

            if (BorderColor != Color.Transparent)
            {
                using var pen = new Pen(BorderColor, 1.5f);
                e.Graphics.DrawPath(pen, path);
            }

            this.Region = new Region(path);
            base.OnPaint(e);
        }
    }

    // Pill-shaped button
    public class PillButton : Button
    {
        public PillButton()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var r    = new Rectangle(0, 0, Width - 1, Height - 1);
            var path = SubscriptionForm.GetRoundedRect(r, Height / 2);

            using var fill = new SolidBrush(BackColor);
            e.Graphics.FillPath(fill, path);

            using var sf = new StringFormat
            {
                Alignment     = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            using var brush = new SolidBrush(ForeColor);
            e.Graphics.DrawString(Text, Font, brush,
                new RectangleF(0, 0, Width, Height), sf);

            this.Region = new Region(path);
        }
    }
}
