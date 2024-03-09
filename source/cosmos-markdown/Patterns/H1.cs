namespace cosmos_markdown.Patterns
{
    internal class H1 : Pattern
    {
        internal override string ThePattern => "^# (.+)$";

        internal override string TheType => "H1";
    }
}