using UpDEV.Marketplace.Domains.Common.Database;
using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.Miscelaneas.Entities
{
    public class CityEntity : EntityBase
    {
        public virtual MacroRegionEntity? MacroRegion { get; set; }
        public virtual string? IbgeCode { get; set; }
        public virtual string? Name { get; set; }
        public virtual int? DDD { get; set; }
        public virtual float? Latitude { get; set; }
        public virtual float? Longitude { get; set; }
        public virtual float? Perimeter { get; set; }
        public virtual CityZone? Zone { get; set; }
    }
}
