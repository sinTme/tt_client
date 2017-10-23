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
using TtClientApplication.com.tj.taotao.ui;

namespace TtClientApplication
{
    public partial class LoginForm : Form
    {
        // 关闭按钮图标
        private Image CloseImage;

        // logo图标
        private Image LogoImage;

        // 用户名Label
        private TTLabel accountLabel;

        // 密码Label
        private TTLabel pwdLabel;

        // 账号输入框背景
        private Image AccountTextBoxImage;

        // 密码输入框背景
        private Image PwdTextBoxImage;

        // 选中或鼠标移上时背景框
        private Image TextBoxImageActive;

        // 鼠标离开后背景框
        private Image TextBoxImageNagetive;

        // 账户图标
        private Image AccountImage;

        // 密码图标
        private Image PwdImage;

        // 用户输入框
        private TTTextBox accountTextBox;

        // 密码输入框
        private TTTextBox pwdTextBox;

        // 注册超链接
        private TTLinkLabel registLinkLabel;

        // 找回密码超链接
        private TTLinkLabel findBackPwdLabel;

        // 记住密码勾选框
        private TTCheckBox remenberPwdBox;

        // 开机自动登录勾选框
        private TTCheckBox autoLoginBox;

        // 登录按钮
        private TTButton loginButton;

        public LoginForm()
        {
            InitializeComponent();
            initializeImage();
            initializeFormStyle();

            // 用户名Label
            accountLabel = new TTLabel();
            accountLabel.Text = "用户名 ：";
            accountLabel.SetBounds(this.Width / 20, this.Height * 6 / 16, this.Width * 3 / 20, this.Height * 2 / 16);
            accountLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 用户名输入框
            accountTextBox = new TTTextBox();
            accountTextBox.HintText = "请输入账号";
            accountTextBox.SetBounds(this.Width / 4 + this.Width * 3 / 32, this.Height * 6 / 16 + this.Height * 1 / 32, this.Width / 2 - this.Width * 3 / 32 - 1, this.Height * 1 / 16);

            // 账号注册超链接
            registLinkLabel = new TTLinkLabel();
            registLinkLabel.Text = "注册账号";
            registLinkLabel.TextAlign = ContentAlignment.MiddleCenter;
            registLinkLabel.SetBounds(this.Width * 4 / 5, this.Height * 6 / 16, this.Width * 3 / 20, this.Height * 2 / 16);
            registLinkLabel.Click += new EventHandler(regesit_label_clicked);

            // 密码Label
            pwdLabel = new TTLabel();
            pwdLabel.Text = "密 码 ：";
            pwdLabel.SetBounds(this.Width / 20, this.Height * 8 / 16 + this.Height / 32, this.Width * 3 / 20, this.Height * 2 / 16);
            pwdLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 密码输入框
            pwdTextBox = new TTTextBox();
            pwdTextBox.HintText = "请输入密码";
            pwdTextBox.SetBounds(this.Width * 4 / 16 + this.Width * 3 / 32, this.Height * 9 / 16, this.Width * 10 / 20 - this.Width * 3 / 32 - 1, this.Height * 1 / 16);
            pwdTextBox.PasswordChar = '*';

            // 找回密码超链接
            findBackPwdLabel = new TTLinkLabel();
            findBackPwdLabel.Text = "找回密码";
            findBackPwdLabel.TextAlign = ContentAlignment.MiddleCenter;
            findBackPwdLabel.SetBounds(this.Width * 16 / 20, this.Height * 8 / 16 + this.Height / 32, this.Width * 3 / 20, this.Height * 2 / 16);

            // 记住密码
            remenberPwdBox = new TTCheckBox();
            remenberPwdBox.SetBounds(this.Width * 4 / 16, this.Height * 11 / 16, this.Width * 4 / 20, this.Height * 2 / 16);
            remenberPwdBox.Text = "记住密码";

            // 开机自动登录
            autoLoginBox = new TTCheckBox();
            autoLoginBox.SetBounds(this.Width * 10 / 20, this.Height * 11 / 16, this.Width * 4 / 16, this.Height * 2 / 16);
            autoLoginBox.Text = "开机自动登录";

            // 登录按钮
            loginButton = new TTButton();
            loginButton.Text = "登 录";
            loginButton.SetBounds(this.Width * 5 / 20, this.Height * 13 / 16 + this.Height / 32, this.Width * 10 / 20, this.Height * 2 / 16);
            loginButton.BackgroundImage = Properties.Resources.logbtn;
            loginButton.MouseHover += new EventHandler(btn_MouseHover);
            loginButton.MouseLeave += new EventHandler(btn_MouseLeave);

            this.Controls.Add(accountLabel);
            this.Controls.Add(registLinkLabel);
            this.Controls.Add(accountTextBox);

            this.Controls.Add(pwdLabel);
            this.Controls.Add(pwdTextBox);
            this.Controls.Add(findBackPwdLabel);

            this.Controls.Add(remenberPwdBox);
            this.Controls.Add(autoLoginBox);
            this.Controls.Add(loginButton);
            
        }

        public void initializeFormStyle()
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

        private void initializeImage()
        {
            this.LogoImage = Properties.Resources.logo1;
            this.CloseImage = Properties.Resources.close;
            this.TextBoxImageNagetive = Properties.Resources.text;
            this.TextBoxImageActive = Properties.Resources.text2;
            this.AccountImage = Properties.Resources.account;
            this.PwdImage = Properties.Resources.password;

            this.AccountTextBoxImage = TextBoxImageActive;
            this.PwdTextBoxImage = TextBoxImageNagetive;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            accountTextBox.Focus();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawLogo(e.Graphics);

        }

        public void regesit_label_clicked(object sender, EventArgs e)
        {
            this.Hide();
            RegistForm registForm = new RegistForm();
            registForm.Parent = this;
            registForm.Show();
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

        private void DrawLogo(Graphics g)
        {
            ImageAttributes ImgAtt = new ImageAttributes();
            ImgAtt.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
            if (this.LogoImage != null)
            {
                Rectangle logoRect = new Rectangle(this.Width * 3 / 8, this.Height / 16, this.Width * 5 / 20, this.Height * 4 / 16);
                g.DrawImage(this.LogoImage, logoRect, 0, 0, this.LogoImage.Width, this.LogoImage.Height, GraphicsUnit.Pixel, ImgAtt);
            }

            if (this.CloseImage != null)
            {
                closeRect = new Rectangle(this.Width - 20, 15, 10, 10);
                g.DrawImage(this.CloseImage, closeRect, 0, 0, this.CloseImage.Width, this.CloseImage.Height, GraphicsUnit.Pixel, ImgAtt);
            }

            if (this.AccountTextBoxImage != null)
            {
                accountRect = new Rectangle(this.Width / 4, this.Height * 6 / 16, this.Width / 2, this.Height * 2 / 16);
                g.DrawImage(this.AccountTextBoxImage, accountRect, 0, 0, this.AccountTextBoxImage.Width, this.AccountTextBoxImage.Height, GraphicsUnit.Pixel, ImgAtt);
            }

            if (this.PwdTextBoxImage != null)
            {
                pwdRect = new Rectangle(this.Width * 4 / 16, this.Height * 8 / 16 + this.Height / 32, this.Width * 10 / 20, this.Height * 2 / 16);
                g.DrawImage(this.PwdTextBoxImage, pwdRect, 0, 0, this.PwdTextBoxImage.Width, this.PwdTextBoxImage.Height, GraphicsUnit.Pixel, ImgAtt);
            }
            if (this.AccountImage != null)
            {
                Rectangle r = new Rectangle(this.Width / 4 + this.Width * 3 / 32 / 5, this.Height * 6 / 16 + this.Height / 32, this.Width * 3 / 32 * 4 / 5 , this.Height * 2 / 16 - this.Height * 3 / 64);
                g.DrawImage(this.AccountImage, r, 0, 0, this.AccountImage.Width, this.AccountImage.Height, GraphicsUnit.Pixel, ImgAtt);
            }

            if (this.PwdImage != null)
            {
                Rectangle r = new Rectangle(this.Width / 4 + this.Width * 3 / 32 / 5, this.Height * 8 / 16 + this.Height * 2/ 32, this.Width * 3 / 32 * 4 / 5, this.Height * 2 / 16 - this.Height * 3 / 64);
                g.DrawImage(this.PwdImage, r, 0, 0, this.PwdImage.Width, this.PwdImage.Height, GraphicsUnit.Pixel, ImgAtt);
            }

        }

        private Rectangle closeRect = Rectangle.Empty;
        private Rectangle loginRect = Rectangle.Empty;
        private Rectangle accountRect = Rectangle.Empty;
        private Rectangle pwdRect = Rectangle.Empty;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            if (closeRect.Contains(point))
            {
                this.CloseImage = Properties.Resources.close2;
            }
            else
            {
                this.CloseImage = Properties.Resources.close;
            }

            if (accountRect.Contains(point))
            {
                this.AccountTextBoxImage = TextBoxImageActive;
            }
            else
            {
                this.AccountTextBoxImage = TextBoxImageNagetive;
            }

            if (pwdRect.Contains(point))
            {
                this.PwdTextBoxImage = TextBoxImageActive;
            }
            else
            {
                this.PwdTextBoxImage = TextBoxImageNagetive;
            }
            this.Invalidate(closeRect);
            this.Invalidate(accountRect);
            this.Invalidate(pwdRect);
            base.OnMouseMove(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (closeRect.Contains(p))
            {
                this.Close();
                this.Dispose();
            }
            base.OnMouseClick(e);
        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }
    }
}
