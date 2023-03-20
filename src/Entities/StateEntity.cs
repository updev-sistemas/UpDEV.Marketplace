namespace UpDEV.Marketplace.Domains.Entities
{
    public class StateEntity : EntityBase
    {
        public virtual RegionEntity? Region { get; set; }
        public virtual string? Name { get; set; }
    }
}
