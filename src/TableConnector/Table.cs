using TableConnector.Contracts;
using TableConnector.Models;

namespace TableConnector
{
    public abstract class Table<T> : ITable<T> where T : class, new()
    {
        public abstract string Name { get; }
        public abstract IColumnRenderer<T>[] Columns { get; }

        public Task<FilledTable<T>> Render(CancellationToken cancellationToken)
            => Render(new List<ITableFilter>(), cancellationToken);

        public async Task<FilledTable<T>> Render(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken)
        {
            var data = await Request(filter, cancellationToken);
            await Intercept(data, Columns);
            var rows = TableRenderer.Render(data, Columns);
            return new FilledTable<T>(Name, rows);
        }


        public Task<IReadOnlyCollection<T>> Request(CancellationToken cancellationToken)
            => Request(new List<ITableFilter>(), cancellationToken);

        public async Task<IReadOnlyCollection<T>> Request(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken)
            => await Load(filter, cancellationToken);


        public Task<IReadOnlyCollection<IRow<T>>> Print(CancellationToken cancellationToken)
            => Print(new List<ITableFilter>(), cancellationToken);

        public async Task<IReadOnlyCollection<IRow<T>>> Print(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken)
        {
            var data = await Request(filter, cancellationToken);
            await Intercept(data, Columns);
            return TableRenderer.Print(data, Columns);
        }


        public abstract Task<IReadOnlyCollection<T>> Load(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken);

        public virtual Task Intercept(IEnumerable<T> data, IEnumerable<IColumnRenderer<T>> columns)
            => Task.CompletedTask;
    }
}
