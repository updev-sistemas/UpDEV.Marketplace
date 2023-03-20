
using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class PackageMap : ClassMap<PackageEntity>
    {
        public PackageMap()
        {
            Table("packages");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            Map(p => p.Name).Column("name").Nullable();
            Map(p => p.Shortcut).Column("shortcut").Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
