using PrismAPI.Graphics;

namespace cosmos_markdown
{
    internal abstract class Rule
    {
        internal int Size;

        protected Rule(int Size) => this.Size = Size;

        internal abstract int RenderTo(Canvas Canvas, int Y);
    }
}