using CosmosTTF;
using System.Text;
using IL2CPU.API.Attribs;

namespace cosmos_markdown.test
{
    internal static class Resources
    {
        [ManifestResourceStream(ResourceName = "cosmos-markdown.test.Resources.MonaSans-Regular.ttf")] static byte[] _rawRegular;
        [ManifestResourceStream(ResourceName = "cosmos-markdown.test.Resources.MonaSans-Bold.ttf")] static byte[] _rawBold;
        [ManifestResourceStream(ResourceName = "cosmos-markdown.test.Resources.MonaSans-Italic.ttf")] static byte[] _rawItalic;
        [ManifestResourceStream(ResourceName = "cosmos-markdown.test.Resources.MonaSans-BoldItalic.ttf")] static byte[] _rawBoldItalic;
        [ManifestResourceStream(ResourceName = "cosmos-markdown.test.Resources.Example.md")] internal static byte[] _rawMarkdown;

        internal static TTFFont Regular = new TTFFont(_rawRegular);
        internal static TTFFont Bold = new TTFFont(_rawBold);
        internal static TTFFont Italic = new TTFFont(_rawItalic);
        internal static TTFFont BoldItalic = new TTFFont(_rawBoldItalic);
        internal static string[] Markdown = Encoding.UTF8.GetString(_rawMarkdown).Split('\n');
    }
}