using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Editor
{
    public class Canvas
    {
        IntPtr ptr;

        public Canvas(IntPtr handle, uint width, uint height)
        {
            ptr = _createCanvas(handle, width, height);
        }

        ~Canvas()
        {
            _destroyCanvas(ptr);
        }

        public void SetClearColor(uint r, uint g, uint b)
        {
            _canvasSetClearColor(ptr, r, g, b);
        }

        public void SetClearColor(Color color)
        {
            _canvasSetClearColor(ptr, color.r, color.g, color.b);
        }

        public void Clear()
        {
            _canvasClear(ptr);
        }

        public void Present()
        {
            _canvasPresent(ptr);
        }

        public void DrawTextureFull(Texture texture, Rect dstRect, int rotationAngle)
        {
            _canvasDrawTextureFull(ptr, texture.GetInternalPtr(), dstRect, rotationAngle);
        }

        public void DrawTexturePart(Texture texture,Rect dstRect,Rect srcRect,int rotation)
        {
            _canvasDrawTexturePart(ptr, texture.GetInternalPtr(), dstRect, srcRect, rotation);
        }
        public void DrawRect(Rect rect, Color color)
        {
            _canvasDrawRect(ptr, rect, color.r, color.g, color.b);
        }

        public IntPtr GetDevice()
        {
            return _canvasGetDevice(ptr);
        }

        #region Imports

        [DllImport("NETPort.dll",CallingConvention=CallingConvention.Cdecl)]
        private static extern IntPtr _createCanvas(IntPtr handle, uint width, uint height);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _destroyCanvas(IntPtr ptr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _canvasSetClearColor(IntPtr ptr, uint r, uint g, uint b);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _canvasClear(IntPtr ptr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _canvasPresent(IntPtr ptr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _canvasDrawTextureFull(IntPtr canvasPtr,IntPtr texturePtr,
                                                        Rect r,int rotationAngle);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _canvasDrawTexturePart(IntPtr canvasPtr, IntPtr texturePtr,
                                                        Rect r,Rect src, int rotationAngle);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _canvasGetDevice(IntPtr ptr);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _canvasDrawRect(IntPtr ptr,Rect rect,uint r,uint g,uint b);
        #endregion
    }
}
