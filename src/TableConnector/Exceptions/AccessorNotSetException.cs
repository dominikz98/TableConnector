namespace TableConnector.Exceptions
{
    public class AccessorNotSetException : ArgumentException
    {
        public string Accessor { get; set; }
        public AccessorNotSetException(string accessor) : base($"{accessor} not set in column definitions!")
        {
            Accessor = accessor;
        }
    }
}
