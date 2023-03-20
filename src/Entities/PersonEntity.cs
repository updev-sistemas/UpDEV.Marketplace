namespace UpDEV.Marketplace.Domains.Entities
{
    public class PersonEntity : EntityBase
    {
        public virtual string? Name { get; set; }
        public virtual string? Surname { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? Phone1 { get; set; }
        public virtual string? Phone2 { get; set; }
        public virtual DateOnly? Birthday { get; set; }
    }
}