using UpDEV.Marketplace.Domains.Common.Database;
using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.Domains.Catalog.Entities
{
    public class ItemEntity : EntityBase
    {
        public virtual ItemType? Type { get; set; }
        public virtual string? Code { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual string? HtmlDescription { get; set; }
        public virtual string? Images { get; set; }
        public virtual UnitEntity? BasicUnit { get; set; }
        public virtual UnitEntity? SalesUnit { get; set; }
        public virtual GroupEntity? Group { get; set; }
        public virtual SubcategoryEntity? Subcategory { get; set; }
        public virtual bool? IsVirtual { get; set; }
        public virtual string? Thumbnail { get; set; } = "img-default.png";
        public virtual bool? ToOrder { get; set; } = false; // Feito sobre encomenda
        public virtual bool? AccceptedToOrder { get; set; } = false; // Está aceitando encomenda
        public virtual bool? ControlledProduction { get; set; } = false; // Já fabricado, mas é escasso
        public virtual IEnumerable<ItemPropertyEntity>? Properties { get; set; }
    }
}