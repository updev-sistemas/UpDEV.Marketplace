using UpDEV.Marketplace.Domains.Entities;
using FluentNHibernate.Mapping;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class BrandMap : ClassMap<BrandEntity>
    {
        public BrandMap()
        {
            Table("brands");
            Schema("");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            Map(p => p.Name).Column("name");

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
