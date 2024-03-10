namespace cosmos_markdown.Patterns
{
    internal class Paragraph : Pattern
    {
        internal override string ThePattern => "^\\s*$";

        internal override string TheType => "Paragraph";
    }
}