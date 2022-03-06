using TableConnector.Contracts;

namespace TableConnector.Models
{
    internal class ColumnDetails : IColumnDetails
    {
        public IReadOnlyCollection<ILink> Links { get; set; }

        public IReadOnlyCollection<IImage> Images { get; set; }

        public IReadOnlyCollection<ICSS> CSS { get; set; }

        public ColumnDetails(IReadOnlyCollection<ILink> links, IReadOnlyCollection<IImage> images, IReadOnlyCollection<ICSS> cSS)
        {
            Links = links;
            Images = images;
            CSS = cSS;
        }

        public ColumnDetails() : this(new List<ILink>(), new List<IImage>(), new List<ICSS>()) { }
    }
}
