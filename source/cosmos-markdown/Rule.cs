using System;
using PrismAPI.Graphics;

namespace cosmos_markdown
{
    internal abstract class Rule
    {
        internal int Size;
        internal Canvas Canvas;

        protected Rule(int Width, int Height)
        {
            Size = Height;
            Canvas = new Canvas((ushort)Width, (ushort)Height);
        }

        internal abstract void Render();
    }
}