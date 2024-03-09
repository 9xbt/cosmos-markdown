using System.Collections.Generic;
using cosmos_markdown.regex.RegularExpressions;

namespace cosmos_markdown
{
    internal class MarkdownParser
    {
        internal static Pattern[] Patterns = new Pattern[]
        {
            new Patterns.H1(),
            new Patterns.H2(),
            new Patterns.H3(),
            new Patterns.Paragraph()
        };

        internal string[] Document;

        internal Font Font;
        internal List<Rule> Rules;

        internal MarkdownParser(string[] Document, Font Font)
        {
            this.Document = Document;
            this.Font = Font;

            Rules = new List<Rule>();
        }

        internal void ParseDocument()
        {
            foreach (string line in Document)
            {
                ParseLine(line.Trim());
            }
        }

        private void ParseLine(string line)
        {
            foreach (Pattern pattern in Patterns)
            {
                Regex regex = new Regex(pattern.ThePattern);
                Match match = regex.Match(line.Trim());

                if (!match.Success) continue;

                string output = match.Groups[1].Value;

                switch (pattern.TheType)
                {
                    case "H1":
                        Rules.Add(new Rules.H1(output, Font.Bold));
                        return;

                    case "H2":
                        Rules.Add(new Rules.H2(output, Font.Bold));
                        return;

                    case "H3":
                        Rules.Add(new Rules.H3(output, Font.Bold));
                        return;

                    case "Paragraph":
                        Rules.Add(new Rules.Paragraph(output, Font.Regular));
                        return;
                }
            }
        }
    }
}