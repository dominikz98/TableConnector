namespace TableConnector.Contracts
{
    public interface IRow<T> where T : class, new()
    {
        public IReadOnlyCollection<IColumn<T>> Columns { get; set; }
    }
}
