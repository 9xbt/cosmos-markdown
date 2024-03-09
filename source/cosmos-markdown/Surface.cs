using CosmosTTF;
using PrismAPI.Graphics;

namespace cosmos_markdown
{
    internal unsafe class Surface : ITTFSurface
    {
        private Canvas Canvas;

        public Surface(Canvas Canvas)
        {
            this.Canvas = Canvas;
        }

        public void DrawBitmap(Cosmos.System.Graphics.Bitmap Image, int X, int Y)
        {
            /*int maxWidth = Canvas.Width - 30;

            if (X > maxWidth)
            {
                X -= (Canvas.Width - 50) * (maxWidth / X);
            }*/

            // Fast alpha image drawing.
            for (int IY = 0; IY < Image.Height; IY++)
            {
                int CanvasY = Y + IY;

                // Skip if out of bounds.
                if (IY < 0 || IY >= Image.Height || CanvasY < 0 || CanvasY >= Canvas.Height)
                {
                    continue;
                }

                for (int IX = 0; IX < Image.Width; IX++)
                {
                    int CanvasX = X + IX;

                    // Skip if out of bounds.
                    if (IX < 0 || IX >= Image.Width || CanvasX < 0 || CanvasX >= Canvas.Width)
                    {
                        continue;
                    }

                    int CanvasIndex = (CanvasY * Canvas.Width) + CanvasX;

                    // Retrieve background and foreground colors.
                    uint BackgroundARGB = Canvas.Internal[CanvasIndex];
                    uint ForegroundARGB = (uint)Image.RawData[(IY * Image.Width) + IX];

                    unchecked
                    {
                        // Extract channels.
                        byte BackgroundR = (byte)((BackgroundARGB >> 16) & 0xFF);
                        byte BackgroundG = (byte)((BackgroundARGB >> 8) & 0xFF);
                        byte BackgroundB = (byte)((BackgroundARGB) & 0xFF);
                        byte ForegroundA = (byte)((ForegroundARGB >> 24) & 0xFF);
                        byte ForegroundR = (byte)((ForegroundARGB >> 16) & 0xFF);
                        byte ForegroundG = (byte)((ForegroundARGB >> 8) & 0xFF);
                        byte ForegroundB = (byte)((ForegroundARGB) & 0xFF);

                        // Inverse the foreground alpha.
                        byte InvForegroundA = (byte)(255 - ForegroundA);

                        // Calculate blending.
                        byte R = (byte)((ForegroundA * ForegroundR + InvForegroundA * BackgroundR) >> 8);
                        byte G = (byte)((ForegroundA * ForegroundG + InvForegroundA * BackgroundG) >> 8);
                        byte B = (byte)((ForegroundA * ForegroundB + InvForegroundA * BackgroundB) >> 8);

                        // Repack channels.
                        uint Color = 0xFF000000 | ((uint)R << 16) | ((uint)G << 8) | B;

                        Canvas.Internal[CanvasIndex] = Color;
                    }
                }
            }
        }
    }
}