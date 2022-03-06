namespace TableConnector.Contracts
{
    public interface IColumnRenderer<T> : IColumn<T> where T : class, new()
    {
        Func<T, string> RenderAccessor { get; }
        Func<T, string> PrintAccessor { get; }
    }
}
