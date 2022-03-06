namespace TableConnector.Contracts
{
    public interface IColumn<T> where T : class, new()
    {
        string Header { get; }
        string Name { get; }
        string Value { get; }
        
        bool IsPrintable { get; }
        bool IsHidden { get; }

        public IColumnDetails Details { get; }
        T Data { get; }
    }
}
