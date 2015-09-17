using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Editor
{
    public class Sprite : ScreenEntity , IUpdateable
    {

        Texture texture;

        string srcImagePath;

        public int Rotation { get; set; }

        private Color currentColor;

        private SpritePropPanel props;

        private Rect srcRect;

        private uint frameWidth;
        private uint frameHeight;

        private bool animated;

        public bool Animated
        {
            get { return animated; }
            set 
            {
                if (animated != value)
                {
                    animated = value;
                    props.Animated = value;
                    OnAnimatedStateChanged();
                }

            }
        }

        public uint FrameWidth
        {
            get { return frameWidth; }
            set
            {
                if (frameWidth != value)
                {
                    frameWidth = value;
                    props.FrameWidth = frameWidth;
                    OnAnimatedStateChanged();
                }
            }
        }

        public uint FrameHeight
        {
            get { return frameHeight; }
            set
            {
                if (frameHeight != value)
                {
                    frameHeight = value;
                    props.FrameHeight = value;
                    OnAnimatedStateChanged();
                }
            }
        }

        public string TexturePath
        {
            get { return srcImagePath; }
        }

        private List<Animation> animations;
        private Animation currentAnimation;
        uint currentFrame;
        uint counter;
        uint rows;


        public Sprite()
        {

            animated = false;
            srcImagePath = string.Empty;
            frameWidth = frameHeight = 30;
            srcRect.left = srcRect.top = 0;
            srcRect.right = (int)frameWidth;
            srcRect.bottom = (int)frameHeight;
            animations = new List<Animation>();
            currentAnimation = null;
            currentFrame = 0;

            Rotation = 0;

            texture = null;

            currentColor = Color.Green;

            props = new SpritePropPanel();


            props.FrameWidth = frameWidth;
            props.FrameHeight = frameHeight;
            
            props.OnPropChange += PropPanel_OnChange;

            OnXChange += OnInternalPropChange;
            OnYChange += OnInternalPropChange;

            props.OnAnimAdd += OnPropPanel_AnimAdd;
            props.OnAnimPlay += OnPropPanel_AnimPlay;
            props.OnAnimStop += OnPropPanel_AnimStop;
            props.OnAnimEdit += OnPropPanel_AnimEdit;
            props.OnAnimDelete += OnPropPanel_AnimDelete;


            AddMenuItem("Delete");
            AddMenuItem("Add to library");
            OnMenuItemSelect += OnMenuItemSel;

            OnInstanceNameChange += OnInstanceNameCh;
           

        }

        private void OnAnimatedStateChanged()
        {
            if (animated)
            {
                ClipWidth = (int)frameWidth;
                ClipHeight = (int)frameHeight;
            }
            else
            {
                if (texture != null)
                {
                    ClipWidth = (int)texture.Width;
                    ClipHeight = (int)texture.Height;
                }
                else
                {
                    ClipWidth = ClipHeight = 60;
                }
                
            }
        }

        public void LoadFromFile(string path)
        {
            srcImagePath = path;
            texture = TextureFactory.CreateTexture();
            texture.InitFromFile(path);

            if (!Animated)
            {
                ClipWidth = (int)texture.Width;
                ClipHeight = (int)texture.Height;
            }            
        }

        public override void Draw(Canvas canvas)
        {

            destRect.left = X;
            destRect.top = Y;
            destRect.right = X + ClipWidth;
            destRect.bottom = Y + ClipHeight;

            if (texture != null)
            {
                if (animated)
                {
                    srcRect.right = srcRect.left + (int)frameWidth;
                    srcRect.bottom = srcRect.top + (int)frameHeight;
                    canvas.DrawTexturePart(texture, destRect, srcRect, Rotation);
                }
                else 
                    canvas.DrawTextureFull(texture, destRect, Rotation);
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

        public void Update()
        {
            if (animated)
            {
                if (currentAnimation != null)
                {
                    counter++;
                    if (counter > 100)
                    {
                        uint frame = currentFrame + currentAnimation.StartFrame-1;
                        if(frame > currentAnimation.EndFrame-1)
                        {
                            if(currentAnimation.PlayStyle == AnimationPlayStyle.ONCE)
                                return;

                            currentFrame = 0;
                            frame = currentFrame + currentAnimation.StartFrame -1;
                        }
                        rows = texture.Width / frameWidth;

                        uint locY = frame / rows;
                        uint locX = frame % rows;

                        srcRect.left = (int)(locX * frameWidth);
                        srcRect.top = (int)(locY * frameHeight);
                        counter = 0;
                        currentFrame++;
                    }
                    
                }
            }
        }

        public void AddAnimation(Animation anim)
        {
            animations.Add(anim);
            props.AddAnimation(anim);
        }

        public Animation GetAnimationAt(uint index)
        {
            return animations[(int)index];
        }

        public uint GetNumberOfAnimations()
        {
            return (uint)animations.Count;
        }

        protected override void OnTreeNodeClick()
        {
            OnSelect();
        }

        private void OnInstanceNameCh(object sender, EventArgs e)
        {
            SetNodeText(InstanceName + " : Sprite");
        }

        protected void LoadProps()
        {
            props.SpriteName = InstanceName;
            props.SpriteX = X.ToString();
            props.SpriteY = Y.ToString();
            props.TexturePath = srcImagePath;
            props.Rotation = Rotation.ToString();
        }

        public void ShowPropsPanel()
        {
            LoadProps();
            PropPanelLoader.SetPropContent(props);
        }

        private void PropPanel_OnChange(object sender, SpritePropPanel_OnPropChangeArgs e)
        {
            if (e.Prop == SpriteProp.Texture)
            {
                srcImagePath = props.TexturePath;
                LoadFromFile(srcImagePath);
                return;
            }

            Animated = props.Animated;
            FrameHeight = props.FrameHeight;
            FrameWidth = props.FrameWidth;

            X = int.Parse(props.SpriteX);
            Y = int.Parse(props.SpriteY);

            Rotation = int.Parse(props.Rotation);
            InstanceName = props.SpriteName;
        }

        private void OnSelect()
        {
            FocusHandler.SetFocusComponent(fComponent);
            ShowPropsPanel();
        }

        protected override void OnInteractionEntityClick()
        {
            OnSelect();
        }

        protected override void OnInteractionEntityDrag()
        {
            X = iComponent.X;
            Y = iComponent.Y;
        }

        public LibrarySprite GenerateLibSprite()
        {
            LibrarySprite lib = new LibrarySprite();
            lib.X = X;
            lib.Y = Y;
            lib.TexturePath = srcImagePath;
            lib.Animated = animated;

            if (animated)
            {
                lib.FrameHeight = FrameHeight;
                lib.FrameWidth = FrameHeight;
                
                foreach(Animation anim in animations)
                {
                    lib.Animations.Add(anim.Copy());
                }
            }
            return lib;
        }

        private void OnInternalPropChange(object sender, EventArgs e)
        {
            LoadProps();
        }

        private void OnPropPanel_AnimAdd(object sender, SpritePropPanel_AnimAddArgs e)
        {
            Animation a = new Animation();
            a.Name = e.Anim.Name;
            a.PlayStyle = e.Anim.PlayStyle;
            a.StartFrame = e.Anim.StartFrame;
            a.EndFrame = e.Anim.EndFrame;

            animations.Add(a);
        }

        private void OnPropPanel_AnimPlay(object sender, SpritePropPanel_AnimPlayArgs e)
        {
            currentAnimation = animations[(int)e.Index];
            currentFrame = 0;
            counter = 0;
        }

        private void OnPropPanel_AnimStop(object sender, EventArgs e)
        {
            currentAnimation = null;

        }

        private void OnPropPanel_AnimEdit(object sender, SpritePropPanel_AnimEditArgs e)
        {
            if (animations[(int)e.Index] == currentAnimation)
            {
                currentAnimation = null;
            }

            Animation anim = animations[(int)e.Index];
            anim.Name = e.New.Name;
            anim.PlayStyle = e.New.PlayStyle;
            anim.StartFrame = e.New.StartFrame;
            anim.EndFrame = e.New.EndFrame;

        }

        private void OnPropPanel_AnimDelete(object sender, SpritePropPanel_AnimDeleteArgs e)
        {
            if (animations[(int)e.Index] == currentAnimation)
            {
                currentAnimation = null;
            }

            animations.RemoveAt((int)e.Index);
        }

        private void OnMenuItemSel(object sender, MenuItemClickedArgs e)
        {
            if(e.Text == "Delete")
                GameApp.GetGurrentScreen().RemoveSprite(this);
            else
            {
                NameDialog dialog = new NameDialog();

                System.Windows.Forms.DialogResult res = dialog.ShowDialog();

                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    LibrarySprite libSprite = GenerateLibSprite();
                    libSprite.Name = dialog.NameValue;

                    GameApp.GetGurrentScreen().AddLibrarySprite(libSprite);
                }
            }
        }
    }
}
