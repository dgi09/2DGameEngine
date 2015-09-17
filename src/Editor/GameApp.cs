using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class GameApp
    {
        private static GameScreen currentScreen;
        private static List<GameScreen> screens;
        private static string startUpScreen;

        private static uint texturesHeapSize;
        private static uint spritesHeapSize;
        private static uint textsHeapSize;


        private static System.Windows.Forms.TreeNode tNode;
        private static AppPropPanel propPanel;

        private static uint fps;
        private static double timeStep;

        public static uint GetFPS()
        {
            return fps;
        }

        public static void SetFPS(uint val)
        {
            fps = val;
            timeStep = (double)1000 / (double)val;
        }

        public static double GetTimeStep()
        {
            return timeStep;
        }

        public static void Init()
        {
            currentScreen = null;
            screens = new List<GameScreen>();
            startUpScreen = "";
            textsHeapSize = 0;
            texturesHeapSize = 0;
            spritesHeapSize = 0;
            SetFPS(24);
            tNode = new System.Windows.Forms.TreeNode("app : Application");

            propPanel = new AppPropPanel();
            propPanel.TextsHeapSize = "0";
            propPanel.TexturesHeapSize = "0";
            propPanel.SpritesHeapSize = "0";
            propPanel.FPS = "24";
            propPanel.AppName = AppManager.GetAppName();
            
            propPanel.OnPropChange += PropPanel_OnPropChange;
        }



        public static void SetCurrentScreen(GameScreen screen)
        {
            currentScreen = screen;
        }

        public static GameScreen GetGurrentScreen()
        {
            return currentScreen;
        }

        public static void AddScreen(GameScreen screen)
        {
            tNode.Nodes.Add(screen.GetTreeNode());
            screen.OnAddToTree();

            screens.Add(screen);
        }

        public static void RemoveScreen(GameScreen screen)
        {
            ShowPropsPanel();
            tNode.Nodes.Remove(screen.GetTreeNode());

            screens.Remove(screen);

            if (screens.Count > 0)
                SetCurrentScreen(screens[0]);
            else currentScreen = null;
        }

        public static void SetStartupScreen(string name)
        {
            startUpScreen = name;
            propPanel.StartScreen = name;
        }

        public static void SetName(string name)
        {
            propPanel.AppName = name;
        }

        public static string GetStartupScreen()
        {
            return startUpScreen;
        }

        public static uint GetTexturesHeapSize()
        {
            return texturesHeapSize;
        }

        public static void SetTexturesHeapSize(uint size)
        {
            texturesHeapSize = size;
            propPanel.TexturesHeapSize = size.ToString();
        }

        public static uint GetSpritesHeapSize()
        {
            return spritesHeapSize;
        }

        public static void SetSpritesHeapSize(uint size)
        {
            spritesHeapSize = size;
            propPanel.SpritesHeapSize = size.ToString();
        }

        public static uint GetTextsHeapSize()
        {
            return textsHeapSize;
        }

        public static void SetTextsHeapSize(uint size)
        {
            textsHeapSize = size;
            propPanel.TextsHeapSize = size.ToString();
        }

        public static uint GetNumberOfScreens()
        {
            return (uint)screens.Count;
        }

        public static GameScreen GetScreenAt(uint index)
        {
            return screens[(int)index];
        }

        public static System.Windows.Forms.TreeNode GetTreeNode()
        {
            return tNode;
        }

        public static void OnTreeNodeAdd()
        {
            tNode.TreeView.NodeMouseClick += TreeView_NodeMouseClick;
        }

        public static void ShowPropsPanel()
        {
            PropPanelLoader.SetPropContent(propPanel);
        }


        public static void PropPanel_OnPropChange(object sender, AppPropPanel_OnPropChangeArgs e)
        {
            startUpScreen = propPanel.StartScreen;
            textsHeapSize = uint.Parse(propPanel.TextsHeapSize);
            texturesHeapSize = uint.Parse(propPanel.TexturesHeapSize);
            spritesHeapSize = uint.Parse(propPanel.SpritesHeapSize);
            SetFPS(uint.Parse(propPanel.FPS));
        }

        private static void TreeView_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == tNode)
            {
                ShowPropsPanel();
            }
        }
    }
}
