using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class ToolManager
    {
        private static ITool currentTool = null;

        public static void SetCurrentTool(ITool tool)
        {
            if (currentTool != null)
            {
                currentTool.OnRemove();
            }

            currentTool = tool;

            currentTool.OnAdd();
        }

        public static void PushMouseEvent(MouseEvent e)
        {
            if (currentTool != null)
                currentTool.OnMouseEvent(e);
        }
    }
}
