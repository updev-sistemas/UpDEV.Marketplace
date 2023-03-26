using NHibernate.Type;
using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.Common.Database
{
    public class AnsiEnumStringType : EnumStringType
    {
        public AnsiEnumStringType(Type type)
            : base(type)
        {
        }

        public AnsiEnumStringType(Type type, int length)
            : base(type, length)
        {
        }
    }

    public class PersonLegalTypeEnumWrapper : AnsiEnumStringType
    {
        public PersonLegalTypeEnumWrapper()
            : base(typeof(PersonLegalType), 30)
        {
        }
    }

    public class CityZoneEnumWrapper : AnsiEnumStringType
    {
        public CityZoneEnumWrapper()
            : base(typeof(CityZone), 30)
        {
        }
    }
}
