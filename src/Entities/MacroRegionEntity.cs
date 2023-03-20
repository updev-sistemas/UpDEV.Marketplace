namespace UpDEV.Marketplace.Domains.Entities
{
    public class MacroRegionEntity : EntityBase
    {
        public virtual string? Name { get; set; }
        public virtual StateEntity? State { get; set; }
    }
}
