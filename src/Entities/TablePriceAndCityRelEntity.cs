namespace UpDEV.Marketplace.Domains.Entities
{
    public class TablePriceAndCityRelEntity : EntityBase
    {
        public virtual TablePriceEntity? TablePrice { get; set; }
        public virtual CityEntity? City { get; set; }
    }
}
