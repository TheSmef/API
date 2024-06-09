namespace API.Attributes
{
    /// <summary>
    /// Аттрибут для установки значения строки для Enum
    /// </summary>
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; set; }
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
    }
}
