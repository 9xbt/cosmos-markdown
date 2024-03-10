using cosmos_markdown.Tools;
using CosmosTTF;
using PrismAPI.Graphics;
using Color = System.Drawing.Color;

namespace cosmos_markdown.Rules
{
    internal class H3 : Rule
    {
        private const int FontSize = 28;

        private string Text;
        private TTFFont Font;

        internal H3(string Text, TTFFont Font)
        {
            this.Text = Text;
            this.Font = Font;
        }

        internal override (int X, int Y) RenderTo(Canvas Canvas, int X, int Y)
        {
            var size = TextRenderer.DrawString(Canvas, FontSize, 25, Y + FontSize, Canvas.Width, Text + '\n', Font, Color.Black, true, false);

            return (size.X, size.Y + FontSize);
        }
    }
}