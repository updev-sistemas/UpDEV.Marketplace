using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.Entities
{
    public class SkuEntity : EntityBase
    {
        public virtual TablePriceEntity? TablePrice { get; set; }
        public virtual ProductEntity? Product { get; set; }
        public virtual BrandEntity? Brand { get; set; }
        public virtual PackageEntity? Package { get; set; }
        public virtual UnitEntity? Unit { get; set; }
        public virtual OriginDefault? Origin { get; set; }
        public virtual PersonEntity? User { get; set; }
        public virtual decimal? Factor { get; set; }
        public virtual decimal? Cost { get; set; }
        public virtual decimal? MinCost { get; set; }
        public virtual decimal? MaxCost { get; set; }
    }
}
