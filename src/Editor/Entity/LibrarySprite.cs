using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class LibrarySprite
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string TexturePath { get; set; }

        public bool Animated { get; set; }

        public uint FrameWidth { get; set; }
        public uint FrameHeight { get; set; }

        public List<Animation> Animations { get; set;}

        public LibrarySprite()
        {
            Animations = new List<Animation>();
        }

        public static Sprite GenerateSprite(LibrarySprite lib)
        {
            Sprite s = new Sprite();
            s.X = lib.X;
            s.Y = lib.Y;
            if (!string.IsNullOrEmpty(lib.TexturePath))
                s.LoadFromFile(lib.TexturePath);

            s.Animated = lib.Animated;

            if (lib.Animated)
            {
                s.FrameWidth = lib.FrameWidth;
                s.FrameHeight = lib.FrameHeight;

                foreach (Animation anim in lib.Animations)
                {
                    s.AddAnimation(anim.Copy());
                }
            }
            
            return s;
        }
    }
}
