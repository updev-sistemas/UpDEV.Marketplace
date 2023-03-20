using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Common.Enumerables;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class SkuMap : ClassMap<SkuEntity>
    {
        public SkuMap()
        {
            Table("skus");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            References<TablePriceEntity>(p => p.TablePrice!).Column("table_price_id").Nullable();
            References<ProductEntity>(p => p.Product!).Column("product_id").Nullable();
            References<BrandEntity>(p => p.Brand!).Column("brand_id").Nullable();
            References<PackageEntity>(p => p.Package!).Column("package_id").Nullable();
            References<UnitEntity>(p => p.Unit!).Column("unit_id").Nullable();
            References<PersonEntity>(p => p.User!).Column("user_id").Nullable();

            Map(p => p.Origin).CustomType<OriginDefault>().Column("id_cost_origin").Nullable();

            Map(p => p.Factor).Column("factor").Nullable();
            Map(p => p.Cost).Column("cost_base").Nullable();
            Map(p => p.MinCost).Column("cost_min").Nullable();
            Map(p => p.MaxCost).Column("cost_max").Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();


        }
    }
}
