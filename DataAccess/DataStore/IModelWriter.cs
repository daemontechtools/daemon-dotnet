using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;


public interface IWritableModelStore<D, V> : IModelStorage<V> 
    where D : SMARTBaseClass 
    where V : SMARTBaseClass 
{
    public Task<V> Create(V model);
    public Task<V> Update(V model);
    public Task<V> Delete(V model);
}