using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Miscelaneas.Entities
{
    public class SettingEntity : EntityBase
    {
        public virtual string? Key { get; set; }
        public virtual string? Value { get; set; }
    }
}
