using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Miscelaneas.Entities
{
    public class MacroRegionEntity : EntityBase
    {
        public virtual StateEntity? State { get; set; }
        public virtual string? Name { get; set; }
        public virtual bool? IsActive { get; set; }
    }
}
