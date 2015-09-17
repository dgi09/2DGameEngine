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


    public partial class ScreenPropPanel : UserControl
    {
        Color bgColor;


        public EventHandler<ScreenPropPanel_PropChangeArgs> OnPropChange;
        public EventHandler<ScreenPropPanel_LSpriteArgs> OnLSpriteRemove;
        public EventHandler<ScreenPropPanel_LSpriteArgs> OnLSpratePlace;

        public EventHandler OnScriptEditClick;

        public string ScreenName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public string Script
        {
            get { return tbScript.Text; }
            set { tbScript.Text = value; }
        }


        public Color BGColor
        {
            get { return bgColor; }
            set 
            {
                bgColor = value;
                UpdateButtonColor();
            }
        }

        public ScreenPropPanel()
        {
            InitializeComponent();
           
        }

        private void UpdateButtonColor()
        {
            System.Drawing.Color c = System.Drawing.Color.FromArgb(255, (int)bgColor.r, (int)bgColor.g, (int)bgColor.b);
            btnColor.BackColor = c;
            btnColor.Invalidate();
        }


        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorPickerDialog dialog = new ColorPickerDialog();
            dialog.ShowDialog();

            if (dialog.IsCanceled == false)
            {
                bgColor = dialog.Color;
                UpdateButtonColor();

                if (OnPropChange != null)
                    OnPropChange(this, new ScreenPropPanel_PropChangeArgs(ScreenPanelProp.BgColor));
            }

        }

        #region Name 
        
        private void NotifyNameChange()
        {
            if (OnPropChange != null)
                OnPropChange(this, new ScreenPropPanel_PropChangeArgs(ScreenPanelProp.ScreenName));
        }


        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyNameChange();
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            NotifyNameChange();
        }


        #endregion

        #region Script 
        
        private void NotifyScriptChange()
        {
            if (OnPropChange != null)
                OnPropChange(this, new ScreenPropPanel_PropChangeArgs(ScreenPanelProp.Script));
        }

        private void tbScript_Leave(object sender, EventArgs e)
        {
            NotifyScriptChange();
        }

        private void tbScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyScriptChange();
        }

        #endregion


        public void AddLibrarySprite(string name)
        {
            lbSprites.Items.Add(name);
        }

        public void RemoveLibrarySprite(int index)
        {
            lbSprites.Items.RemoveAt(index);
            if (lbSprites.Items.Count < 0)
            {
                btnPlaceOnScreen.Enabled = false;
                btnRemoveLSprite.Enabled = false;
            }
        }

        private void lbSprites_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPlaceOnScreen.Enabled = true;
            btnRemoveLSprite.Enabled = true;
        }

        private void btnRemoveLSprite_Click(object sender, EventArgs e)
        {
            if (lbSprites.SelectedIndex >= 0)
            {
               
                if (OnLSpriteRemove != null)
                {
                    OnLSpriteRemove(this, new ScreenPropPanel_LSpriteArgs(lbSprites.SelectedIndex));
                }

                lbSprites.Items.RemoveAt(lbSprites.SelectedIndex);
            }
            
        }

        private void btnPlaceOnScreen_Click(object sender, EventArgs e)
        {
            if (OnLSpratePlace != null)
            {
                OnLSpratePlace(this, new ScreenPropPanel_LSpriteArgs(lbSprites.SelectedIndex));
            }
        }

        private void btnEditScript_Click(object sender, EventArgs e)
        {
            if (OnScriptEditClick != null)
                OnScriptEditClick(this, new EventArgs());
        }

    }

    public enum ScreenPanelProp
    {
        ScreenName,
        Script,
        BgColor
    }

    public class ScreenPropPanel_PropChangeArgs : EventArgs
    {
        public ScreenPanelProp Prop { get; set; }
        public ScreenPropPanel_PropChangeArgs(ScreenPanelProp prop)
        {
            Prop = prop;
        }
    }

    public class ScreenPropPanel_LSpriteArgs : EventArgs
    {
        public int Index { get; set; }
        public ScreenPropPanel_LSpriteArgs(int index)
        {
            Index = index;
        }
    }

}
