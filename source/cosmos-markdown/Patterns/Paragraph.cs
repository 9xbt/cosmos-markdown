namespace cosmos_markdown.Patterns
{
    internal class Paragraph : Pattern
    {
        internal override string ThePattern => "^(.*?)$";

        internal override string TheType => "Paragraph";
    }
}