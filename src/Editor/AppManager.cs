using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

using System.Xml.Linq;


namespace Editor
{
    public class AppManager
    {
        private static string appName;
        private static string rootDirectory;

        public static void SetAppName(string name)
        {
            appName = name;
        }
        public static string GetAppName()
        {
            return appName;
        }

        public static void SetRootDir(bool current, string directory = "")
        {
            if (current)
            {
                rootDirectory = Directory.GetCurrentDirectory();
            }
            else
            {
                rootDirectory = directory;
            }

        }

        public static void Compile()
        {
            CompileMainEntry();
            CompileScreens();
        }

        public static void RunFirstSetUp()
        {
            string fullDir = GetFullDir();

            if (Directory.Exists(fullDir))
                DeleteDir(fullDir + "\\");

            Directory.CreateDirectory(fullDir);

            Directory.CreateDirectory(fullDir + "\\Bin");
            Directory.CreateDirectory(fullDir + "\\Scripts");
            Directory.CreateDirectory(fullDir + "\\Assets");
            Directory.CreateDirectory(fullDir + "\\Assets\\Textures");
            Directory.CreateDirectory(fullDir + "\\Assets\\Fonts");
            Directory.CreateDirectory(fullDir + "\\Scripts\\Libs");

            File.Copy("Core.dll", fullDir + "\\Bin\\Core.dll");
            File.Copy("D3DX11d_43.dll", fullDir + "\\Bin\\D3DX11d_43.dll");
            File.Copy("Engine.dll", fullDir + "\\Bin\\Engine.dll");
            File.Copy("Skel.exe", fullDir + "\\Bin\\" + appName + ".exe");
            File.Copy("lua51.dll", fullDir + "\\Bin\\lua51.dll");
            File.Copy("lualibs\\input.lua", fullDir + "\\Scripts\\Libs\\input.lua");
            File.Copy("lualibs\\sprite.lua", fullDir + "\\Scripts\\Libs\\sprite.lua");
            File.Copy("lualibs\\text.lua", fullDir + "\\Scripts\\Libs\\text.lua");
            File.Copy("lualibs\\librarySprite.lua", fullDir + "\\Scripts\\Libs\\librarySprite.lua");

            File.CreateText(fullDir + "\\Scripts\\entry.lua");

        }

        private static string GetFullDir()
        {

            return rootDirectory + "\\" + appName;
        }

        private static void DeleteDir(string dir)
        {
            string[] files = Directory.GetFiles(dir);

            foreach (string file in files)
            {
                File.Delete(file);
            }

            string[] dirs = Directory.GetDirectories(dir);

            foreach (string cdir in dirs)
            {
                DeleteDir(cdir);
            }

            Directory.Delete(dir);
        }

        public static void RunApp()
        {

            ProcessStartInfo info = new ProcessStartInfo();

            info.FileName = GetFullDir() + "\\Bin\\" + appName + ".exe";
            info.CreateNoWindow = false;
            info.WindowStyle = ProcessWindowStyle.Normal;
            info.WorkingDirectory = GetFullDir() + "\\Bin\\";
            using (Process proc = Process.Start(info))
            {
                proc.WaitForExit();
            }
        }

        public static void RunEditScriptDialog(GameScreen screen)
        {
            string filePath = GetFullDir() + "\\Scripts\\" + screen.Script + "_user.lua";

            if (File.Exists(filePath) == false)
            {
                CreateEmptyUserScript(filePath);
            }

            EditScript dialog = new EditScript();
            dialog.TextValue = File.ReadAllText(filePath);

            System.Windows.Forms.DialogResult res = dialog.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(filePath, dialog.TextValue);
            }

        }

        private static void CreateEmptyUserScript(string filePath)
        {
            StreamWriter sw = File.CreateText(filePath);

            sw.WriteLine("function init()");
            sw.Write(sw.NewLine);
            sw.WriteLine("end");

            sw.WriteLine("function logic()");
            sw.Write(sw.NewLine);
            sw.Write("end");

            sw.Close();
        }

        private static void CompileMainEntry()
        {
            string filePath = GetFullDir() + "\\Scripts\\entry.lua";
            if (File.Exists(filePath) == false)
                File.Create(filePath);

            StringBuilder sb = new StringBuilder();

            sb.Append("SetNumberOfHeapTextures(");
            sb.Append(GameApp.GetTexturesHeapSize());
            sb.AppendLine(")");

            sb.Append("SetNumberOfHeapSprites(");
            sb.Append(GameApp.GetSpritesHeapSize());
            sb.AppendLine(")");

            sb.Append("SetNumberOfHeapTexts(");
            sb.Append(GameApp.GetTextsHeapSize());
            sb.AppendLine(")");

            sb.AppendLine();

            uint numberOfScreens = GameApp.GetNumberOfScreens();
            for (uint i = 0; i < numberOfScreens; i++)
            {
                GameScreen screen = GameApp.GetScreenAt(i);
                sb.AppendLine("CreateScreen('" + screen.ScreenName + "','../Scripts/" +
                              screen.Script + "_autogen.lua'" + ",'../Scripts/" +
                              screen.Script + "_user.lua')");
            }

            sb.AppendLine("SetCurrentScreen('" + GameApp.GetStartupScreen() + "')");

            File.WriteAllText(filePath, sb.ToString());
        }

        private static void CompileScreens()
        {
            for (uint i = 0; i < GameApp.GetNumberOfScreens(); i++)
            {
                GameScreen screen = GameApp.GetScreenAt(i);
                CompileScreen(screen);
            }
        }

        private static void CompileScreen(GameScreen screen)
        {
            string userScriptPath = GetFullDir() + "\\Scripts\\" + screen.Script + "_user.lua";
            if (File.Exists(userScriptPath) == false)
            {
                CreateEmptyUserScript(userScriptPath);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("function autogen_init()");
            sb.AppendLine("SetBackgroundColor(" + screen.BackgroundColor.r + "," + screen.BackgroundColor.g + "," + screen.BackgroundColor.b + ")");
            sb.AppendLine();

            uint i;
            for (i = 0; i < screen.GetNumberOfSprites(); i++)
            {
                Sprite sp = screen.GetSpriteAt(i);
                WriteSprite(sb, sp);
                sb.AppendLine();
            }

            for (i = 0; i < screen.GetNumberOfTexts(); i++)
            {
                Text text = screen.GetTextAt(i);
                WriteText(sb, text);
                sb.AppendLine();
            }

            for (i = 0; i < screen.GetNumberOfLibrarySprites(); i++)
            {
                LibrarySprite lSprite = screen.GetLibrarySpriteAt(i);
                WriteLSprite(sb, lSprite, i);
                sb.AppendLine();
            }

            sb.AppendLine("end");

            string autoGenPath = GetFullDir() + "\\Scripts\\" + screen.Script + "_autogen.lua";

            File.WriteAllText(autoGenPath, sb.ToString());
        }

        private static void WriteSprite(StringBuilder sb, Sprite sprite)
        {
            sb.AppendLine(sprite.InstanceName + " = AddSprite()");
            sb.AppendLine(sprite.InstanceName + ":SetPosition(" + sprite.X.ToString() + "," + sprite.Y.ToString() + ")");

            if (sprite.TexturePath != string.Empty)
            {
                string fileName = GetFileNameFromPath(sprite.TexturePath);
                string newFilePath = GetFullDir() + "\\Assets\\Textures\\" + fileName;

                if (File.Exists(newFilePath) == false)
                    File.Copy(sprite.TexturePath, newFilePath);

                sb.AppendLine(sprite.InstanceName + ":LoadTextureFromFile('../Assets/Textures/" + fileName + "')");
            }

            sb.AppendLine(sprite.InstanceName + ":Animated(" + sprite.Animated.ToString().ToLower() + ")");

            if (sprite.Animated)
            {
                sb.AppendLine(sprite.InstanceName + ":SetFrameSize(" + sprite.FrameWidth.ToString() + "," + sprite.FrameHeight.ToString() + ")");

                for (uint i = 0; i < sprite.GetNumberOfAnimations(); i++)
                {
                    Animation anim = sprite.GetAnimationAt(i);

                    string playStyle = anim.PlayStyle == AnimationPlayStyle.LOOP ? "PLAYSTYLE_LOOP" : "PLAYSTYLE_ONCE";

                    sb.AppendLine(sprite.InstanceName + ":AddAnimation('" + anim.Name + "'," + playStyle + "," + anim.StartFrame.ToString() + "," + anim.EndFrame.ToString() + ")");
                }

            }

        }

        private static void WriteText(StringBuilder sb, Text text)
        {
            sb.AppendLine(text.InstanceName + " = AddText()");
            sb.AppendLine(text.InstanceName + ":SetPosition(" + text.X.ToString() + "," + text.Y.ToString() + ")");
            sb.AppendLine(text.InstanceName + ":SetText('" + text.TextValue + "')");
            sb.AppendLine(text.InstanceName + ":SetColor(" + text.Color.r.ToString() + "," +
                                                             text.Color.g.ToString() + "," +
                                                             text.Color.b.ToString() + ")");

            sb.AppendLine(text.InstanceName + ":SetSize(" + text.Size.ToString() + ")");

            string fontFileName = GetFileNameFromPath(text.Font);
            string newFontPath = GetFullDir() + "\\Assets\\Fonts\\" + fontFileName;

            if (File.Exists(newFontPath) == false)
                File.Copy(text.Font, newFontPath);

            sb.AppendLine(text.InstanceName + ":SetFont('../Assets/Fonts/" + fontFileName + "')");
        }

        private static void WriteLSprite(StringBuilder sb, LibrarySprite lSprite, uint index)
        {
            string inst = "autoGenLs" + index.ToString();

            sb.AppendLine("local " + inst + " = AddLibrarySprite('" + lSprite.Name + "')");
            sb.AppendLine(inst + ":SetPosition(" + lSprite.X.ToString() + "," + lSprite.Y.ToString() + ")");

            string fileName = GetFileNameFromPath(lSprite.TexturePath);
            string newFilePath = GetFullDir() + "\\Assets\\Textures\\" + fileName;
            if (File.Exists(newFilePath) == false)
                File.Copy(lSprite.TexturePath, newFilePath);

            sb.AppendLine(inst + ":SetTexturePath('../Assets/Textures/" + fileName + "')");
            sb.AppendLine(inst + ":Animated(" + lSprite.Animated.ToString().ToLower() + ")");

            if (lSprite.Animated)
            {
                sb.AppendLine(inst + ":SetFrameSize(" + lSprite.FrameWidth + "," + lSprite.FrameHeight + ")");

                foreach (Animation anim in lSprite.Animations)
                {
                    string playStyle = anim.PlayStyle == AnimationPlayStyle.LOOP ? "PLAYSTYLE_LOOP" : "PLAYSTYLE_ONCE";
                    sb.AppendLine(inst + ":AddAnimation('" + anim.Name + "'," + playStyle + "," + anim.StartFrame.ToString() + "," + anim.EndFrame.ToString() + ")");
                }
            }

        }

        private static string GetFileNameFromPath(string path)
        {
            string[] split = path.Split('\\');
            return split.Last();
        }

        public static void Save()
        {
            XElement rootElement = new XElement("root");
            XDocument doc = new XDocument(rootElement);

            XElement appElement = new XElement("app");
            appElement.Add(new XElement("name", appName));
            appElement.Add(new XElement("rootPath", rootDirectory));
            appElement.Add(new XElement("startScreen", GameApp.GetStartupScreen()));

            GameScreen current = GameApp.GetGurrentScreen();
            string curScreenName = current != null ? current.ScreenName : "";

            appElement.Add(new XElement("currentScreen", curScreenName));
            appElement.Add(new XElement("numberOfHeapTextures", GameApp.GetTexturesHeapSize().ToString()));
            appElement.Add(new XElement("numberOfHeapSprites", GameApp.GetSpritesHeapSize().ToString()));
            appElement.Add(new XElement("numberOfHeapTexts", GameApp.GetTextsHeapSize().ToString()));

            rootElement.Add(appElement);

            XElement screensEl = new XElement("screens");
            rootElement.Add(screensEl);

            for (uint i = 0; i < GameApp.GetNumberOfScreens(); i++)
            {
                GameScreen screen = GameApp.GetScreenAt(i);
                screensEl.Add(CreateScreenElement(screen));
            }

            string filePath = rootDirectory + "\\" + appName + ".2dp";
            File.WriteAllText(filePath, doc.ToString());
        }

        public static void LoadFromFile(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement rootEl = doc.Element("root");
            XElement appEl = rootEl.Element("app");

            string appName = appEl.Element("name").Value;
            SetAppName(appName);
            SetRootDir(false, appEl.Element("rootPath").Value);

            GameApp.SetName(appName);
            GameApp.SetStartupScreen(appEl.Element("startScreen").Value);
            GameApp.SetSpritesHeapSize(uint.Parse(appEl.Element("numberOfHeapSprites").Value));
            GameApp.SetTexturesHeapSize(uint.Parse(appEl.Element("numberOfHeapTextures").Value));
            GameApp.SetTextsHeapSize(uint.Parse(appEl.Element("numberOfHeapTexts").Value));

            XElement screensEl = rootEl.Element("screens");

            foreach (XElement screenEl in screensEl.Elements())
            {
                GameScreen screen = CreateScreenFromElement(screenEl);
                GameApp.AddScreen(screen);
            }

            string currentScreenName = appEl.Element("currentScreen").Value;


            for (uint i = 0; i < GameApp.GetNumberOfScreens(); i++)
            {
                GameScreen current = GameApp.GetScreenAt(i);
                if (current.ScreenName == currentScreenName)
                {
                    GameApp.SetCurrentScreen(current);
                    break;
                }
            }
        }

        private static XElement CreateScreenElement(GameScreen screen)
        {
            XElement el = new XElement("screen");
            el.Add(new XElement("name", screen.ScreenName));
            el.Add(new XElement("script", screen.Script));

            XElement colorEl = new XElement("color");
            colorEl.Add(new XAttribute("r", screen.BackgroundColor.r));
            colorEl.Add(new XAttribute("g", screen.BackgroundColor.g));
            colorEl.Add(new XAttribute("b", screen.BackgroundColor.b));

            el.Add(colorEl);

            XElement spritesEl = new XElement("sprites");
            el.Add(spritesEl);

            for (uint i = 0; i < screen.GetNumberOfSprites(); i++)
            {
                Sprite s = screen.GetSpriteAt(i);

                spritesEl.Add(CreateSpriteElement(s));
            }

            XElement textsEl = new XElement("texts");
            el.Add(textsEl);

            for (uint i = 0; i < screen.GetNumberOfTexts(); i++)
            {
                Text t = screen.GetTextAt(i);
                textsEl.Add(CreateTextElement(t));
            }

            XElement lSpritesEl = new XElement("lSprites");
            el.Add(lSpritesEl);

            for (uint i = 0; i < screen.GetNumberOfLibrarySprites(); i++)
            {
                LibrarySprite ls = screen.GetLibrarySpriteAt(i);
                lSpritesEl.Add(CreateLSpriteElement(ls));
            }

            return el;
        }

        private static XElement CreateSpriteElement(Sprite s)
        {
            XElement el = new XElement("sprite");
            el.Add(new XElement("instanceName", s.InstanceName));
            el.Add(new XElement("x", s.X));
            el.Add(new XElement("y", s.Y));
            el.Add(new XElement("texturePath", s.TexturePath));
            el.Add(new XElement("frameWidth", s.FrameWidth));
            el.Add(new XElement("frameHeight", s.FrameHeight));
            el.Add(new XElement("animated", s.Animated));

            XElement animsEl = new XElement("animations");
            el.Add(animsEl);

            for (uint i = 0; i < s.GetNumberOfAnimations(); i++)
            {
                XElement animEl = new XElement("animation");

                Animation anim = s.GetAnimationAt(i);
                animEl.Add(new XElement("name", anim.Name));
                animEl.Add(new XElement("playStyle", anim.PlayStyle.ToString()));
                animEl.Add(new XElement("startFrame", anim.StartFrame));
                animEl.Add(new XElement("endFrame", anim.EndFrame));

                animsEl.Add(animEl);

            }
                return el;
        }

        private static XElement CreateTextElement(Text t)
        {
            XElement el = new XElement("text");
            el.Add(new XElement("instanceName", t.InstanceName));
            el.Add(new XElement("text", t.TextValue));
            el.Add(new XElement("x", t.X));
            el.Add(new XElement("y", t.Y));
            el.Add(new XElement("fontPath", t.Font));
            XElement colorEl = new XElement("color");
            colorEl.Add(new XAttribute("r",t.Color.r));
            colorEl.Add(new XAttribute("g",t.Color.g));
            colorEl.Add(new XAttribute("b",t.Color.b));

            el.Add(colorEl);
            el.Add(new XElement("size", t.Size));
            el.Add(new XElement("charSpacing", t.CharOffset));

            return el;

        }

        private static XElement CreateLSpriteElement(LibrarySprite ls)
        {
            XElement el = new XElement("lSprite");
            el.Add(new XElement("name", ls.Name));
            el.Add(new XElement("texturePath", ls.TexturePath));
            el.Add(new XElement("frameWidth", ls.FrameWidth));
            el.Add(new XElement("frameHeight", ls.FrameHeight));
            el.Add(new XElement("animated", ls.Animated));

            XElement animsEl = new XElement("animations");
            el.Add(animsEl);

            foreach (Animation anim in ls.Animations)
            {
                XElement animEl = new XElement("animation");

                
                animEl.Add(new XElement("name", anim.Name));
                animEl.Add(new XElement("playStyle", anim.PlayStyle.ToString()));
                animEl.Add(new XElement("startFrame", anim.StartFrame));
                animEl.Add(new XElement("endFrame", anim.EndFrame));

                animsEl.Add(animEl);

            }
            return el;
        }

        private static GameScreen CreateScreenFromElement(XElement el)
        {
            GameScreen screen = new GameScreen();
            screen.ScreenName = el.Element("name").Value;
            screen.Script = el.Element("script").Value;
            screen.BackgroundColor = CreateColorFromElement(el.Element("color"));

            XElement spritesEl = el.Element("sprites");

            foreach (XElement spriteEl in spritesEl.Elements())
            {
                Sprite sprite = CreateSpriteFromElement(spriteEl);
                screen.AddSprite(sprite);
            }

            XElement textsEl = el.Element("texts");

            foreach (XElement textEl in textsEl.Elements())
            {
                Text text = CreateTextFromElement(textEl);
                screen.AddText(text);
            }

            XElement lSpritesEl = el.Element("lSprites");

            foreach (XElement lSpriteEl in lSpritesEl.Elements())
            {
                LibrarySprite lSprite = CreateLSpriteFromElement(lSpriteEl);
                screen.AddLibrarySprite(lSprite);
            }

            return screen;
        }

        private static Color CreateColorFromElement(XElement el)
        {
            Color c = new Color();
            c.a = 255;
            c.r = uint.Parse(el.Attribute("r").Value);
            c.g = uint.Parse(el.Attribute("g").Value);
            c.b = uint.Parse(el.Attribute("b").Value);

            return c;
        }

        private static Sprite CreateSpriteFromElement(XElement el)
        {
            Sprite s = new Sprite();
            
            s.InstanceName = el.Element("instanceName").Value;
            s.X = int.Parse(el.Element("x").Value);
            s.Y = int.Parse(el.Element("y").Value);
            s.FrameWidth = uint.Parse(el.Element("frameWidth").Value);
            s.FrameHeight = uint.Parse(el.Element("frameHeight").Value);
            s.Animated = bool.Parse(el.Element("animated").Value);

            string path = el.Element("texturePath").Value;
            if (string.IsNullOrEmpty(path) == false)
            {
                s.LoadFromFile(path);
            }

            XElement animsEl = el.Element("animations");

            foreach (XElement animEl in animsEl.Elements())
            {
                Animation anim = new Animation();
                anim.Name = animEl.Element("name").Value;
                string playStyleStr = animEl.Element("playStyle").Value;

                anim.PlayStyle = playStyleStr == "LOOP" ? AnimationPlayStyle.LOOP : AnimationPlayStyle.ONCE;
                anim.StartFrame = uint.Parse(animEl.Element("startFrame").Value);
                anim.EndFrame = uint.Parse(animEl.Element("endFrame").Value);

                s.AddAnimation(anim);
            }

            return s;
        }

        private static Text CreateTextFromElement(XElement el)
        {
            Text t = new Text();
            t.InstanceName = el.Element("instanceName").Value;
            t.TextValue = el.Element("text").Value;
            t.X = int.Parse(el.Element("x").Value);
            t.Y = int.Parse(el.Element("y").Value);
            t.Font = el.Element("fontPath").Value;
            t.Color = CreateColorFromElement(el.Element("color"));
            t.Size = uint.Parse(el.Element("size").Value);
            t.CharOffset = uint.Parse(el.Element("charSpacing").Value);

            return t;
        }

        private static LibrarySprite CreateLSpriteFromElement(XElement el)
        {

            LibrarySprite s = new LibrarySprite();
            s.Name = el.Element("name").Value;
            s.FrameWidth = uint.Parse(el.Element("frameWidth").Value);
            s.FrameHeight = uint.Parse(el.Element("frameHeight").Value);
            s.Animated = bool.Parse(el.Element("animated").Value);
            
            s.TexturePath = el.Element("texturePath").Value;
            

            XElement animsEl = el.Element("animations");

            foreach (XElement animEl in animsEl.Elements())
            {
                Animation anim = new Animation();
                anim.Name = animEl.Element("name").Value;
                string playStyleStr = animEl.Element("playStyle").Value;

                anim.PlayStyle = playStyleStr == "LOOP" ? AnimationPlayStyle.LOOP : AnimationPlayStyle.ONCE;
                anim.StartFrame = uint.Parse(animEl.Element("startFrame").Value);
                anim.EndFrame = uint.Parse(animEl.Element("endFrame").Value);

                s.Animations.Add(anim);
            }

            return s;
        }
    }
}
