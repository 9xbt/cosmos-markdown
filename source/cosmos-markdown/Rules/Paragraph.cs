using PrismAPI.Graphics;

namespace cosmos_markdown.Rules
{
    internal class Paragraph : Rule
    {
        internal override (int X, int Y) RenderTo(Canvas Canvas, int X, int Y) => (0, 36);
    }
}