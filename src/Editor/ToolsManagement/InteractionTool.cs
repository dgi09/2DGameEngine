using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Editor
{
    class InteractionTool : ITool
    {
        public void OnAdd()
        {
            CursorHandler.SetCursor(Cursors.Default);
        }

        public void OnRemove()
        {

        }

        public void OnMouseEvent(MouseEvent e)
        {
            GameScreen screen = GameApp.GetGurrentScreen();
            if (screen != null)
            {
                screen.GetInteractionArea().PushMouseEvent(e);
            }   
        }
    }
}
