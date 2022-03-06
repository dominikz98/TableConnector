using TableConnector.Contracts;

namespace TableConnector.Models
{
    public class Column<T> : IColumn<T> where T : class, new()
    {
        public string Header { get; set; }

        public string Name { get; set; }

        public string Value { get; internal set; }

        public bool IsPrintable { get; set; }
        public bool IsHidden { get; set; }

        public T Data { get; internal set; }

        public IColumnDetails Details { get; set; }

        public Column(string header, string name, string value, bool isPrintable, bool isHidden, T data, IColumnDetails definition)
        {
            Header = header;
            Name = name;
            Value = value;
            IsPrintable = isPrintable;
            IsHidden = isHidden;
            Data = data;
            Details = definition;
        }

        public Column(string header, string name, string value, T data, IColumnDetails definition) : this(header, name, value, true, false, data, definition) { }

        public Column() : this(string.Empty, string.Empty, string.Empty, new(), new ColumnDetails()) { }
    }
}
