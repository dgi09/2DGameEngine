using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    class PropPanelLoader
    {
        private static Panel mainPropPane;

        public static void SetMainPropPanel(Panel panel)
        {
            mainPropPane = panel;
        }

        public static void SetPropContent(Control control)
        {
            mainPropPane.Controls.Clear();
            mainPropPane.Controls.Add(control);
        }
    }
}
