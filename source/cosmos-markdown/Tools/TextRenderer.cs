using CosmosTTF;
using System.Text;
using PrismAPI.Graphics;
using Color = System.Drawing.Color;

namespace cosmos_markdown.Tools
{
    internal static class TextRenderer
    {
        internal static (int X, int Y) DrawString(Canvas cv, int px, int x, int y, int cvWidth, string text, TTFFont font, Color color, bool underline = false, bool closeUnderline = true, bool underlineFill = true, uint underlineColor = 0xFFD8DEE4)
        {
            int offX = 0, offY = 0;
            var words = text.Split(' ');

            GlyphResult g;
            Rune prevRune = new Rune('\0');
            
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (i != words.Length - 1) word += ' ';

                if (x + offX + font.CalculateWidth(word, px) > cvWidth - 25)
                {
                    offX = 0;
                    offY += px;
                }

                foreach (Rune c in word.EnumerateRunes())
                {
                    var gMaybe = font.RenderGlyphAsBitmap(c, color, px);
                    if (!gMaybe.HasValue) continue;

                    g = gMaybe.Value;

                    font.GetGlyphHMetrics(c, px, out int advWidth, out int lsb);
                    font.GetKerning(prevRune, c, px, out int kerning);

                    offX += lsb + kerning;

                    int tX = x + offX, tY = y + offY + g.offY;

                    var surface = new Surface(cv);
                    surface.DrawBitmap(g.bmp, tX, tY);

                    if (kerning > 0)
                        offX -= lsb;
                    else
                        offX += advWidth - lsb;

                    prevRune = c;
                }
            }

            if (underline)
            {
                cv.DrawLine(x, y + offY + (closeUnderline ? 2 : 10) - 1, underlineFill ? cv.Width - 26 :
                    x + offX, y + offY + (closeUnderline ? 2 : 10) - 1, new(underlineColor));
            }

            return (text.EndsWith('\n') ? 0 : offX, offY + (underline ? (closeUnderline ? 10 : 20) : 0));
        }
    }
}