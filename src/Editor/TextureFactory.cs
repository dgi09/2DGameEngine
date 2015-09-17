using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class TextureFactory
    {
        private static IntPtr devicePtr;

        public static void SetDevicePtr(IntPtr device)
        {
            devicePtr = device;
        }

        public static Texture CreateTexture()
        {
            Texture t = new Texture(devicePtr);
            return t;
        }
    }
}
