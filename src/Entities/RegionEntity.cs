namespace UpDEV.Marketplace.Domains.Entities
{
    public class RegionEntity : EntityBase
    {
        public virtual CountryEntity? Country { get; set; }
        public virtual string? Name { get; set; }
    }
}
