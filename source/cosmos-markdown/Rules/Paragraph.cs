using System;
using CosmosTTF;
using System.Drawing;
using PrismColor = PrismAPI.Graphics.Color;

namespace cosmos_markdown.Rules
{
    internal class Paragraph : Rule
    {
        private string Text;
        private TTFFont Font;
        private Surface Surface;

        internal Paragraph(string Text, TTFFont Font) : base(Font.CalculateWidth(Text, 19), 19)
        {
            this.Text = Text;
            this.Font = Font;

            Surface = new Surface(Canvas);
        }

        internal override void Render()
        {
            Canvas.Clear(PrismColor.White);
            Font.DrawToSurface(Surface, Size, 0, Size, Text, Color.Black);
            //Canvas.(Color.Black, "Testing", "MonaSans-Regular", 14, new Point(0, 14));
            //Proxy.DrawStringTTF(Color.Black, Text, Font, Size, new Point(0, 0));
        }
    }
}