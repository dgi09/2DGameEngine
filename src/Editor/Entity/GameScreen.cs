using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class GameScreen : ObjectTreeElement
    {

        private string _screenName;

        public string ScreenName 
        {
            get
            {
                return _screenName;
            }
            set
            {
                _screenName = value;
                SetNodeText(_screenName + ": Screen");
            }
        }
        public string Script { get; set; }
        public Color BackgroundColor { get; set; }

        private InteractionComponent iComponent;
        private InteractionArea iArea;
        private ScreenPropPanel props;

        private List<IDrawable> drawables;
        private List<Sprite> sprites;
        private List<Text> texts;
        private List<IUpdateable> updateables;

        private List<LibrarySprite> lSprites;

        public GameScreen()
        {

            BackgroundColor = Color.Black;
            iArea = new InteractionArea();
            iComponent = new InteractionComponent();
            iComponent.IsInfinet = true;
            iComponent.Dragable = false;

            props = new ScreenPropPanel();
            props.OnPropChange += props_onPropChange;
            props.OnLSpriteRemove += OnPropPanel_LibSpriteRemove;
            props.OnLSpratePlace += OnPropPanel_LibSpritePlace;
            props.OnScriptEditClick += OnScriptEdit;
            
            iArea.AddEntity(iComponent);

            iComponent.OnClick += iEntity_Click;

            AddMenuItem("Delete");
            OnMenuItemSelect += OnMenuItemSel;

            drawables = new List<IDrawable>();
            updateables = new List<IUpdateable>();
            sprites = new List<Sprite>();
            texts = new List<Text>();
            lSprites = new List<LibrarySprite>();





        }


        public void Draw(Canvas canvas)
        {

            foreach (IUpdateable up in updateables)
            {
                up.Update();
            }

            canvas.SetClearColor(BackgroundColor);
            canvas.Clear();

            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw(canvas);
            }

            canvas.Present();
            
        }

        public void AddSprite(Sprite sprite)
        {
            sprites.Add(sprite);
            drawables.Add(sprite);
            updateables.Add(sprite);
            iArea.AddEntity(sprite.GetIntractionComponent());

            AddChild(sprite);
        }

        public void RemoveSprite(Sprite sprite)
        {
            sprites.Remove(sprite);
            drawables.Remove(sprite);
            updateables.Remove(sprite);
            iArea.RemoveEntity(sprite.GetIntractionComponent());

            RemoveChild(sprite);

            ShowPropsPanel();
        }

        public void AddText(Text text)
        {
            texts.Add(text);
            drawables.Add(text);

            iArea.AddEntity(text.GetIntractionComponent());

            AddChild(text);
        }

        public void RemoveText(Text text)
        {
            texts.Remove(text);
            drawables.Remove(text);
            iArea.RemoveEntity(text.GetIntractionComponent());

            RemoveChild(text);
        }

        public void AddLibrarySprite(LibrarySprite lSprite)
        {
            lSprites.Add(lSprite);
            props.AddLibrarySprite(lSprite.Name);
        }

        public void RemoveLibrarySprite(LibrarySprite lSprite)
        {
            int index = lSprites.IndexOf(lSprite);
            lSprites.Remove(lSprite);

            props.RemoveLibrarySprite(index);
        }

        public uint GetNumberOfSprites()
        {
            return (uint)sprites.Count;
        }

        public Sprite GetSpriteAt(uint index)
        {
            return sprites[(int)index];
        }

        public uint GetNumberOfTexts()
        {
            return (uint)texts.Count;
        }

        public Text GetTextAt(uint index)
        {
            return texts[(int)index];
        }

        public uint GetNumberOfLibrarySprites()
        {
            return (uint)lSprites.Count;
        }

        public LibrarySprite GetLibrarySpriteAt(uint index)
        {
            return lSprites[(int)index];
        }

        public InteractionArea GetInteractionArea()
        {
            return iArea;
        }

        private void iEntity_Click(object sender, EventArgs e)
        {
            FocusHandler.OutOfFocus();
            ShowPropsPanel();
        }

        private void props_onPropChange(object sender, ScreenPropPanel_PropChangeArgs e)
        {
            this.ScreenName = props.ScreenName;
            this.Script = props.ScreenName;
            this.BackgroundColor = props.BGColor;
        }

        private void OnMenuItemSel(object sender, MenuItemClickedArgs e)
        {
            GameApp.RemoveScreen(this);
        }

        public void ShowPropsPanel()
        {
            

            props.ScreenName = ScreenName;
            props.Script = Script;
            props.BGColor = BackgroundColor;

            PropPanelLoader.SetPropContent(props);
        }

        protected override void OnTreeNodeClick()
        {
            FocusHandler.OutOfFocus();
            ShowPropsPanel();
            GameApp.SetCurrentScreen(this);
        }


        private void OnPropPanel_LibSpriteRemove(object sender, ScreenPropPanel_LSpriteArgs e)
        {
            lSprites.RemoveAt(e.Index);
        }

        private void OnPropPanel_LibSpritePlace(object sender, ScreenPropPanel_LSpriteArgs e)
        {
            LibrarySprite lib = lSprites[e.Index];
            ToolManager.SetCurrentTool(new CreateScreenObjectTool(ObjectType.Sprite, LibrarySprite.GenerateSprite(lib)));
        }

        private void OnScriptEdit(object sender, EventArgs e)
        {
            AppManager.RunEditScriptDialog(this);
        }
    }
}
