using CosmosTTF;
using PrismAPI.Graphics;
using cosmos_markdown.Tools;
using Color = System.Drawing.Color;

namespace cosmos_markdown.Rules
{
    internal class Link : Rule
    {
        private const int FontSize = 18;

        private string Text;
        private TTFFont Font;

        internal Link(string Text, TTFFont Font)
        {
            this.Text = Text;
            this.Font = Font;
        }

        internal override (int X, int Y) RenderTo(Canvas Canvas, int X, int Y)
            => TextRenderer.DrawString(Canvas, FontSize, X, Y + FontSize, Canvas.Width, Text + ' ', Font, Color.FromArgb(0x7F0969DA), true, true, false, 0xFF0969DA);
    }
}