using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Miscelaneas.Entities
{
    public class RegionEntity : EntityBase
    {
        public virtual CountryEntity? Country { get; set; }
        public virtual string? Name { get; set; }
    }
}
