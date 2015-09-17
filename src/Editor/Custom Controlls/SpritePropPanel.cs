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
    public partial class SpritePropPanel : UserControl
    {
        public EventHandler<SpritePropPanel_OnPropChangeArgs> OnPropChange;
        public EventHandler<SpritePropPanel_AnimAddArgs> OnAnimAdd;
        public EventHandler<SpritePropPanel_AnimEditArgs> OnAnimEdit;
        public EventHandler<SpritePropPanel_AnimDeleteArgs> OnAnimDelete;
        public EventHandler<SpritePropPanel_AnimPlayArgs> OnAnimPlay;
        public EventHandler OnAnimStop;

        private List<Animation> animations;

        public string SpriteName
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

        public string SpriteX
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

        public string SpriteY
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

        public string Rotation
        {
            get
            {
                return tbRotation.Text;
            }
            set
            {
                tbRotation.Text = value;
            }
        }

        public string TexturePath
        {
            get
            {
                return tbTexture.Text;
            }
            set
            {
                tbTexture.Text = value;
            }
        }

        public bool Animated
        {
            get { return chbToggleAnimation.Checked; }
            set
            {
                chbToggleAnimation.Checked = value;
            }
        }

        public uint FrameWidth
        {
            get { return uint.Parse(tbFrameWidth.Text); }
            set
            {
                tbFrameWidth.Text = value.ToString();
            }
        }

        public uint FrameHeight
        {
            get { return uint.Parse(tbFrameHeight.Text); }
            set { tbFrameHeight.Text = value.ToString(); }
        }

        public SpritePropPanel()
        {
            InitializeComponent();
            animations = new List<Animation>();
        }

        private void tbnChooseTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult res = dialog.ShowDialog();
            if (res != DialogResult.Cancel)
            {
                tbTexture.Text = dialog.FileName;
                if (OnPropChange != null)
                    OnPropChange(this, new SpritePropPanel_OnPropChangeArgs(SpriteProp.Texture));
            }
        }

        #region Name

        private void NotifyNameChange()
        {
            if (OnPropChange != null)
                OnPropChange(this, new SpritePropPanel_OnPropChangeArgs(SpriteProp.Name));
        }

        private void tbName_Leave(object sender, EventArgs e)
        {
            NotifyNameChange();
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
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

        private void tbX_KeyDown(object sender, KeyEventArgs e)
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
                OnPropChange(this, new SpritePropPanel_OnPropChangeArgs(SpriteProp.X));
        }

        #endregion

        #region Y
        private void NotifyYChange()
        {
            int temp;
            if (string.IsNullOrEmpty(tbY.Text) || int.TryParse(tbY.Text, out temp) == false)
                tbY.Text = "0";

            if (OnPropChange != null)
                OnPropChange(this, new SpritePropPanel_OnPropChangeArgs(SpriteProp.Y));
        }


        private void tbY_Leave(object sender, EventArgs e)
        {
            NotifyYChange();
        }

        private void tbY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyYChange();
        }

        #endregion

        #region Rotation
        private void NotifyRotationChange()
        {
            int temp;
            if (string.IsNullOrEmpty(tbRotation.Text) || int.TryParse(tbRotation.Text, out temp) == false)
                tbRotation.Text = "0";

            if (OnPropChange != null)
                OnPropChange(this, new SpritePropPanel_OnPropChangeArgs(SpriteProp.Rotation));
        }

        private void tbRotation_Leave(object sender, EventArgs e)
        {
            NotifyRotationChange();
        }

        private void tbRotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NotifyRotationChange();
            }
        }

        #endregion

        #region FrameWidth

        void NotifyFrameWidthChange()
        {
            if (OnPropChange != null)
            {
                OnPropChange(this, new SpritePropPanel_OnPropChangeArgs(SpriteProp.FrameWidth));
            }

        }


        private void tbFrameWidth_Leave(object sender, EventArgs e)
        {
            NotifyFrameWidthChange();
        }

        private void tbFrameWidth_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NotifyFrameWidthChange();
            }
        }

        #endregion

        #region FrameHeight

        void NotifyFrameHeightChange()
        {
            if (OnPropChange != null)
            {
                OnPropChange(this, new SpritePropPanel_OnPropChangeArgs(SpriteProp.FrameHeight));
            }
        }

        private void tbFrameHeight_Leave(object sender, EventArgs e)
        {
            NotifyFrameHeightChange();
        }

        private void tbFrameHeight_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NotifyFrameHeightChange();
        }

        #endregion



        private void chbToggleAnimation_CheckedChanged(object sender, EventArgs e)
        {
            if (chbToggleAnimation.Checked)
                pnlAnimation.Visible = true;
            else
                pnlAnimation.Visible = false;

            if (OnPropChange != null)
            {
                OnPropChange(this, new SpritePropPanel_OnPropChangeArgs(SpriteProp.Animated));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            AnimationEditor dialog = new AnimationEditor();
            DialogResult res = dialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                Animation anim = new Animation();

                SetUpAnimFromDialog(dialog, anim);

                AddAnimation(anim);

                if (OnAnimAdd != null)
                {
                    OnAnimAdd(this, new SpritePropPanel_AnimAddArgs(anim));
                }

                
            }

        }

        public void AddAnimation(Animation anim)
        {
            animations.Add(anim);
            lbAnimations.Items.Add(GenerateLBNameFromAnim(anim));
        }
        private void lbAnimations_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnRemove.Enabled = true;
            pnlPlayAnim.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            Animation anim = animations[lbAnimations.SelectedIndex];

            AnimationEditor dialog = new AnimationEditor();
            dialog.AnimationName = anim.Name;
            dialog.PlayStyle = anim.PlayStyle;
            dialog.StartFrame = anim.StartFrame;
            dialog.EndFrame = anim.EndFrame;

            DialogResult res = dialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                SetUpAnimFromDialog(dialog, anim);
                lbAnimations.SelectedItem = GenerateLBNameFromAnim(anim);

                if (OnAnimEdit != null)
                    OnAnimEdit(this, new SpritePropPanel_AnimEditArgs(anim, (uint)lbAnimations.SelectedIndex));
            }
        }


        private void SetUpAnimFromDialog(AnimationEditor dialog, Animation anim)
        {
            anim.Name = dialog.AnimationName;
            anim.StartFrame = dialog.StartFrame;
            anim.EndFrame = dialog.EndFrame;
            anim.PlayStyle = dialog.PlayStyle;
        }

        private string GenerateLBNameFromAnim(Animation anim)
        {
            return anim.Name + ": " + anim.StartFrame.ToString() + "-" + anim.EndFrame.ToString();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (OnAnimPlay != null)
                OnAnimPlay(this, new SpritePropPanel_AnimPlayArgs((uint)lbAnimations.SelectedIndex));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (OnAnimStop != null)
                OnAnimStop(this, new EventArgs());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            animations.RemoveAt(lbAnimations.SelectedIndex);


            if (OnAnimStop != null)
                OnAnimStop(this, new EventArgs());


            if (OnAnimDelete != null)
                OnAnimDelete(this, new SpritePropPanel_AnimDeleteArgs((uint)lbAnimations.SelectedIndex));

            lbAnimations.Items.RemoveAt(lbAnimations.SelectedIndex);

            if (lbAnimations.Items.Count == 0)
            {
                pnlPlayAnim.Enabled = false;
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
            }
            else lbAnimations.SelectedIndex = 0;
        }


    }

    public enum SpriteProp
    {
        Name,
        X,
        Y,
        Rotation,
        Texture,
        Animated,
        FrameWidth,
        FrameHeight
    }

    public class SpritePropPanel_OnPropChangeArgs : EventArgs
    {
        public SpriteProp Prop { get; set; }

        public SpritePropPanel_OnPropChangeArgs(SpriteProp prop)
        {
            Prop = prop;
        }
    }

    public class SpritePropPanel_AnimAddArgs : EventArgs
    {
        public Animation Anim { get; set; }

        public SpritePropPanel_AnimAddArgs(Animation a)
        {
            Anim = a;
        }
    }

    public class SpritePropPanel_AnimEditArgs : EventArgs
    {
        public Animation New { get; set; }
        public uint Index { get; set; }
        public SpritePropPanel_AnimEditArgs(Animation a, uint index)
        {
            New = a;
            Index = index;
        }
    }

    public class SpritePropPanel_AnimDeleteArgs : EventArgs
    {
        public uint Index { get; set; }
        public SpritePropPanel_AnimDeleteArgs(uint index)
        {
            Index = index;
        }
    }

    public class SpritePropPanel_AnimPlayArgs : EventArgs
    {
        public uint Index { get; set; }
        public SpritePropPanel_AnimPlayArgs(uint index)
        {
            Index = index;
        }
    }
}
