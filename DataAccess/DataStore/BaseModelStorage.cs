using AutoMapper;
using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public class BaseModelStorage<V> : IModelStorage<V> {
    public IList<V> Models { get; set; } = new List<V>();
    public IQueryable<V> Views { get; set; }

    public event EventHandler? OnStateChanged;
    public void StateChanged() {
        Views = Models.AsQueryable();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    public BaseModelStorage(
        IList<V> mockModels
    ) {
        Models = mockModels; 
        Views = Models.AsQueryable();  
    }

    public BaseModelStorage() {
        Views = Models.AsQueryable();
    }
}