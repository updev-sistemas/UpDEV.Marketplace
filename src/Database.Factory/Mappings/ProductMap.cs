
using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Common.Enumerables;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class ProductMap : ClassMap<ProductEntity>
    {
        public ProductMap()
        {
            Table("products");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            References<BrandEntity>(p => p.Brand!).Column("brand_id");
            References<CategoryEntity>(p => p.Category!).Column("category_id");
            References<UnitEntity>(p => p.BasicUnit!).Column("basic_unit_id");
            References<UnitEntity>(p => p.SalesUnit!).Column("sales_unit_id");

            Map(p => p.Name).Column("name").Nullable();
            Map(p => p.Description).Column("description").Nullable();
            Map(p => p.Thumbnail).Column("thumbnail").Nullable();
            Map(p => p.IsActive).Column("is_active").Nullable();
            Map(p => p.IsControlStock).Column("id_control_stock").Nullable();
            Map(p => p.PriceBaseBasicUnit).Column("price_base_basic_unit").Nullable();
            Map(p => p.PriceBaseSalesUnit).Column("price_base_sales_unit").Nullable();
            Map(p => p.Origin).CustomType<OriginDefault>().Column("id_origin").Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
