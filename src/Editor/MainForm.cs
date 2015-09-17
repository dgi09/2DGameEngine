using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Editor
{
    public partial class MainForm : Form
    {
        Canvas canvas = null;

        System.Diagnostics.Stopwatch fpsCounter;

        public MainForm(OpenProjectProps openProjProps)
        {
            InitializeComponent();

            this.FormClosing += MainForm_FormClosing;
            this.FormClosed += MainForm_FormClosed;

            ctPanel.OnItemSelected += ctPanel_onItemSelected;
            pbDraw.Draw += drawPanel_Draw;
            pbDraw.MouseClick += pbDraw_MouseClick;
            pbDraw.MouseMove += pbDraw_MouseMove;
            pbDraw.MouseDown += pbDraw_MouseDown;
            pbDraw.MouseUp += pbDraw_MouseUp;


            Init();
            
            if (openProjProps.Type == OpenType.New)
            {
                string mainDir = openProjProps.ProjectFolder + "\\" + openProjProps.ProjectName;
                Directory.CreateDirectory(mainDir);

                AppManager.SetAppName(openProjProps.ProjectName);
                AppManager.SetRootDir(false,mainDir);
                AppManager.RunFirstSetUp();
            }
            else
            {
                AppManager.LoadFromFile(openProjProps.ProjectFile);
            }


            

        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppManager.Save();
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Init()
        {
            CursorHandler.SetMainForm(this);



            GameApp.Init();
            TextRenderer.Init();

            objectsTree.Nodes.Add(GameApp.GetTreeNode());
            GameApp.OnTreeNodeAdd();



            pbDraw.Init();
            canvas = pbDraw.GetCanvas();
            canvas.SetClearColor(Color.Black);

            PropPanelLoader.SetMainPropPanel(propPanel);
            TextureFactory.SetDevicePtr(canvas.GetDevice());

            GameApp.ShowPropsPanel();

            ToolManager.SetCurrentTool(new InteractionTool());

            fpsCounter = new System.Diagnostics.Stopwatch();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
    
        }

        private void ctPanel_onItemSelected(object sender, CreateTabArgs e)
        {
            if (e.Item == CreateTabItem.GameScreen)
            {
                NewScreen dialog = new NewScreen();

                dialog.ShowDialog();
                if (dialog.IsCanceled == false)
                {
                    GameScreen screen = new GameScreen();
                    screen.ScreenName = dialog.ScreenName;
                    screen.Script = dialog.ScriptName;

                    screen.BackgroundColor = dialog.BackgroundColor;

                    screen.ShowPropsPanel();

                    GameApp.AddScreen(screen);
                    GameApp.SetCurrentScreen(screen);

                }
            }

            else if (e.Item == CreateTabItem.Sprite && GameApp.GetGurrentScreen() != null)
            {
                ToolManager.SetCurrentTool(new CreateScreenObjectTool(ObjectType.Sprite));
            }

            else if (e.Item == CreateTabItem.Text && GameApp.GetGurrentScreen() != null)
            {
                ToolManager.SetCurrentTool(new CreateScreenObjectTool(ObjectType.Text));
            }

        }

        private void drawPanel_Draw(object sender, EventArgs e)
        {
            if (GameApp.GetGurrentScreen() == null)
            {
               
                canvas.Clear();

                canvas.Present();
            }
            else
            {
                fpsCounter.Start();
                GameApp.GetGurrentScreen().Draw(canvas);
                
                if (fpsCounter.ElapsedMilliseconds < (long)GameApp.GetTimeStep())
                {
                    System.Threading.Thread.Sleep((int)GameApp.GetTimeStep() - (int)fpsCounter.ElapsedMilliseconds);
                }
            }

        }
        #region DrawPanelEventns

        private void pbDraw_MouseClick(object sender, MouseEventArgs e)
        {

            MouseEvent evt = new MouseEvent();
            evt.Type = EventType.Click;
            evt.MouseX = e.X;
            evt.MouseY = e.Y;

            ToolManager.PushMouseEvent(evt);

        }

        void pbDraw_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEvent evt = new MouseEvent();
            evt.Type = EventType.Move;
            evt.MouseX = e.X;
            evt.MouseY = e.Y;

            ToolManager.PushMouseEvent(evt);
        }

        void pbDraw_MouseUp(object sender, MouseEventArgs e)
        {
            MouseEvent evt = new MouseEvent();
            evt.Type = EventType.Up;
            evt.MouseX = e.X;
            evt.MouseY = e.Y;

            ToolManager.PushMouseEvent(evt);
        }

        void pbDraw_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEvent evt = new MouseEvent();
            evt.Type = EventType.Down;
            evt.MouseX = e.X;
            evt.MouseY = e.Y;

            ToolManager.PushMouseEvent(evt);
        }

        #endregion
        void btnRun_Click(object sender, System.EventArgs e)
        {
            AppManager.RunApp();
        }


        void btnCompile_Click(object sender, System.EventArgs e)
        {
            AppManager.Compile();
        }


    }
}
