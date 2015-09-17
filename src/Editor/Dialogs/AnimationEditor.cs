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
    public partial class AnimationEditor : Form
    {
        public string AnimationName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public AnimationPlayStyle PlayStyle
        {
            get
            {
                if (cbStyle.SelectedIndex == 0)
                    return AnimationPlayStyle.LOOP;
                else return AnimationPlayStyle.ONCE;
            }
            set
            {
                if (value == AnimationPlayStyle.LOOP)
                    cbStyle.SelectedIndex = 0;
                else cbStyle.SelectedIndex = 1;
            }
        }

        public uint StartFrame
        {
            get { return uint.Parse(tbStartFrame.Text); }
            set { tbStartFrame.Text = value.ToString(); }
        }

        public uint EndFrame
        {
            get { return uint.Parse(tbEndFrame.Text); }
            set { tbEndFrame.Text = value.ToString(); }
        }

        public AnimationEditor()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
