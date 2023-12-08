namespace Daemon.DataAccess.DataStore;

public interface IModelStorage<V> {
    IList<V> Models { get; set;}
    IQueryable<V> Views { get; set;}
    event EventHandler? OnStateChanged;
    void StateChanged();
}