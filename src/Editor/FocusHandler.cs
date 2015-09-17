using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class FocusHandler
    {
        private static FocusComponent current = null;
        public static void SetFocusComponent(FocusComponent componenet)
        {
            if (current == componenet)
                return;

            if (current != null)
                current.InFocus = false;
            current = componenet;

            current.InFocus = true;
        }

        public static void OutOfFocus()
        {
            if (current != null)
                current.InFocus = false;

            current = null;
        }
      
    }
}
