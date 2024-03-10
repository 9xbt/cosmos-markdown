#define __RULE_DEBUG__

using System;
using PrismAPI.Graphics;

namespace cosmos_markdown
{
    public class Renderer
    {
        internal Canvas? Canvas;
        internal Action? Update;

        /// <summary>
        /// Renders a Markdown document to a <see cref="Canvas"/>
        /// </summary>
        /// <param name="Canvas">The canvas to render the document to</param>
        /// <param name="Document">The Markdown document to render</param>
        /// <param name="Font">The font to use by renderer</param>
        /// <param name="Update">Called when an item finishes rendering</param>
        public void RenderMarkdownDocument(Canvas Canvas, string[] Document, Font Font, Action Update)
        {
            this.Canvas = Canvas;
            this.Update = Update;

            var parser = new Parser(this, Document, Font);
            parser.ParseDocument();

#if __RULE_DEBUG__
            int x = 25, y = 25;

            Canvas.DrawString(0, 0, "Rule count: " + parser.Rules.Count, default, Color.Black);

            for (int i = 0; i < parser.Rules.Count; i++)
            {
                var rule = parser.Rules[i];

                Canvas.DrawString(0, (i + 1) * 16, rule.GetType().ToString(), default, Color.Black);
                y += 16;
            }
#else
            int x = 25, y = 25;
#endif

            for (int i = 0; i < parser.Rules.Count; i++)
            {
                var rule = parser.Rules[i];
                var size = rule.RenderTo(Canvas, x, y);

                x = size.X == 0 ? 25 : x + size.X;
                y += size.Y;

                Canvas.DrawFilledRectangle(0, 0, Canvas.Width, 16, 0, Color.White);
                Canvas.DrawString(0, Canvas.Height - 16, "Rendering items... " + (i / parser.Rules.Count * 100) + "%", default, Color.Black);
                Update?.Invoke();
            }
        }
    }
}