using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    interface ITool
    {
         void OnAdd();
         void OnRemove();
         void OnMouseEvent(MouseEvent e);
    }
}
