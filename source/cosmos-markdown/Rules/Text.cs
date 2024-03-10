using CosmosTTF;
using PrismAPI.Graphics;
using cosmos_markdown.Tools;
using Color = System.Drawing.Color;

namespace cosmos_markdown.Rules
{
    internal class Text : Rule
    {
        private const int FontSize = 18;

        private string TheText;
        private TTFFont Font;

        internal Text(string Text, TTFFont Font)
        {
            this.Font = Font;

            TheText = Text;
        }

        internal override (int X, int Y) RenderTo(Canvas Canvas, int X, int Y)
            => TextRenderer.DrawString(Canvas, FontSize, X, Y + FontSize, Canvas.Width, TheText + ' ', Font, Color.Black, false);
    }
}