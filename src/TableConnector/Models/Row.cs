using TableConnector.Contracts;

namespace TableConnector.Models
{
    internal class Row<T> : IRow<T> where T : class, new()
    {
        public IReadOnlyCollection<IColumn<T>> Columns { get; set; }

        public Row(IReadOnlyCollection<IColumn<T>> columns)
        {
            Columns = columns;
        }

        public Row() : this(new List<IColumn<T>>()) { }
    }
}
