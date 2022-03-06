namespace TableConnector.Exceptions
{
    public class MissingColumnInfoException : ArgumentException
    {
        public string? Property { get; set; }
        public string? Details { get; set; }

        public MissingColumnInfoException(string? property, string? details)
            : base($"Missing {(property ?? "info")} in column definitions!{(details != null ? Environment.NewLine + details : string.Empty)}")
        {
            Property = property;
            Details = details;
        }
    }
}
