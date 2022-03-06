using TableConnector.Contracts;
using TableConnector.Exceptions;
using TableConnector.Models;

namespace TableConnector
{
    internal static class TableRenderer
    {
        public static IReadOnlyCollection<IRow<T>> Render<T>(IReadOnlyCollection<T> data, IReadOnlyCollection<IColumnRenderer<T>> columns) where T : class, new()
            => Internal(data, columns, (column, entry) => column.RenderAccessor(entry));

        public static IReadOnlyCollection<IRow<T>> Print<T>(IReadOnlyCollection<T> data, IReadOnlyCollection<IColumnRenderer<T>> columns) where T : class, new()
            => Internal(data, columns, (column, entry) => column.PrintAccessor(entry));

        private static IReadOnlyCollection<IRow<T>> Internal<T>(IReadOnlyCollection<T> data, IReadOnlyCollection<IColumnRenderer<T>> columns, Func<IColumnRenderer<T>, T, string> render) where T : class, new()
        {
            var rows = new List<IRow<T>>();
            foreach (var entry in data)
            {
                var columnData = new List<IColumn<T>>();
                foreach (var column in columns)
                {
                    if (column is Column<T> setable)
                        setable.Value = render(column, entry);

                    // verify header
                    if (string.IsNullOrWhiteSpace(column.Header))
                        throw new MissingColumnInfoException(nameof(Column<T>.Header), "Header needs to be set, otherwise client can't map and assign columns explicitly!");

                    columnData.Add(column);
                }

                // verify unique header
                var errors = columnData.GroupBy(x => x.Header)
                    .Where(x => x.Count() > 1)
                    .Select(x => x.First().Header);

                foreach (var error in errors)
                    throw new HeaderNotUniqueException(error);

                rows.Add(new Row<T>(columnData));
            }
            return rows;
        }
    }
}
