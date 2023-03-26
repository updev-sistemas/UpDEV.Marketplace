using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Catalog
{
    public class UnitEntity : EntityBase
    {
        public virtual string? Name { get; set; }
        public virtual string? Sigla { get; set; }
    }
}