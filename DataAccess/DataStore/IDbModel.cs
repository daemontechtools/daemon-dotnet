namespace Daemon.DataAccess.DataStore;


public interface IDbModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}