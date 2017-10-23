namespace TtClientApplication
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            //将布局暂时挂起,防止频繁的重绘
            this.SuspendLayout();

            #region 描述
            //AutoScaleDimensions 属性表示控件缩放到或用于屏幕的 DPI 或字体设置。 
            //具体而言，在设计当前正在使用此属性将设置 Windows 窗体设计器的值监
            //视器的时间。 然后，该窗体加载时在运行时，如果 CurrentAutoScaleDimensions
            //属性是不同于 AutoScaleDimensions, 、 PerformAutoScale 
            //将调用方法来执行该控件及其所有子级的缩放比例。 此后， 
            //AutoScaleDimensions 将更新以反映新的缩放大小。
            #endregion
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);

            #region 描述
            //AutoScaleMode 属性指定此控件的当前自动缩放模式。 按缩放 Font 
            //如果想要的控件或窗体拉伸或收缩根据操作系统中的字体的大小并且
            //控件或窗体的绝对大小并不重要时，应使用非常有用。 按缩放 Dpi 
            //你想要调整大小的控件或窗体相对于屏幕时很有帮助。 例如，您可以
            //使用每英寸点数 (DPI) 缩放控件，以便它始终占据一定百分比的屏幕
            //显示图表或其他图形上点数为单位。
            #endregion
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(400, 320);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.Name = "LoginForm";
            this.Text = Properties.Settings.Default.AppName + "-" + Properties.Settings.Default.Version;
            this.ResumeLayout(false);
        }

        #endregion
    }
}

