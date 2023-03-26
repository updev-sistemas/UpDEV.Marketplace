using System.ComponentModel;

namespace UpDEV.Marketplace.Domains.Common.Enumerables
{
    public enum ProductSectionType
    {
        [Description("Não se aplica")]
        NONE = 0,
        [Description("Refrigerado")]
        REFRIGERATED = 1,
        [Description("Congelado")]
        FROZEN = 2,
        [Description("Seco")]
        DRY = 3
    }
}
