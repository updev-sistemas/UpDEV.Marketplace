
using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Common.Enumerables;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class PersonAddressMap : ClassMap<PersonAddressEntity>
    {
        public PersonAddressMap()
        {
            Table("people_addresses");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            References<PersonEntity>(p => p.Person!).Column("person_id");
            References<CityEntity>(p => p.City!).Column("city_id");

            Map(p => p.Type).CustomType<AddressType>().Column("id_type").Nullable();
            Map(p => p.Label).Column("label").Nullable();
            Map(p => p.Streetname).Column("streetname").Nullable();
            Map(p => p.District).Column("district").Nullable();
            Map(p => p.Complement).Column("complement").Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
