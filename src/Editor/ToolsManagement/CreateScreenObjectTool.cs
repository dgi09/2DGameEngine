using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public enum ObjectType
    {
        Sprite,
        Text
    }
    class CreateScreenObjectTool : ITool
    {
        private ObjectType type;
        private object obj;

        public CreateScreenObjectTool(ObjectType type)
        {
            this.type = type;
            obj = null;
        }

        public CreateScreenObjectTool(ObjectType type, object obj)
        {
            this.type = type;
            this.obj = obj;
        }

        public void OnAdd()
        {
            CursorHandler.SetCursor(System.Windows.Forms.Cursors.Cross);
        }

        public void OnRemove()
        {
            CursorHandler.SetCursor(System.Windows.Forms.Cursors.Default);
        }

        public void OnMouseEvent(MouseEvent e)
        {
            if (e.Type == EventType.Click)
            {
                GameScreen currentScreen = GameApp.GetGurrentScreen();

                ScreenEntity entity = null;

                if (type == ObjectType.Sprite)
                {
                    Sprite s;
                    if (obj != null)
                        s = (Sprite)obj;
                    else s = new Sprite();
                    entity = s;

                    s.InstanceName = "sprite";
                    

                    currentScreen.AddSprite(s);
                    s.ShowPropsPanel();

                    
                }
                else
                {
                    Text t;
                    if (obj != null)
                        t = (Text)obj;
                    else t = new Text();
                    entity = t;

                    t.InstanceName = "text";
                    currentScreen.AddText(t);
                    t.ShowPropPanel();
                }


                entity.X = e.MouseX - entity.ClipWidth / 2;
                entity.Y = e.MouseY - entity.ClipHeight / 2;


                FocusHandler.SetFocusComponent(entity.GetFocusComponent());
                ToolManager.SetCurrentTool(new InteractionTool());
            }
        }
    }
}
