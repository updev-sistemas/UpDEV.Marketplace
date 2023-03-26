using UpDEV.Marketplace.Domains.Common.Database;

namespace UpDEV.Marketplace.Domains.Miscelaneas.Entities
{
    public class EnterpriseEntity : EntityBase
    {
        public virtual string? Name { get; set; }
        public virtual string? Document { get; set; }
        public virtual string? Phone { get; set; }
        public virtual string? Email { get; set; }
        public virtual bool? IsActive { get; set; }
    }
}
