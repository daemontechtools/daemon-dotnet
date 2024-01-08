using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;


public interface IModelApi<D> {
    public Task<D> Create(D model);
    public Task<IList<D>> Get();
    public Task Delete(D model);
    public Task<D> Update(D model);
}