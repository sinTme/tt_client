using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TtClientApplication.com.tj.taotao.ui
{
    public partial class RegistForm : Form
    {
        private TTLabel accountLabel;

        private TTLabel identufyCodeLabel;

        private TTLabel pwdLabel;

        private TTLabel repeatePwdLabel;

        private TTTextBox accountTextBox;

        private TTTextBox identifyCodeTextBox;

        private TTTextBox pwdTextBox;

        private TTTextBox repeatePwdTextBox;

        private TTButton registBtn;

        private TTButton cancelBtn;

        private TTLinkLabel sendIndentifyCodeLabel;

        private Image accoutTextBoxImage;

        private Image pwdTextBoxImage;

        private Image identifyCodeTextBoxImage;

        private Image repeateTextBoxImage;

        private Image textBoxActiveImage;

        private Image textBoxNegativeImage;

        public RegistForm()
        {
            InitializeComponent();
            initializeFormStyle();
            initailize();

            accountLabel = new TTLabel();
            accountLabel.Text = "用 户 名：";
            accountLabel.TextAlign = ContentAlignment.MiddleRight;
            accountLabel.SetBounds(this.Width / 20, this.Height * 1 / 12, this.Width * 4 / 20, this.Height * 1 / 12);

            accountTextBox = new TTTextBox();
            accountTextBox.HintText = "请输入用户名";
            accountTextBox.SetBounds(this.Width / 4 + 5, this.Height * 1 / 12 + 5, this.Width / 2 - 10, this.Height * 1 / 12 - 10);

            identufyCodeLabel = new TTLabel();
            identufyCodeLabel.Text = "验 证 码：";
            identufyCodeLabel.TextAlign = ContentAlignment.MiddleRight;
            identufyCodeLabel.SetBounds(this.Width / 20, this.Height * 3 / 12, this.Width * 4 / 20, this.Height * 1 / 12);

            identifyCodeTextBox = new TTTextBox();
            identifyCodeTextBox.HintText = "请输入验证码";
            identifyCodeTextBox.SetBounds(this.Width / 4 + 5, this.Height * 3 / 12 + 5, this.Width / 2 - 10, this.Height * 1 / 12 - 10);

            sendIndentifyCodeLabel = new TTLinkLabel();
            sendIndentifyCodeLabel.Text = "发送验证码";
            sendIndentifyCodeLabel.TextAlign = ContentAlignment.MiddleCenter;
            sendIndentifyCodeLabel.SetBounds(this.Width * 3 / 4 + this.Width * 1 / 32, this.Height * 3 / 12, this.Width * 6 / 32, this.Height * 1 / 12);

            pwdLabel = new TTLabel();
            pwdLabel.Text = " 密     码：";
            pwdLabel.TextAlign = ContentAlignment.MiddleRight;
            pwdLabel.SetBounds(this.Width / 20, this.Height * 5 / 12, this.Width * 4 / 20, this.Height * 1 / 12);

            pwdTextBox = new TTTextBox();
            pwdTextBox.HintText = "请输入密码";
            pwdTextBox.SetBounds(this.Width / 4 + 5, this.Height * 5 / 12 + 5, this.Width / 2 - 10, this.Height * 1 / 12 - 10);

            repeatePwdLabel = new TTLabel();
            repeatePwdLabel.Text = "重复密码：";
            repeatePwdLabel.TextAlign = ContentAlignment.MiddleRight;
            repeatePwdLabel.SetBounds(this.Width / 20, this.Height * 7 / 12, this.Width * 4 / 20, this.Height * 1 / 12);

            repeatePwdTextBox = new TTTextBox();
            repeatePwdTextBox.HintText = "请输入密码：";
            repeatePwdTextBox.SetBounds(this.Width / 4 + 5, this.Height * 7 / 12 + 5, this.Width / 2 - 10, this.Height * 1 / 12 - 10);

            registBtn = new TTButton();
            registBtn.Text = "注  册";
            registBtn.SetBounds(this.Width / 4, this.Height * 9 / 12, this.Width * 7 / 32, this.Height * 1 / 12);
            registBtn.BackgroundImage = Properties.Resources.logbtn;
            registBtn.MouseHover += new EventHandler(btn_MouseHover);
            registBtn.MouseLeave += new EventHandler(btn_MouseLeave);

            cancelBtn = new TTButton();
            cancelBtn.Text = "取  消";
            cancelBtn.SetBounds(this.Width / 4 + this.Width * 9 / 32, this.Height * 9 / 12, this.Width * 7 / 32, this.Height * 1 / 12);
            cancelBtn.BackgroundImage = Properties.Resources.logbtn;
            cancelBtn.MouseHover += new EventHandler(btn_MouseHover);
            cancelBtn.MouseLeave += new EventHandler(btn_MouseLeave);

            this.Controls.Add(accountLabel);
            this.Controls.Add(accountTextBox);
            this.Controls.Add(identufyCodeLabel);
            this.Controls.Add(identifyCodeTextBox);

            this.Controls.Add(pwdLabel);
            this.Controls.Add(pwdTextBox);
            this.Controls.Add(repeatePwdLabel);
            this.Controls.Add(repeatePwdTextBox);

            this.Controls.Add(registBtn);
            this.Controls.Add(cancelBtn);

            this.Controls.Add(sendIndentifyCodeLabel);
        }

        private void initializeFormStyle()
        {
            this.BackColor = Color.White;

            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);

            base.UpdateStyles();
            base.AutoScaleMode = AutoScaleMode.None;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            drawImage(e);
            base.OnMouseMove(e);
        }

        public void drawImage(MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);

            if (accountTextBoxRect.Contains(point))
            {
                accoutTextBoxImage = textBoxActiveImage;
            }
            else
            {
                this.accoutTextBoxImage = textBoxNegativeImage;
            }

            if (pwdTextBoxRect.Contains(point))
            {
                pwdTextBoxImage = textBoxActiveImage;
            }
            else
            {
                this.pwdTextBoxImage = textBoxNegativeImage;
            }

            if (identifyCodeTextBoxRect.Contains(point))
            {
                identifyCodeTextBoxImage = textBoxActiveImage;
            }
            else
            {
                identifyCodeTextBoxImage = textBoxNegativeImage;
            }

            if (repeatePwdTextBoxRect.Contains(point))
            {
                repeateTextBoxImage = textBoxActiveImage;
            }
            else
            {
                repeateTextBoxImage = textBoxNegativeImage;
            }

            this.Invalidate(accountTextBoxRect);
            this.Invalidate(pwdTextBoxRect);
            this.Invalidate(identifyCodeTextBoxRect);
            this.Invalidate(repeatePwdTextBoxRect);
        }


        private void btn_MouseHover(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources.logbtn2;
        }
        private void btn_MouseLeave(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Properties.Resources.logbtn;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            drawBackGroundImage(e.Graphics);
        }

        public void drawBackGroundImage(Graphics g)
        {
            ImageAttributes ImgAtt = new ImageAttributes();
            ImgAtt.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);

            g.DrawImage(this.accoutTextBoxImage, accountTextBoxRect, 0, 0, this.accoutTextBoxImage.Width, this.accoutTextBoxImage.Height, GraphicsUnit.Pixel, ImgAtt);
            g.DrawImage(this.pwdTextBoxImage, pwdTextBoxRect, 0, 0, this.pwdTextBoxImage.Width, this.pwdTextBoxImage.Height, GraphicsUnit.Pixel, ImgAtt);
            g.DrawImage(this.identifyCodeTextBoxImage, identifyCodeTextBoxRect, 0, 0, this.identifyCodeTextBoxImage.Width, this.identifyCodeTextBoxImage.Height, GraphicsUnit.Pixel, ImgAtt);
            g.DrawImage(this.repeateTextBoxImage, repeatePwdTextBoxRect, 0, 0, this.repeateTextBoxImage.Width, this.repeateTextBoxImage.Height, GraphicsUnit.Pixel, ImgAtt);

        }

        private void initailize()
        {
            this.textBoxNegativeImage = Properties.Resources.text;
            this.textBoxActiveImage = Properties.Resources.text2;
            this.accoutTextBoxImage = textBoxActiveImage;
            this.pwdTextBoxImage = textBoxNegativeImage;
            this.identifyCodeTextBoxImage = textBoxNegativeImage;
            this.repeateTextBoxImage = textBoxNegativeImage;

            
            this.accountTextBoxRect = new Rectangle(this.Width / 4, this.Height * 1 / 12, this.Width / 2, this.Height * 1 / 12);
            this.identifyCodeTextBoxRect = new Rectangle(this.Width / 4, this.Height * 3 / 12, this.Width / 2, this.Height * 1 / 12);
            this.pwdTextBoxRect = new Rectangle(this.Width / 4, this.Height * 5 / 12, this.Width / 2, this.Height * 1 / 12);
            this.repeatePwdTextBoxRect = new Rectangle(this.Width / 4, this.Height * 7 / 12, this.Width / 2, this.Height * 1 / 12);

        }

        private Rectangle accountTextBoxRect = Rectangle.Empty;
        private Rectangle identifyCodeTextBoxRect = Rectangle.Empty;
        private Rectangle pwdTextBoxRect = Rectangle.Empty;
        private Rectangle repeatePwdTextBoxRect = Rectangle.Empty;

    }
}
