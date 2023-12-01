namespace Daemon.DataAccess.DataStore;


public interface IDbModel
{
    public string ID { get; set; }
    public string LinkID { get; set; }
    public string Name { get; set; }
}