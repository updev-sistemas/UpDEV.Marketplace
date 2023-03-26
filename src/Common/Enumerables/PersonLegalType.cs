using System.ComponentModel;

namespace UpDEV.Marketplace.Domains.Common.Enumerables
{
    public enum PersonLegalType
    {
        [Description("Pessoa Física")]
        INDIVIDUAL_PERSON = 0,

        [Description("Pessoa Juridica")]
        LEGAL_PERSON = 1
    }
}
