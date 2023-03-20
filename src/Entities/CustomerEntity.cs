namespace UpDEV.Marketplace.Domains.Entities
{
    public class CustomerEntity : EntityBase
    {
        public virtual bool? IsActive { get; set; }
        public virtual PersonEntity? Person { get; set; }
    }
}
