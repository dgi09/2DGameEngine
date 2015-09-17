using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class ScreenEntity : ObjectTreeElement, IDrawable
    {
        int x;
        int y;
        int clipWidth;
        int clipHeight;
        private string instanceName;
        protected Rect destRect;

        protected InteractionComponent iComponent;

        protected FocusComponent fComponent;

        #region Properties
        public int X
        {
            get { return x; }
            set
            {
                if (value != x)
                {
                    x = value;
                    iComponent.X = x;
                    if (OnXChange != null)
                        OnXChange(this, new EventArgs());
                }
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value != y)
                {
                    y = value;
                    iComponent.Y = y;
                    if (OnYChange != null)
                        OnYChange(this, new EventArgs());
                }
            }
        }

        public int ClipWidth
        {
            get { return clipWidth; }
            set
            {
                if (clipWidth != value)
                {
                    clipWidth = value;
                    iComponent.Width = clipWidth;
                }
            }
        }

        public int ClipHeight
        {
            get { return clipHeight; }
            set
            {
                if (clipHeight != value)
                {
                    clipHeight = value;
                    iComponent.Height = clipHeight;
                }
            }
        }

        public string InstanceName
        {
            get { return instanceName; }
            set
            {
                if (instanceName != value)
                {
                    instanceName = value;
                    if (OnInstanceNameChange != null)
                        OnInstanceNameChange(this, new EventArgs());
                }
            }
        }
        #endregion

        public ScreenEntity()
        {
            x = y = 0;
            clipWidth = clipHeight = 60;
            iComponent = new InteractionComponent();
            iComponent.Width = clipWidth;
            iComponent.Height = clipHeight;


            fComponent = new FocusComponent();
            fComponent.InFocus = false;

            iComponent.Dragable = true;
            iComponent.OnClick += IEntity_Click;
            iComponent.OnDrag += IEntity_Drag;

        }

        private void IEntity_Click(object sender, EventArgs e)
        {
            OnInteractionEntityClick();
        }


        private void IEntity_Drag(object sender, EventArgs e)
        {
            OnInteractionEntityDrag();
        }


        public FocusComponent GetFocusComponent()
        {
            return fComponent;
        }

        public InteractionComponent GetIntractionComponent()
        {
            return iComponent;
        }

        #region Abstractions
        public abstract void Draw(Canvas canvas);
        protected abstract void OnInteractionEntityClick();
        protected abstract void OnInteractionEntityDrag();

        #endregion

        #region Events
        protected EventHandler OnXChange;
        protected EventHandler OnYChange;
        protected EventHandler OnInstanceNameChange;
        #endregion
    }
}
