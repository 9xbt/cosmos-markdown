using CosmosTTF;
using System.Drawing;
using System.Text;
using Color = System.Drawing.Color;
using PrismAPI.Graphics;

namespace cosmos_markdown.Tools
{
    internal static class TextRenderer
    {
        internal static int DrawString(Canvas cv, int px, int x, int y, int cvWidth, string text, TTFFont font, Color color, bool underline = false)
        {
            //text = text.Replace('’', '\'');

            int offX = 0, offY = 0;
            GlyphResult g;

            Rune prevRune = new Rune('\0');

            foreach (Rune c in text.EnumerateRunes())
            {
                var gMaybe = font.RenderGlyphAsBitmap(c, color, px);
                if (!gMaybe.HasValue) continue;

                g = gMaybe.Value;

                font.GetGlyphHMetrics(c, px, out int advWidth, out int lsb);
                font.GetKerning(prevRune, c, px, out int kerning);

                offX += lsb + kerning;

                int tX = x + offX, tY = y + offY + g.offY;

                if (tX > cvWidth - 25 - g.bmp.Height)
                {
                    offY += px;
                    offX = 0;

                    tX = x + offX;
                    tY = y + offY + g.offY;
                }

                var surface = new Surface(cv);
                surface.DrawBitmap(g.bmp, tX, tY);

                if (kerning > 0)
                    offX -= lsb;
                else
                    offX += advWidth - lsb;

                prevRune = c;
            }

            if (underline)
            {
                cv.DrawLine(25, y + offY + 10 - 1, cv.Width - 26, y + offY + 10 - 1, new(0xFFD8DEE4));
            }

            return offY + px;
        }
    }
}