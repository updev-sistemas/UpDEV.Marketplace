using UpDEV.Marketplace.Domains.Common.Settings;

namespace UpDEV.Marketplace.Domains.Common.Database
{
    public abstract class EntityBase : IIdentityEntityDatabase, IEntityTimestamp
    {
        public virtual long? Id { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual DateTime? DeletedAt { get; set; }
    }
}
