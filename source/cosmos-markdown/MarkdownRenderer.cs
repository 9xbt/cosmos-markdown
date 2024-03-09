#define __RULE_DEBUG__

using PrismAPI.Graphics;
using System.Collections.Generic;

namespace cosmos_markdown
{
    public static class MarkdownRenderer
    {
        /// <summary>
        /// Renders a Markdown document to a <see cref="Canvas"/>
        /// </summary>
        /// <param name="Canvas">The canvas to render the document to</param>
        /// <param name="Document">The Markdown document to render</param>
        /// <param name="Font">The font to use by renderer</param>
        public static void RenderMarkdownDocument(Canvas Canvas, string[] Document, Font Font)
        {
            var parser = new Parser(Document, Font);
            parser.ParseDocument();

#if __RULE_DEBUG__
            int y = 25;

            Canvas.DrawString(0, 0, "Rule count: " + parser.Rules.Count, default, Color.Black);

            for (int i = 0; i < parser.Rules.Count; i++)
            {
                var rule = parser.Rules[i];

                Canvas.DrawString(0, (i + 1) * 16, rule.GetType().ToString(), default, Color.Black);

                y += 16;
            }

            y += 25;

            /*for (int i = 0; i < Document.Length; i++)
            {
                var line = Document[i];

                Canvas.DrawString(0, (i + 1) * 16, line, default, Color.Black);
            }*/
#else
            int y = 25;
#endif

            foreach (var rule in parser.Rules)
            {
                rule.RenderTo(Canvas, y);
                y += rule.Size;
            }
        }
    }
}