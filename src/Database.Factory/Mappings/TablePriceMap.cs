using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Common.Enumerables;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class TablePriceMap : ClassMap<TablePriceEntity>
    {
        public TablePriceMap()
        {
            Table("table_prices_products");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            Map(p => p.Label).Column("label").Nullable();
            Map(p => p.Scope).CustomType<TablePriceScope>().Column("id_scope").Nullable();
            Map(p => p.OtherTax).Column("other_tax").Nullable();
            Map(p => p.DeliveryTax).Column("delivery_tax").Nullable();
            Map(p => p.EffectiveDateStart).Column("effective_date_start").Nullable();
            Map(p => p.EffectiveDateFinish).Column("effective_date_finish").Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
