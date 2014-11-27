using System;
using System.Linq;
using System.Xml.Linq;

namespace Bizagi.Util
{
    using System.Globalization;

    public static class XElementExtensions
    {
        public static string GetAbsoluteXPath(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            Func<XElement, string> relativeXPath = e =>
            {
                var index = e.IndexPosition();
                var name = e.Name.LocalName;

                return (index == -1)
                    ? "/" + name
                    : string.Format("/{0}[{1}]", name, index.ToString(CultureInfo.InvariantCulture));
            };

            var ancestors = from e in element.Ancestors() select relativeXPath(e);

            return string.Concat(ancestors.Reverse().ToArray()) + relativeXPath(element);
        }

        public static int IndexPosition(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (element.Parent == null)
            {
                return -1;
            }

            var i = 1; // Indexes for nodes start at 1, not 0

            foreach (var sibling in element.Parent.Elements(element.Name))
            {
                if (sibling == element)
                {
                    return i;
                }

                i++;
            }

            throw new InvalidOperationException("element has been removed from its parent.");
        }
    }
}
