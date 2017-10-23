using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TtClientApplication.com.tj.taotao.ui
{
    class TTTextBox : TextBox
    {
        private string hintText;

        public String HintText
        {
            get { return hintText; }
            set
            {
                hintText = value;
                base.Invalidate();
            }
        }

        public TTTextBox()
        {
            //SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();

            this.AutoSize = false;
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.Transparent;
            this.Font = ControlStyleUtil.defaultFont;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT || m.Msg == WM_CTLCOLOREDIT)
            {
                WmPaint(ref m);
            }
        }

        private void WmPaint(ref Message m)
        {
            Graphics g = Graphics.FromHwnd(base.Handle);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (Text.Length == 0 && !string.IsNullOrEmpty(hintText) && !Focused)
            {
                TextRenderer.DrawText(g, hintText, Font, ClientRectangle, Color.Gray, TextFormatFlags.Left);
            }
        }

        public const int WM_PAINT = 0xF;
        public const int WM_CTLCOLOREDIT = 0x133;
    }
}
