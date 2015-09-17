using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class ColorPickerDialog : Form
    {

        public bool IsCanceled { get; set; }
        public Color Color { get; set; }


        private System.Drawing.Color col;

        public ColorPickerDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Color = new Editor.Color();
            IsCanceled = false;
            Color.r = (uint)sldrRed.Value;
            Color.g = (uint)sldrGreen.Value;
            Color.b = (uint)sldrBlue.Value;
            Color.a = 255;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsCanceled = true;
            Close();
        }

        private void ColorPickerDialog_Load(object sender, EventArgs e)
        {
            pbColor.Paint += pbColor_Paint;
            col = System.Drawing.Color.Black;
        }

        private void pbColor_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(col);
        }

        private void sldr_ValueChanged(object sender, EventArgs e)
        {
           col = System.Drawing.Color.FromArgb(255, sldrRed.Value, sldrGreen.Value, sldrBlue.Value);
           pbColor.Invalidate();
        }
    }
}
