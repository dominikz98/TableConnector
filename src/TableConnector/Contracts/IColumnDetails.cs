namespace TableConnector.Contracts
{
    public interface IColumnDetails
    {
        IReadOnlyCollection<ILink> Links { get; }
        IReadOnlyCollection<IImage> Images { get; }
        IReadOnlyCollection<ICSS> CSS { get; }
    }

    public interface ILink
    {

    }

    public interface IImage
    {

    }

    public interface ICSS
    {

    }
}
