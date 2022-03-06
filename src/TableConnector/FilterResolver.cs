using TableConnector.Contracts;

namespace TableConnector
{
    public class FilterResolver
    {
        public static bool TryGet<TFilter>(IReadOnlyCollection<ITableFilter> all_filter, out TFilter? reuslt_filter) where TFilter : ITableFilter
        {
            reuslt_filter = default;

            foreach (var filter in all_filter)
            {
                if (filter is TFilter casted)
                {
                    reuslt_filter = casted;
                    return true;
                }
            }

            return false;
        }
    }
}
