using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Shims
{
    class GLShims
    {
        public static int LoadTexture(string path, int unit)
        {
            using (Bitmap image = Bitmap.FromFile(path) as Bitmap)
            {
                BitmapData bitmapData = null;
                byte[] rgbaBytes;

                try
                {
                    bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    int totalSize = bitmapData.Height * bitmapData.Stride;
                    rgbaBytes = new byte[totalSize];

                    System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, rgbaBytes, 0, totalSize);
                }
                finally
                {
                    if (bitmapData != null) image.UnlockBits(bitmapData);
                }

                int id = GL.GenTexture();
                GL.ActiveTexture(OpenTK.Graphics.OpenGL.TextureUnit.Texture0 + unit);
                GL.BindTexture(TextureTarget.Texture2D, id);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, rgbaBytes);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

                return id;
            }
        }
    }
}
