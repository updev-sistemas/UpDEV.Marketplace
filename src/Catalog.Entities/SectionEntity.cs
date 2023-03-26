using UpDEV.Marketplace.Domains.Common.Database;
using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.Catalog
{
    public class SectionEntity : EntityBase
    {
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual bool? IsVirtual { get; set; }
        public virtual ProductSectionType? TypeEnvironment { get; set; }
    }
}