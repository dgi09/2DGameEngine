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
    public partial class TextPropPanel : UserControl
    {
        public EventHandler<TextPropPanel_OnPropChangeArgs> OnPropChange;

        private Color color;

        public string InstanceName
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }

        public string TextX
        {
            get
            {
                return tbX.Text;
            }
            set
            {
                tbX.Text = value;
            }
        }

        public string TextY
        {
            get
            {
                return tbY.Text;
            }
            set
            {
                tbY.Text = value;
            }
        }

        public string FontPath
        {
            get { return tbFont.Text; }
            set { tbFont.Text = value; }
        }

        public string TextValue
        {
            get { return tbText.Text; }
            set { tbText.Text = value; }
        }

        public string CharSize
        {
            get { return tbCharSize.Text; }
            set { tbCharSize.Text = value; }
        }

        public string CharOffset
        {
            get { return tbCharOffset.Text; }
            set { tbCharOffset.Text = value; }
        }

        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                SetupButtonColor();
            }
        }


        public TextPropPanel()
        {
            InitializeComponent();
            color = new Color(0, 0, 0);
        }

        private void SetupButtonColor()
        {
            System.Drawing.Color c = System.Drawing.Color.FromArgb((int)color.r,(int)color.g,(int)color.b);
            btnColor.BackColor = c;
            btnColor.Invalidate();
        }

        #region InstanceName

        private void NotifyNameChange()
        {
            if (OnPropChange != null)
                OnPropChange(this, new TextPropPanel_OnPropChangeArgs(TextProp.InstanceName));
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            NotifyNameChange();
        }


        private void tbName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NotifyNameChange();
            }
        }

        #endregion

        #region X
        private void tbX_Leave(object sender, EventArgs e)
        {
            NotifyXChange();
        }


        private void tbX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyXChange();
        }

        private void NotifyXChange()
        {
            int temp;
            if (string.IsNullOrEmpty(tbX.Text) || int.TryParse(tbX.Text, out temp) == false)
                tbX.Text = "0";

            if (OnPropChange != null)
                OnPropChange(this, new TextPropPanel_OnPropChangeArgs(TextProp.X));
        }

        #endregion

        #region Y
        private void NotifyYChange()
        {
            int temp;
            if (string.IsNullOrEmpty(tbY.Text) || int.TryParse(tbY.Text, out temp) == false)
                tbY.Text = "0";

            if (OnPropChange != null)
                OnPropChange(this, new TextPropPanel_OnPropChangeArgs(TextProp.Y));
        }


        private void tbY_Leave(object sender, EventArgs e)
        {
            NotifyYChange();
        }


        private void tbY_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyYChange();
        }

        #endregion

        #region Text
        private void tbText_Leave(object sender, EventArgs e)
        {
            NotifyTextChange();
        }


        private void tbText_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                NotifyTextChange();
        }

        private void NotifyTextChange()
        {
            if (OnPropChange != null)
                OnPropChange(this, new TextPropPanel_OnPropChangeArgs(TextProp.Text));
        }

        #endregion

        #region Char Size
        private void tbCharSize_Leave(object sender, EventArgs e)
        {
            NotifyCharSizeChange();
        }

        private void tbCharSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyCharSizeChange();
        }

        void NotifyCharSizeChange()
        {
            if (OnPropChange != null)
                OnPropChange(this, new TextPropPanel_OnPropChangeArgs(TextProp.CharSize));
        }
        #endregion

        #region Char Offset

        private void tbCharOffset_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyCharOffSetChange();
        }

        private void tbCharOffset_Leave(object sender, EventArgs e)
        {
            NotifyCharOffSetChange();
        }

        void NotifyCharOffSetChange()
        {
            if (OnPropChange != null)
                OnPropChange(this, new TextPropPanel_OnPropChangeArgs(TextProp.CharOffset));
        }


        #endregion


        private void btnFont_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult res = dialog.ShowDialog();

            if (res != DialogResult.Cancel)
            {
                tbFont.Text = dialog.FileName;

                if (OnPropChange != null)
                    OnPropChange(this, new TextPropPanel_OnPropChangeArgs(TextProp.Font));
            }
        
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorPickerDialog dialog = new ColorPickerDialog();
            dialog.ShowDialog();

            if (dialog.IsCanceled == false)
            {
                Color = dialog.Color;

                if (OnPropChange != null)
                    OnPropChange(this, new TextPropPanel_OnPropChangeArgs(TextProp.Color));
            }
        }

    }

    public enum TextProp
    {
        InstanceName,
        X,
        Y,
        Text,
        Font,
        CharSize,
        CharOffset,
        Color
    }

    public class TextPropPanel_OnPropChangeArgs : EventArgs
    {
        public TextProp Prop { get; set; }

        public TextPropPanel_OnPropChangeArgs(TextProp prop)
        {
            Prop = prop;
        }
    }
}
