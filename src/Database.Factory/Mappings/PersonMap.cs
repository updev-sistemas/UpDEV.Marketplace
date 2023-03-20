using FluentNHibernate.Mapping;
using UpDEV.Marketplace.Domains.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Mappings
{
    public class PersonMap : ClassMap<PersonEntity>
    {
        public PersonMap()
        {
            Table("people");
            Where("deleted_at is null");

            Id(pk => pk.Id).Column("id").GeneratedBy.Guid();

            Map(p => p.Name).Column("name").Nullable();
            Map(p => p.Surname).Column("surname").Nullable();
            Map(p => p.Email).Column("email").Nullable();
            Map(p => p.Phone1).Column("phone1").Nullable();
            Map(p => p.Phone2).Column("phone2").Nullable();
            Map(p => p.Birthday).Column("birthday").Nullable();

            Map(p => p.CreatedAt).Column("created_at").Nullable();
            Map(p => p.UpdatedAt).Column("updated_at").Nullable();
            Map(p => p.DeletedAt).Column("deleted_at").Nullable();
        }
    }
}