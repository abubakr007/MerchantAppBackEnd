namespace Epay.QueueContext.Domain.Acl.Dto
{
    public class TaxSettingDto
    {
        public bool IsTaxAllowded { get; set; }
        public bool IsTaxExcluded { get; set; }
        public double TaxAmount { get; set; }
    }
}
