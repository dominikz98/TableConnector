using TableConnector.Contracts;
using TableConnector.Exceptions;

namespace TableConnector.Models
{
    public class ColumnRenderer<T> : Column<T>, IColumnRenderer<T> where T : class, new()
    {
        private Func<T, string>? _renderAccessor;
        public Func<T, string> RenderAccessor
        {
            get
            {
                if (_renderAccessor is null)
                    throw new AccessorNotSetException(nameof(RenderAccessor));

                return _renderAccessor;
            }
            set { _renderAccessor = value; }
        }

        private Func<T, string>? _printAccessor;
        public Func<T, string> PrintAccessor
        {
            get { return _printAccessor ?? new Func<T, string>((entry) => RenderAccessor(entry)?.ToString() ?? string.Empty); }
            set { _printAccessor = value; }
        }
    }
}
