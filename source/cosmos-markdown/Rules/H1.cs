using CosmosTTF;
using PrismAPI.Graphics;
using cosmos_markdown.Tools;
using Color = System.Drawing.Color;

namespace cosmos_markdown.Rules
{
    internal class H1 : Rule
    {
        private const int FontSize = 42;

        private string Text;
        private TTFFont Font;

        internal H1(string Text, TTFFont Font) : base(FontSize + 10)
        {
            this.Text = Text;
            this.Font = Font;
        }

        internal override int RenderTo(Canvas Canvas, int Y)
            => TextRenderer.DrawString(Canvas, FontSize, 25, Y + FontSize, Canvas.Width, Text, Font, Color.Black, true);
    }
}