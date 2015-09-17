using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public enum EventType
    {
        Click,
        Down,
        Up,
        DClick,
        RightCick,
        Move,
        Out
    }

    public class MouseEvent
    {
        public int MouseX { get; set; }
        public int MouseY { get; set; }
        public EventType Type { get; set; }
    }
}
