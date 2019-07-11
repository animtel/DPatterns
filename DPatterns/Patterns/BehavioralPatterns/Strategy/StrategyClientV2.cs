using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.BehavioralPatterns.Strategy
{
    public class StrategyClientV2 : IClient
    {
        public StrategyClientV2()
        {
            Execute();
        }

        public void Execute()
        {
            var tp = new TextProcessor();
            tp.SetOutPutFormat(OutPutFormat.Markdown);
            tp.AppendList(new[] {"test1", "test2", "test3"});
            System.Console.WriteLine(tp);

            tp.Clear();
            tp.SetOutPutFormat(OutPutFormat.Html);
            tp.AppendList(new[] {"test4", "test5", "test6"});
            System.Console.WriteLine(tp);

            tp.Clear();
        }
    }

    public class TextProcessor
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy listStrategy;

        public void SetOutPutFormat(OutPutFormat format)
        {
            switch (format)
            {
                case OutPutFormat.Html:
                    listStrategy = new HtmlListStrategy();
                    break;
                case OutPutFormat.Markdown:
                    listStrategy = new MarkdownListStrategy();
                    break;
            }
        }

        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);
            foreach (var item in items)
            {
                listStrategy.AddListItem(sb, item);
            }
            listStrategy.End(sb);
        }

        public override string ToString()
        {
            return sb.ToString();
        }

        public StringBuilder Clear(){
            return sb.Clear();
        }
    }

    public enum OutPutFormat
    {
        Markdown, Html
    }

    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }

    public class HtmlListStrategy : IListStrategy
    {
        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"    <li>{item}</li>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }

        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }
    }

    public class MarkdownListStrategy : IListStrategy
    {
        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"  *  {item}");
        }

        public void End(StringBuilder sb)
        {
        }

        public void Start(StringBuilder sb)
        {
        }
    }
}