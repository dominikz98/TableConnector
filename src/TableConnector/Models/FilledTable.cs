using TableConnector.Contracts;

namespace TableConnector.Models
{
    public class FilledTable<T> where T : class, new()
    {
        public string Name { get; set; }
        public IReadOnlyCollection<IRow<T>> Rows { get; set; }

        public FilledTable(string name, IReadOnlyCollection<IRow<T>> rows)
        {
            Name = name;
            Rows = rows;
        }

        public FilledTable() : this(string.Empty, new List<IRow<T>>()) { }
    }
}
