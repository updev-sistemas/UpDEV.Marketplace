namespace UpDEV.Marketplace.Domains.Catalog
{
    public class SubcategoryEntity : CategoryBaseEntity
    {
        public virtual CategoryEntity? Category { get; set; }
    }
}