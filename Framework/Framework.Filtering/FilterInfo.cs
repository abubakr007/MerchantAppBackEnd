using Framework.Filtering.Enums;

namespace Framework.Filtering
{
    public class FilterInfo
    {
        public Logical Logical { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public Operator Operator { get; set; } = Operator.Contains;
    }
}
