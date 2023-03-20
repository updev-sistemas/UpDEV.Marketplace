using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.Entities
{
    public class ProductEntity : EntityBase
    {
        public virtual BrandEntity? Brand { get; set; }
        public virtual CategoryEntity? Category { get; set; }
        public virtual UnitEntity? BasicUnit { get; set; }
        public virtual UnitEntity? SalesUnit { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual string? Thumbnail { get; set; }
        public virtual bool? IsActive { get; set; }
        public virtual bool? IsControlStock { get; set; }
        public virtual decimal? PriceBaseBasicUnit { get; set; }
        public virtual decimal? PriceBaseSalesUnit { get; set; }
        public virtual OriginDefault? Origin { get; set; }
    }
}
