namespace UpDEV.Marketplace.Domains.Entities
{
    public class TablePriceAndCustomerRelEntity : EntityBase
    {
        public virtual TablePriceEntity? TablePrice { get; set; }
        public virtual PersonEntity? Person { get; set; }
    }
}
