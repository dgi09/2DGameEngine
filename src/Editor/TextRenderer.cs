using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Editor
{
    class TextRenderer
    {
        public static void Init()
        {
            _textRendererInit();
        }

        public static void Destroy()
        {
            _textRendererDestroy();
        }

        public static Texture RenderText(TextRenderOptions options, string text)
        {
            Texture texture = TextureFactory.CreateTexture();
            Bitmap b = new Bitmap(_textRendererDrawText(options, text));
            texture.InitFromBitmap(b);

            return texture;
        }

        public static Rect GetTextBounds(TextRenderOptions options, string text)
        {
            return _textRendererGetTextBounds(options, text);
        }

        #region Imports
        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _textRendererInit();

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _textRendererDestroy();

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _textRendererDrawText(TextRenderOptions opt,string text);

        [DllImport("NETPort.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Rect _textRendererGetTextBounds(TextRenderOptions opt,string text);
        #endregion
    }
}
