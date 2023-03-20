using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.Entities
{
    public class CityEntity : EntityBase
    {
        public virtual MacroRegionEntity? MacroRegion { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? IbgeCode { get; set; }
        public virtual int? DDD { get; set; }
        public virtual CityZone? Zone { get; set; }
    }
}
