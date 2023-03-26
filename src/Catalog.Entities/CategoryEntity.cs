using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Catalog.Entities
{
    public class CategoryEntity : EntityBase
    {
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual SectionEntity? Section { get; set; }
    }
}