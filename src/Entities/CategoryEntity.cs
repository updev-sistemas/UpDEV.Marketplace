namespace UpDEV.Marketplace.Domains.Entities
{
    public class CategoryEntity : EntityBase
    {
        public virtual SectionEntity? Section { get; set; }
        public virtual CategoryEntity? Parent { get; set; }
        public virtual string? Name { get; set; }
    }
}
