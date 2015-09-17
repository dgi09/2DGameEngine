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

    

    public partial class AppPropPanel : UserControl
    {
        public string StartScreen
        {
            get
            {
                return tbStartScreen.Text;
            }
            set
            {
                tbStartScreen.Text = value;
            }
        }

        public string TexturesHeapSize
        {
            set
            {
                tbTexturesHeapSize.Text = value;
            }
            get
            {
                return tbTexturesHeapSize.Text;
            }
        }

        public string TextsHeapSize
        {
            get
            {
                return tbTextsHeapSize.Text;
            }
            set
            {
                tbTextsHeapSize.Text = value;
            }
        }

        public string SpritesHeapSize
        {
            get
            {
                return tbSpriteHeapSize.Text;
            }
            set
            {
                tbSpriteHeapSize.Text = value;
            }
        }

        public string FPS
        {
            get
            {
                return tbFPS.Text;
            }
            set
            {
                tbFPS.Text = value;
            }
        }

        public string AppName
        {
            set
            {
                lblAppName.Text = value;
            }
        }

        public EventHandler<AppPropPanel_OnPropChangeArgs> OnPropChange;

        public AppPropPanel()
        {
            InitializeComponent();
        }


        private void tbFPS_TextChanged(object sender, EventArgs e)
        {
            if (OnPropChange != null)
            {
                OnPropChange(this, new AppPropPanel_OnPropChangeArgs(AppProperty.FPS));
            }
        }

        #region StartScreen

        void NotifyStartScreenChange()
        {
            if (OnPropChange != null)
            {
                OnPropChange(this, new AppPropPanel_OnPropChangeArgs(AppProperty.StartScreen));
            }
        }

        private void tbStartScreen_Leave(object sender, EventArgs e)
        {
            NotifyStartScreenChange();
        }

        private void tbStartScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyStartScreenChange();
        }

        #endregion

        #region TexturesHeapSize

        void NotifyTexturesHeapSizeChange()
        {
            if (OnPropChange != null)
            {
                OnPropChange(this, new AppPropPanel_OnPropChangeArgs(AppProperty.TexturesHeapSize));
            }
        }


        private void tbTexturesHeapSize_Leave(object sender, EventArgs e)
        {
            NotifyTexturesHeapSizeChange();
        }

        private void tbTexturesHeapSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyTexturesHeapSizeChange();
        }
        #endregion

        #region TextsHeapSize

        void NotifyTextsHeapSizeChange()
        {
            if (OnPropChange != null)
            {
                OnPropChange(this, new AppPropPanel_OnPropChangeArgs(AppProperty.TextsHeapSize));
            }
        }

        private void tbTextsHeapSize_Leave(object sender, EventArgs e)
        {
            NotifyTextsHeapSizeChange();
        }

        private void tbTextsHeapSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyTextsHeapSizeChange();
        }


        #endregion

        #region SpritesHeapSizeChange
        void NotifySpriteHeapSizeChange()
        {
            if (OnPropChange != null)
            {
                OnPropChange(this, new AppPropPanel_OnPropChangeArgs(AppProperty.SpritesHeapSize));
            }
        }

        private void tbSpriteHeapSize_Leave(object sender, EventArgs e)
        {
            NotifySpriteHeapSizeChange();
        }

        private void tbSpriteHeapSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifySpriteHeapSizeChange();
        }
        
        #endregion





    }

    public enum AppProperty
    {
        StartScreen,
        TexturesHeapSize,
        TextsHeapSize,
        SpritesHeapSize,
        FPS
    }

    public class AppPropPanel_OnPropChangeArgs : EventArgs
    {
        public AppProperty Prop { get; set; }
        public AppPropPanel_OnPropChangeArgs(AppProperty prop)
        {
            Prop = prop;
        }
    }
}
