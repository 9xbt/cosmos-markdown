﻿using CosmosTTF;
using PrismAPI.Graphics;
using cosmos_markdown.Tools;
using Color = System.Drawing.Color;

namespace cosmos_markdown.Rules
{
    internal class H2 : Rule
    {
        private const int FontSize = 34;

        private string Text;
        private TTFFont Font;

        internal H2(string Text, TTFFont Font)
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