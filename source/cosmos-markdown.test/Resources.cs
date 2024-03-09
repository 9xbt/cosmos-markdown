using CosmosTTF;
using System.Text;
using IL2CPU.API.Attribs;

namespace cosmos_markdown.test
{
    internal static class Resources
    {
        [ManifestResourceStream(ResourceName = "cosmos-markdown.test.Resources.MonaSans-Regular.ttf")] static byte[] _rawFont;
        [ManifestResourceStream(ResourceName = "cosmos-markdown.test.Resources.Example.md")] private static byte[] _rawMarkdown;

        internal static TTFFont Font = new TTFFont(_rawFont);
        internal static string Markdown = Encoding.UTF8.GetString(_rawMarkdown);
    }
}