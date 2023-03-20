
using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class RegionMap : ClassMap<RegionEntity>
    {
        public RegionMap()
        {
            Table("regions");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            References<CountryEntity>(p => p.Country!).Column("country_id");

            Map(p => p.Name).Column("name").Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
