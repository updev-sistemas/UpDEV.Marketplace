using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class TablePriceAndCustomerRelMap : ClassMap<TablePriceAndCustomerRelEntity>
    {
        public TablePriceAndCustomerRelMap()
        {
            Table("rel_people_table_price");
            Where("deleted_at is null");

            References<TablePriceEntity>(p => p.TablePrice!).Column("table_price_id").Nullable();
            References<PersonEntity>(p => p.Person!).Column("person_id").Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}
