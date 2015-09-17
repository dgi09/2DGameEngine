using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Editor
{
    public abstract class ObjectTreeElement
    {
        private System.Windows.Forms.TreeNode tNode;


        protected EventHandler<MenuItemClickedArgs> OnMenuItemSelect;

        protected ContextMenuStrip menu;


        protected List<ObjectTreeElement> children;

        public ObjectTreeElement()
        {
            tNode = new System.Windows.Forms.TreeNode();
            children = new List<ObjectTreeElement>();

            menu = new ContextMenuStrip();
            menu.ItemClicked += menu_ItemClicked;
            menu.Closed += menu_Closed;
        }

        void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (OnMenuItemSelect != null)
            {
                OnMenuItemSelect(this, new MenuItemClickedArgs(e.ClickedItem.Text));
            }
        }

        void menu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if(tNode.TreeView != null)
            tNode.TreeView.ContextMenuStrip = null;
        }

        protected void SetNodeText(string text)
        {
            tNode.Text = text;
        }

        protected void AddMenuItem(string text)
        {
            menu.Items.Add(text);
        }

        public System.Windows.Forms.TreeNode GetTreeNode()
        {
            return tNode;
        }

        public void OnAddToTree()
        {
            if (tNode.TreeView != null)
            {
                tNode.TreeView.NodeMouseClick += TreeView_NodeMouseClick;

                foreach (ObjectTreeElement child in children)
                {
                    child.OnAddToTree();
                }
            }
            
        }

        private void TreeView_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == tNode)
            {
                if(e.Button == System.Windows.Forms.MouseButtons.Left)
                    OnTreeNodeClick();
                else if(e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                        tNode.TreeView.ContextMenuStrip = menu; 
                }
            }
        }

        protected abstract void OnTreeNodeClick();

        protected void AddChild(ObjectTreeElement child)
        {
            tNode.Nodes.Add(child.GetTreeNode());
            children.Add(child);
            child.OnAddToTree();
        }

        protected void RemoveChild(ObjectTreeElement child)
        {
            tNode.Nodes.Remove(child.GetTreeNode());
        }

    }

    public class MenuItemClickedArgs : EventArgs
    {

        public string Text{get;set;}
        public MenuItemClickedArgs(string text)
        {
           Text = text;
        }
    }
}
