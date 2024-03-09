using PrismAPI.Graphics;

namespace cosmos_markdown
{
    public static class Renderer
    {
        /// <summary>
        /// Renders a Markdown document to a <see cref="Canvas"/>
        /// </summary>
        /// <param name="Canvas">The canvas to render the document to</param>
        /// <param name="Document">The Markdown document to render</param>
        /// <param name="Font">The font to use by renderer</param>
        public static void RenderMarkdownDocument(this Canvas Canvas, string[] Document, Font Font)
        {
            var parser = new Parser(Document, Font);
            parser.ParseMarkdown();

            int y = 30;
            foreach (var element in parser.Elements)
            {
                element.Render();
                Canvas.DrawImage(30, y, element.Canvas, false);

                y += element.Size + 8;
            }
        }
    }
}