namespace cosmos_markdown.Patterns
{
    internal class H3 : Pattern
    {
        internal override string ThePattern => "^### (.+)$";

        internal override string TheType => "H3";
    }
}