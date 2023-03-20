using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class CategoryMap : ClassMap<CategoryEntity>
    {
        public CategoryMap()
        {
            Table("categories");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            References<SectionEntity>(p => p.Section!).Nullable().Column("section_id");
            References<CategoryEntity>(p => p.Parent).Nullable().Column("parent_id");

            Map(p => p.Name).Nullable().Column("name");

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
