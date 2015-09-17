using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Editor
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Rect
    {
        [FieldOffset(0)]
        public int left;

        [FieldOffset(4)]
        public int right;

        [FieldOffset(8)]
        public int top;

        [FieldOffset(12)]
        public int bottom;
    
    }
    
}
