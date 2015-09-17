using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class DrawPanel : UserControl
    {
        private Canvas canvas;

        public EventHandler Draw;

        public DrawPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor |ControlStyles.Opaque |
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint, true);

            canvas = null;

            this.Paint += DrawPanel_Paint;
        }

        public void Init()
        {
            canvas = new Canvas(Handle, (uint)Height, (uint)Width);

        }

        public Canvas GetCanvas()
        {
            return canvas;
        }


        void DrawPanel_Paint(object sender, EventArgs e)
        {
          
            if (Draw != null)
                Draw(this, new EventArgs());
  
            Invalidate();
           
        }
    }
}
