using System;
using System.Collections.Generic;
using cosmos_markdown.regex.RegularExpressions;

namespace cosmos_markdown
{
    internal class Parser
    {
        internal static Pattern[] Patterns = new Pattern[]
        {
            new Patterns.Paragraph()
        };

        internal string[] Document;

        internal Font Font;
        internal List<Rule> Elements;

        internal Parser(string[] Document, Font Font)
        {
            this.Document = Document;
            this.Font = Font;

            Elements = new List<Rule>();
        }

        internal void ParseMarkdown()
        {
            foreach (string line in Document)
            {
                foreach (Pattern pattern in Patterns)
                {
                    Regex regex = new Regex(pattern.ThePattern);
                    Match match = regex.Match(line);

                    if (!match.Success) continue;

                    string output = match.Groups[1].Value;

                    switch (pattern.TheType)
                    {
                        case "Paragraph":
                            Elements.Add(new Rules.Paragraph(output, Font.Regular));
                            break;
                    }
                }
            }
        }
    }
}