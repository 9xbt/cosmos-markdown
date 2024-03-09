using CosmosTTF;

namespace cosmos_markdown
{
    public struct Font
    {
        public TTFFont Regular;
        public TTFFont Bold;
        public TTFFont Italic;

        public Font(TTFFont Regular, TTFFont? Bold = default, TTFFont? Italic = default)
        {
            this.Regular = Regular;
            this.Bold = Bold == default ? Regular : Bold;
            this.Italic = Italic == default ? Regular : Italic;
        }
    }
}