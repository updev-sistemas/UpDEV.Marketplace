using UpDEV.Marketplace.Domains.Common.Database;
using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.CRM.Entities
{
    public class PersonDocumentEntity : EntityBase
    {
        public virtual PersonEntity? Person { get; set; }
        public virtual PersonLegalType? LegalType { get; set; }
        public virtual string? DocHash { get; set; }
        public virtual string? DocPayload { get; set; }
    }
}
