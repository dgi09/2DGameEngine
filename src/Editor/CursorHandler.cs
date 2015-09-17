using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class CursorHandler
    {
        private static System.Windows.Forms.Form mainForm;

        public static void SetMainForm(System.Windows.Forms.Form form)
        {
            mainForm = form;
        }

        public static void SetCursor(System.Windows.Forms.Cursor cursor)
        {
            mainForm.Cursor = cursor;
        }

        public static void SetDefault()
        {
            mainForm.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}
