using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class TablePriceAndProductRelMap : ClassMap<TablePriceAndProductRelEntity>
    {
        public TablePriceAndProductRelMap()
        {
            Table("rel_product_table_price");
            Where("deleted_at is null");

            References<TablePriceEntity>(p => p.TablePrice!).Column("table_price_id").Nullable();
            References<ProductEntity>(p => p.Product!).Column("product_id").Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
