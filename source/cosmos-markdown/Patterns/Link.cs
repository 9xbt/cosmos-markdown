namespace cosmos_markdown.Patterns
{
    internal class Link : Pattern
    {
        internal override string ThePattern => "\\[([^\\]]+)\\]\\(([^)]+)\\)";

        internal override string TheType => "Link";
    }
}