using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Text : ScreenEntity
    {

        Texture texture;
        Color currentColor;

        TextRenderOptions opt;
        string text;

        private bool needReDraw;

        #region Properties

        public string TextValue
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    if (text != "")
                    {
                        RecalcBounds();
                        needReDraw = true;

                        propPanel.TextValue = value;
                    }
                    else
                    {
                        texture = null;
                        needReDraw = false;
                    }
                }
            }
        }

        public uint Size
        {
            get { return opt.size; }
            set
            {
                if (opt.size != value && value > 5)
                {
                    opt.size = value;
                    RecalcBounds();
                    needReDraw = true;

                    propPanel.CharSize = value.ToString();
                }
            }
        }

        public string Font
        {
            get { return opt.fontName; }
            set
            {
                if (opt.fontName != value)
                {
                    opt.fontName = value;
                    if (opt.fontName == "")
                    {
                        texture = null;
                        needReDraw = false;

                        
                    }
                    else
                    {
                        RecalcBounds();

                        needReDraw = true;
                    }

                    propPanel.FontPath = value;

                }
            }
        }

        public uint CharOffset
        {
            get { return opt.charOffSet; }
            set
            {
                if (opt.charOffSet != value || value > 0)
                {
                    opt.charOffSet = value;

                    RecalcBounds();
                    needReDraw = true;

                    propPanel.CharOffset = value.ToString();
                }
            }
        }

        public uint CharSize
        {
            get { return opt.size; }
            set
            {
                if (opt.size != value)
                {
                    opt.size = value;

                    RecalcBounds();
                    needReDraw = true;
                }
            }
        }

        public Color Color
        {
            get { return new Color(opt.r, opt.g, opt.b); }
            set
            {
                Color c = (Color)value;
                if (c.r != opt.r || c.g != opt.g || c.b != opt.b)
                {
                    opt.r = c.r;
                    opt.g = c.g;
                    opt.b = c.b;

                    needReDraw = true;

                    propPanel.Color = value;
                }
            }
        }
        #endregion

        TextPropPanel propPanel;

        public Text()
        {
            text = "";

            texture = null;
            opt.size = 16;
            opt.charOffSet = 1;
            opt.r = opt.g = opt.b = 255;
            opt.fontName = "";

            currentColor = Color.Green;
            needReDraw = false;

            propPanel = new TextPropPanel();
            LoadProps();


            propPanel.OnPropChange += PropPanel_OnChage;

            OnInstanceNameChange += OnInstanceNameCh;
            OnXChange += OnXCh;
            OnYChange += OnYCh;

            AddMenuItem("Delete");
            OnMenuItemSelect += OnMenuItemSel;
        }


        private void LoadProps()
        {
            propPanel.InstanceName = InstanceName;
            propPanel.TextX = X.ToString();
            propPanel.TextY = Y.ToString();
            propPanel.TextValue = TextValue;
            propPanel.Color = Color;
            propPanel.CharSize = CharSize.ToString();
            propPanel.CharOffset = CharOffset.ToString();
        }


        public void ShowPropPanel()
        {
            PropPanelLoader.SetPropContent(propPanel);
        }

        public override void Draw(Canvas canvas)
        {
            if (needReDraw)
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(opt.fontName))
                    texture = null;
                else
                    texture = TextRenderer.RenderText(opt, text);

                needReDraw = false;
            }

            destRect.left = X;
            destRect.top = Y;
            destRect.right = X + ClipWidth;
            destRect.bottom = Y + ClipHeight;

            if (texture != null)
            {
                canvas.DrawTextureFull(texture, destRect, 0);
                if (fComponent.InFocus)
                {
                    canvas.DrawRect(destRect, Color.Red);
                }
            }
            else
            {
                if (fComponent.InFocus)
                    currentColor = Color.Red;
                else currentColor = Color.Green;

                canvas.DrawRect(destRect, currentColor);
            }
        }

        protected override void OnInteractionEntityClick()
        {
            FocusHandler.SetFocusComponent(fComponent);
            ShowPropPanel();
        }

        protected override void OnInteractionEntityDrag()
        {
            X = iComponent.X;
            Y = iComponent.Y;
        }

        protected override void OnTreeNodeClick()
        {
            FocusHandler.SetFocusComponent(fComponent);
            ShowPropPanel();
        }

        private void RecalcBounds()
        {
            if (text != "" && opt.fontName != "")
            {
                Rect bounds = TextRenderer.GetTextBounds(opt, text);
                ClipWidth = bounds.right;
                ClipHeight = bounds.bottom;
            }

        }

        private void OnInstanceNameCh(object sender, EventArgs e)
        {
            propPanel.InstanceName = InstanceName;
            SetNodeText(InstanceName + ": Text");
        }

        private void OnXCh(object sender, EventArgs e)
        {
            propPanel.TextX = X.ToString();
        }

        private void OnYCh(object sender, EventArgs e)
        {
            propPanel.TextY = Y.ToString();
        }

        private void PropPanel_OnChage(object sender, EventArgs e)
        {
            InstanceName = propPanel.InstanceName;
            X = int.Parse(propPanel.TextX);
            Y = int.Parse(propPanel.TextY);
            TextValue = propPanel.TextValue;
            Font = propPanel.FontPath;

            CharSize = uint.Parse(propPanel.CharSize);
            CharOffset = uint.Parse(propPanel.CharOffset);
            Color = propPanel.Color;
        }

        private void OnMenuItemSel(object sender, MenuItemClickedArgs e)
        {

            GameApp.GetGurrentScreen().RemoveText(this);
        }
    }
}
