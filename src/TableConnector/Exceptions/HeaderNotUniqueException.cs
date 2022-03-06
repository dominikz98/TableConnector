namespace TableConnector.Exceptions
{
    public class HeaderNotUniqueException : ArgumentException
    {
        public string Header { get; }

        public HeaderNotUniqueException(string header) : base($"Header {header} is not unique!")
        {
            Header = header;
        }
    }
}
