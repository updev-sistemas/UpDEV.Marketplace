using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.Entities
{
    public class PersonAddressEntity : EntityBase
    {
        public virtual PersonEntity? Person { get; set; }
        public virtual CityEntity? City { get; set; }
        public virtual AddressType? Type { get; set; }
        public virtual string? Label { get; set; }
        public virtual string? Streetname { get; set; }
        public virtual string? District { get; set; }
        public virtual string? Complement { get; set; }
    }
}
