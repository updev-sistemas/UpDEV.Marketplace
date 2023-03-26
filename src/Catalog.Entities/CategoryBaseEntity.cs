using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Catalog
{
    public abstract class CategoryBaseEntity : EntityBase
    {
        public virtual string? Name { get; set; }
        public virtual SectionEntity? Section { get; set; }
    }
}