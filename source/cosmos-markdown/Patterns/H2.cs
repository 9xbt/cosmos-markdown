namespace cosmos_markdown.Patterns
{
    internal class H2 : Pattern
    {
        internal override string ThePattern => "^## (.+)$";

        internal override string TheType => "H2";
    }
}