using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Catalog
{
    public class ProductPropertyEntity : EntityBase
    {
        public virtual string? Key { get; set; }
        public virtual string? Value { get; set; }
        public virtual bool? IsMandatory { get; set; }
    }
}