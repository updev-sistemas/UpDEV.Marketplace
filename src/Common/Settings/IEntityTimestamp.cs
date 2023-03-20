namespace UpDEV.Marketplace.Domains.Common.Settings
{
    public interface IEntityTimestamp
    {
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
