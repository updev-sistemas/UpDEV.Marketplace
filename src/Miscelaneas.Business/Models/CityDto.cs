using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models
{
    public class CityDto
    {
        public virtual long? Id { get; set; }
        public virtual MacroRegionDto? MacroRegion { get; set; }
        public virtual string? IbgeCode { get; set; }
        public virtual string? Name { get; set; }
        public virtual int? DDD { get; set; }
        public virtual float? Latitude { get; set; }
        public virtual float? Longitude { get; set; }
        public virtual float? Perimeter { get; set; }
        public virtual CityZone? Zone { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
    }
}
