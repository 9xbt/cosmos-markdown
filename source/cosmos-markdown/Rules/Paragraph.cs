using cosmos_markdown.Tools;
using CosmosTTF;
using PrismAPI.Graphics;
using Color = System.Drawing.Color;

namespace cosmos_markdown.Rules
{
    internal class Paragraph : Rule
    {
        private const int FontSize = 18;

        private string Text;
        private TTFFont Font;

        internal Paragraph(string Text, TTFFont Font) : base(Text.Trim().Length == 0 ? 10 : FontSize + 10)
        {
            this.Text = Text.Trim();
            this.Font = Font;
        }

        internal override int RenderTo(Canvas Canvas, int Y)
            => TextRenderer.DrawString(Canvas, FontSize, 25, Y + FontSize, Canvas.Width, Text, Font, Color.Black, false);
    }
}