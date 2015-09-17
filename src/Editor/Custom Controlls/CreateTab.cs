using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    

    public partial class CreateTab : UserControl
    {
        public EventHandler<CreateTabArgs> OnItemSelected;
        
        public CreateTab()
        {
            InitializeComponent();
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            if (OnItemSelected != null)
            {
                OnItemSelected(this, new CreateTabArgs(CreateTabItem.GameScreen));
            }
        }

        private void btnSprite_Click(object sender, EventArgs e)
        {
            if (OnItemSelected != null)
            {
                OnItemSelected(this, new CreateTabArgs(CreateTabItem.Sprite));
            }
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            if (OnItemSelected != null)
            {
                OnItemSelected(this, new CreateTabArgs(CreateTabItem.Text));
            }
        }
    }

    public enum CreateTabItem
    {
        GameScreen,
        Sprite,
        Text
    }

    public class CreateTabArgs : EventArgs
    {
        public CreateTabArgs(CreateTabItem item)
        {
            this.Item = item;
        }

        public CreateTabItem Item { get; set; }
    }
}
