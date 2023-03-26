using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Catalog.Entities
{
    public class ItemPropertyEntity : EntityBase
    {
        public virtual ItemEntity? Item { get; set; }
        public virtual string? Key { get; set; }
        public virtual string? Value { get; set; }
        public virtual bool? IsMandatory { get; set; }
    }
}