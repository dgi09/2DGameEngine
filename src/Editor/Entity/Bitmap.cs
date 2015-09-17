using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Editor
{
    public class Bitmap
    {
        private IntPtr ptr;


        public uint Width
        {
            get { return _bitmapGetWidth(ptr); }
        }

        public uint Height
        {
            get { return _bitmapGetHeight(ptr); }
        }


        public Bitmap()
        {
            ptr = _createBitmap();
        }

        public Bitmap(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        ~Bitmap()
        {
            _destroyBitmap(ptr);
        }

        public void Init(uint width, uint height)
        {
            _initBitmap(ptr, width, height);
        }

        public IntPtr GetBuffer()
        {
            return _bitmapGetBuffer(ptr);
        }

        public IntPtr GetInternalPtr()
        {
            return ptr;
        }

        #region Imports

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _createBitmap();

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _destroyBitmap(IntPtr ptr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _initBitmap(IntPtr ptr,uint width,uint height);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern uint _bitmapGetWidth(IntPtr ptr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern uint _bitmapGetHeight(IntPtr ptr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _bitmapGetBuffer(IntPtr ptr);

        #endregion
    }
}
