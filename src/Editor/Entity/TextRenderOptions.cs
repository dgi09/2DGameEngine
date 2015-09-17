using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Editor
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TextRenderOptions
    {
        [FieldOffset(0)]
        public string fontName;

        [FieldOffset(4)]
        public uint r;

        [FieldOffset(8)]
        public uint g;

        [FieldOffset(12)]
        public uint b;

        [FieldOffset(16)]
        public uint size;

        [FieldOffset(20)]
        public uint charOffSet;

    }
}
