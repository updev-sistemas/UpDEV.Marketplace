
using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Common.Enumerables;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class CityMap : ClassMap<CityEntity>
    {
        public CityMap()
        {
            Table("cities");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            References<MacroRegionEntity>(p => p.MacroRegion!).Column("macro_regions_id").Nullable();

            Map(p => p.Name).Column("name").Nullable();
            Map(p => p.IbgeCode).Column("ibge_code").Nullable();
            Map(p => p.DDD).Column("ddd").Nullable();
            Map(p => p.Zone).Column("id_zone").CustomType<CityZone>().Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
