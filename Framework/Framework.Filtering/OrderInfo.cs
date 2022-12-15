using Framework.Filtering.Enums;

namespace Framework.Filtering
{
    public class OrderInfo
    {
        public OrderType OrderType { get; set; } = OrderType.ASC;
        public string Property { get; set; }
    }
}
