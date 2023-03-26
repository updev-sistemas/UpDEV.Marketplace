using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Miscelaneas.Entities
{
    public class StateEntity : EntityBase
    {
        public virtual RegionEntity? Region { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Uf { get; set; }
    }
}
