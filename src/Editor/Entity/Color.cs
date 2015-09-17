using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Color
    {
        public uint r, g, b, a;

        public Color()
        {

        }

        public Color(uint r, uint g, uint b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public static Color Black
        {
            get { return new Color(0, 0, 0); }
        }

        public static Color Green
        {
            get { return new Color(0, 255, 0); }
        }

        public static Color Red
        {
            get { return new Color(255, 0, 0); }
        }
    }
}
