using UpDEV.Marketplace.Domains.Common.Settings;

namespace UpDEV.Marketplace.Domains.Entities
{
    public abstract class EntityBase : IIdentityEntityDatabase, IEntityTimestamp
    {
        public virtual Guid? Id { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual DateTime? DeletedAt { get; set; }
    }
}
