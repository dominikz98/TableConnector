using TableConnector.Models;

namespace TableConnector.Contracts
{
    public interface ITable<T> where T : class, new()
    {
        IColumnRenderer<T>[] Columns { get; }

        Task<IReadOnlyCollection<T>> Request(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<T>> Request(CancellationToken cancellationToken);
        
        Task<FilledTable<T>> Render(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken);
        Task<FilledTable<T>> Render(CancellationToken cancellationToken);

        Task<IReadOnlyCollection<IRow<T>>> Print(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<IRow<T>>> Print(CancellationToken cancellationToken);
    }
}
