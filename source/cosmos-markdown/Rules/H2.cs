﻿using cosmos_markdown.Tools;
using CosmosTTF;
using PrismAPI.Graphics;
using Color = System.Drawing.Color;

namespace cosmos_markdown.Rules
{
    internal class H2 : Rule
    {
        private const int FontSize = 34;

        private string Text;
        private TTFFont Font;

        internal H2(string Text, TTFFont Font) : base(FontSize + 10)
        {
            this.Text = Text;
            this.Font = Font;
        }

        internal override int RenderTo(Canvas Canvas, int Y)
            => TextRenderer.DrawString(Canvas, FontSize, 25, Y + FontSize, Canvas.Width, Text, Font, Color.Black, true);
    }
}