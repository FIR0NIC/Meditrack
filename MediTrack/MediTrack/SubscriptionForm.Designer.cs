namespace MediTrack
{
    partial class SubscriptionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Subscirption Form 
            this.Text = "Subscription Offers";
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(220, 230, 240);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);

            // Title 
            var lblTitle = new System.Windows.Forms.Label
            {
                Text = "Subscription Offers",
                Font = new System.Drawing.Font("Segoe UI", 15f, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(30, 45, 61),
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Bounds = new System.Drawing.Rectangle(0, 16, 900, 36),
                BackColor = System.Drawing.Color.Transparent,
            };
          
            // Card layout
            int cardW = 260;
            int cardH = 400;
            int cardTop = 88;
            int gap = 30;
            int startX = 30;

            int col1 = startX;
            int col2 = startX + cardW + gap;
            int col3 = startX + cardW + gap + cardW + gap;

            var cardBasic = BuildCard(
                "Basic/Free Tier", "FREE",
                System.Drawing.Color.FromArgb(191, 205, 219),
                System.Drawing.Color.FromArgb(142, 193, 235),
                new string[] { "1 Company Branch Only", "3 Months Free Trial", "Limited Auditing & Business Statistics", "Limited Settings"},
                new System.Drawing.Rectangle(col1, cardTop, cardW, cardH),
                out var btnBuyBasic);

            var cardStandard = BuildCard(
                "Standard Tier", "₱???",
                System.Drawing.Color.FromArgb(191, 205, 219),
                System.Drawing.Color.FromArgb(70, 130, 180),
                new string[] { "Multi Branch Support", "Unlimited Auditing & Business Statistics", "Expanded Settings", "Offline Mode" },
                new System.Drawing.Rectangle(col2, cardTop, cardW, cardH),
                out var btnBuyStandard);

            var cardPremium = BuildCard(
                "Premium Tier", "₱???",
                System.Drawing.Color.FromArgb(191, 205, 219),
                System.Drawing.Color.FromArgb(30, 58, 82),
                new string[] { "Multi Branch Support", "Unlimited Auditing & Business Statistics", "Expanded Settings", "Faster Database", "Offline Mode" },
                new System.Drawing.Rectangle(col3, cardTop, cardW, cardH),
                out var btnBuyPremium);

            btnBuyBasic.Click += btnBuyBasic_Click;
            btnBuyStandard.Click += btnBuyStandard_Click;
            btnBuyPremium.Click += btnBuyPremium_Click;

            this.Controls.Add(lblTitle);          
            this.Controls.Add(cardBasic);
            this.Controls.Add(cardStandard);
            this.Controls.Add(cardPremium);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel BuildCard(
            string planName, string price,
            System.Drawing.Color cardColor,
            System.Drawing.Color accentColor,
            string[] features,
            System.Drawing.Rectangle bounds,
            out PillButton buyButton)
        {
            var card = new RoundedPanel
            {
                Bounds = bounds,
                BackColor = cardColor,
                CornerRadius = 18,
            };

            int cw = bounds.Width;

            // Price badge
            int bW = 120, bH = 34;
            var badge = new System.Windows.Forms.Label
            {
                Text = price,
                Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                BackColor = accentColor,
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Bounds = new System.Drawing.Rectangle((cw - bW) / 2, 8, bW, bH),
                UseCompatibleTextRendering = true,
            };

            badge.Region = new System.Drawing.Region(
    GetRoundedRect(new System.Drawing.Rectangle(0, 0, bW, bH), 10));
            card.Controls.Add(badge);

            // Plan name
            var lblPlan = new System.Windows.Forms.Label
            {
                Text = planName,
                Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(12, 30, 46),
                BackColor = System.Drawing.Color.Transparent,
                AutoSize = false,
                Bounds = new System.Drawing.Rectangle(16, 50, cw - 32, 30),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
            };
            card.Controls.Add(lblPlan);

            // Divider line
            var div = new System.Windows.Forms.Panel
            {
                Bounds = new System.Drawing.Rectangle(16, 84, cw - 32, 2),
                BackColor = System.Drawing.Color.FromArgb(160, 180, 196),
            };
            card.Controls.Add(div);

            // Feature list
            int top = 94;
            foreach (var f in features)
            {
                var lbl = new System.Windows.Forms.Label
                {
                    Text = "• " + f,
                    Font = new System.Drawing.Font("Segoe UI", 10f),
                    ForeColor = System.Drawing.Color.FromArgb(12, 30, 46),
                    BackColor = System.Drawing.Color.Transparent,
                    AutoSize = false,
                    Bounds = new System.Drawing.Rectangle(18, top, cw - 32, 26),
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                };
                card.Controls.Add(lbl);
                top += 28;
            }

            // Upgrade button 
            var btn = new PillButton
            {
                Text = "Upgrade for " + price,
                Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                BackColor = accentColor,
                Bounds = new System.Drawing.Rectangle(16, bounds.Height - 56, cw - 32, 40),
                UseVisualStyleBackColor = false,
                TabStop = false,
            };
            card.Controls.Add(btn);
            buyButton = btn;

            return card;
        }
    }
}
