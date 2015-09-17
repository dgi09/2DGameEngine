using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Editor
{
    public class Texture
    {
        IntPtr ptr;

        public uint Width { get; set; }
        public uint Height { get; set; }

        public Texture(IntPtr devPtr)
        {
            ptr = _createTexture();
            _textureDeviceInit(ptr, devPtr);

            Width = 0;
            Height = 0;
        }

        ~Texture()
        {
            _textureDestroy(ptr);
        }

        public void InitFromFile(string filePath)
        {
            _textureInitFromFile(ptr, filePath);
            Width = _textureGetWidth(ptr);
            Height = _textureGetHeight(ptr);
        }

        public void InitFromBitmap(Bitmap bitmap)
        {
            _textureInitFromBitmap(ptr, bitmap.GetInternalPtr());
        }

        public IntPtr GetInternalPtr()
        {
            return ptr;
        }

        #region Imports
        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _createTexture();

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _textureDeviceInit(IntPtr ptr,IntPtr devPtr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _textureDestroy(IntPtr ptr);


        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _textureInitFromFile(IntPtr ptr,string fileName);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern uint _textureGetWidth(IntPtr ptr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern uint _textureGetHeight(IntPtr ptr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _textureInitFromBitmap(IntPtr ptr,IntPtr bitmapHandle);
        #endregion
    }
}
