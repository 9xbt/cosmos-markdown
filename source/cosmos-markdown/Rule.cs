using System;
using PrismAPI.Graphics;

namespace cosmos_markdown
{
    internal abstract class Rule
    {
        internal abstract (int X, int Y) RenderTo(Canvas Canvas, int X, int Y);
    }
}