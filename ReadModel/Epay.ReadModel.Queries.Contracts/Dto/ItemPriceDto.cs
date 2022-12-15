namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class ItemPriceDto
    {
        public double? BuyingPrice { get; set; }
        public double SellingPrice { get; set; }
        public double DiscountRange { get; set; }
        public bool IsOpenPrice { get; set; }
        public bool IsOpenQuantity { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
    }
}
