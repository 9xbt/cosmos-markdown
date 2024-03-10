using System;
using System.Linq;
using PrismAPI.Graphics;
using System.Collections.Generic;
using cosmos_markdown.regex.RegularExpressions;
using Microsoft.VisualBasic;

namespace cosmos_markdown
{
    internal class Parser
    {
        internal static Pattern[] Patterns = new Pattern[]
        {
            new Patterns.Paragraph(),
            new Patterns.H1(),
            new Patterns.H2(),
            new Patterns.H3(),
            new Patterns.Link(),
            new Patterns.Text()
        };

        internal Renderer Renderer;
        internal Font Font;
        internal List<string> Document;

        internal List<Rule> Rules;

        internal Parser(Renderer Renderer, string[] Document, Font Font)
        {
            this.Renderer = Renderer;
            this.Document = Document.ToList();
            this.Font = Font;

            Rules = new List<Rule>();
            LastRule = new Rules.Text("", Font.Regular);
        }

        internal void ParseDocument()
        {
            for (int i = 0; i < Document.Count; i++)
            {
                ParseLine(i);

                Renderer.Canvas!.DrawFilledRectangle(0, 0, Renderer.Canvas.Width, 16, 0, Color.White);
                Renderer.Canvas!.DrawString(0, Renderer.Canvas.Height - 16, "Parsing document... " + (i / Document.Count * 100) + "%", default, Color.Black);
                Renderer.Update?.Invoke();
            }
        }

        private Rule LastRule;

        private void ParseLine(int index)
        {
            var temp = Document[index].Trim();

            var rules = new List<Rule>();
            var indexes = new List<int>();

            foreach (Pattern pattern in Patterns)
            {
                Regex regex = new Regex(pattern.ThePattern);
                Match match = regex.Match(temp);

                if (!match.Success) continue;

                var groups = match.Groups;
                temp = temp.Substring(0, match.Index); // TODO: fix this
                indexes.Add(match.Index);

                switch (pattern.TheType)
                {
                    case "Paragraph":
                        if (IsLastRuleSingleLine) continue;

                        LastRule = new Rules.Paragraph();
                        Rules.Add(LastRule);

                        goto EndOfParse;

                    case "H1":
                        LastRule = new Rules.H1(groups[1].Value.Trim(), Font.Bold);
                        rules.Add(LastRule);

                        goto EndOfParse;

                    case "H2":
                        LastRule = new Rules.H2(groups[1].Value.Trim(), Font.Bold);
                        rules.Add(LastRule);

                        goto EndOfParse;

                    case "H3":
                        LastRule = new Rules.H3(groups[1].Value.Trim(), Font.Bold);
                        rules.Add(LastRule);

                        goto EndOfParse;

                    case "Link":
                        LastRule = new Rules.Link(groups[1].Value.Trim(), Font.Regular);
                        rules.Add(LastRule);

                        continue;

                    case "Text":
                        if (groups[1].Value.Trim().Length == 0) break;

                        LastRule = new Rules.Text(groups[1].Value.Trim(), Font.Regular);
                        rules.Add(LastRule);

                        break;
                }

                temp += temp.Substring(match.Index + match.Length);
            }

        EndOfParse:
            SortRules(indexes, rules);
            Rules.AddRange(rules);
        }

        private bool IsLastRuleSingleLine
        {
            get
            {
                var type = LastRule.GetType();

                return type == typeof(Rules.H1) || type == typeof(Rules.H2) ||
                    type == typeof(Rules.H3) || type == typeof(Rules.Paragraph);
            }
        }

        private static void SortRules(List<int> indexes, List<Rule> rules)
        {
            int n = Math.Min(indexes.Count, rules.Count);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (indexes[j] > indexes[j + 1])
                    {
                        var temp = rules[j];

                        rules[j] = rules[j + 1];
                        rules[j + 1] = temp;
                    }
                }
            }
        }
    }
}