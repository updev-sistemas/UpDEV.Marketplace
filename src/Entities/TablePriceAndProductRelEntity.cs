namespace UpDEV.Marketplace.Domains.Entities
{
    public class TablePriceAndProductRelEntity : EntityBase
    {
        public virtual TablePriceEntity? TablePrice { get; set; }
        public virtual ProductEntity? Product { get; set; }
    }
}
