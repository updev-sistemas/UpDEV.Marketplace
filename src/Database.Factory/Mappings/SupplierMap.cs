using FluentNHibernate.Mapping;

namespace UpDEV.Marketplace.Domains.Entities
{
    public class SupplierMap : ClassMap<SupplierEntity>
    {
        public SupplierMap()
        {
            Table("suppliers");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            HasOne(x => x.Person).Cascade.All();
            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
