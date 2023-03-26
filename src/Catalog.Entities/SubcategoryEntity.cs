using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Catalog.Entities
{
    public class SubcategoryEntity : EntityBase
    {
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual CategoryEntity? Category { get; set; }
    }
}