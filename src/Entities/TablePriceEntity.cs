using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.Entities
{
    public class TablePriceEntity : EntityBase
    {
        public virtual string? Label { get; set; }
        public virtual TablePriceScope? Scope { get; set; }
        public virtual decimal? OtherTax { get; set; }
        public virtual decimal? DeliveryTax { get; set; }
        public virtual DateTime? EffectiveDateStart { get; set; }
        public virtual DateTime? EffectiveDateFinish { get; set; }
    }
}
