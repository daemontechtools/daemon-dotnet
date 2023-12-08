using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;


public interface IModelApi<D> where D : SMARTBaseClass
{
    public Task<D> Create(string name);
    public Task<IList<D>> Get();
    public Task Delete(D model);
    public Task<D> Update(D model);
}