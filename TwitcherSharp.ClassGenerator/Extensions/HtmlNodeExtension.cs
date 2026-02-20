using HtmlAgilityPack;

namespace ClassGenerator.Extensions;

public static class HtmlNodeExtension
{
    extension(HtmlNode node)
    {
        // Taking the next Sibling or child can often result in a TextNode. We don't really want those, se we just skip them.
        public HtmlNode GetNextElementSibling()
        {
            var nextNode = node.NextSibling;
            while (nextNode.NodeType != HtmlNodeType.Element)
            {
                nextNode = nextNode.NextSibling;
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if(nextNode == null) return null;
            }
            return nextNode;
        }
        
        public HtmlNode GetFirstElementChild()
        {
            var child = node.FirstChild;
            while (child.NodeType != HtmlNodeType.Element)
            {
                child = child.NextSibling;
            }
            return child;
        }
    }
}