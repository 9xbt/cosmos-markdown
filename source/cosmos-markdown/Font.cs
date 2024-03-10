using CosmosTTF;

namespace cosmos_markdown
{
    public struct Font
    {
        public TTFFont Regular;
        public TTFFont Bold;
        public TTFFont Italic;
        public TTFFont BoldItalic;

        public Font(TTFFont Regular, TTFFont Bold, TTFFont Italic, TTFFont BoldItalic)
        {
            this.Regular = Regular;
            this.Bold = Bold;
            this.Italic = Italic;
            this.BoldItalic = BoldItalic;
        }
    }
}