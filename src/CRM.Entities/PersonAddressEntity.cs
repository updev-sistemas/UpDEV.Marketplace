using UpDEV.Marketplace.Domains.Common.Database;
using UpDEV.Marketplace.Domains.Miscelaneas.Entities;

namespace UpDEV.Marketplace.Domains.CRM.Entities
{
    public class PersonAddressEntity : EntityBase
    {
        public virtual PersonEntity? Person { get; set; }
        public virtual CityEntity? City { get; set; }
        public virtual string? Label { get; set; }
        public virtual string? Streetname { get; set; }
        public virtual int? Number { get; set; }
        public virtual string? Complement { get; set; }
        public virtual string? District { get; set; }
        public virtual string? Postcode { get; set; }
    }
}
