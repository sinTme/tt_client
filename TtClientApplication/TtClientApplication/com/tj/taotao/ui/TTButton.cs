using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TtClientApplication.com.tj.taotao.ui
{
    class TTButton : Button
    {
        public TTButton()
        {
            this.Font = ControlStyleUtil.defaultFont;
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Transparent;//去背景  
            this.FlatAppearance.BorderSize = 0;//去边线  
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过  
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下
        }
    }
}
