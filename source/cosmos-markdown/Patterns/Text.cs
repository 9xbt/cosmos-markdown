namespace cosmos_markdown.Patterns
{
    internal class Text : Pattern
    {
        internal override string ThePattern => "^(.*?)$";

        internal override string TheType => "Text";
    }
}