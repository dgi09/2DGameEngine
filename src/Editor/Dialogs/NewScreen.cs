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

    public partial class NewScreen : Form
    {
        public bool IsCanceled { get; set; }
        public string ScreenName { get; set; }
        public string ScriptName { get; set; }
        public Color BackgroundColor { get; set; }
 

        public NewScreen()
        {
            InitializeComponent();

            BackgroundColor = Color.Black;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            IsCanceled = false;
            ScreenName = tbName.Text;
            ScriptName = tbScriptName.Text;


            Terminate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsCanceled = true;
            Terminate();
        }

        private void Terminate()
        {
            this.Close();
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            ColorPickerDialog dialog = new ColorPickerDialog();
            dialog.ShowDialog();

            if (dialog.IsCanceled == false)
            {
                BackgroundColor = dialog.Color;
            }
        }

    }
}
