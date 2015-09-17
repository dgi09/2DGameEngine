using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public enum AnimationPlayStyle
    {
        LOOP,
        ONCE
    }

    public class Animation
    {
        public string Name { get; set; }
        public AnimationPlayStyle PlayStyle { get; set; }
        public uint StartFrame { get; set; }
        public uint EndFrame { get; set; }

        public Animation Copy()
        {
            Animation a = new Animation();
            a.Name = Name;
            a.PlayStyle = PlayStyle;
            a.StartFrame = StartFrame;
            a.EndFrame = EndFrame;

            return a;
        }
    }
}
