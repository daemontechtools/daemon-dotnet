using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;


public interface IModelApi<D> {
    public Task<D> Create(D model);
//    public Task<D> Create(D model, P parent);
    public Task<IList<D>> Get();
//    public Task<IList<D>> Get(P parent);
    public Task Delete(D model);
 //   public Task Delete(D model, P parent);
    public Task<D> Update(D model);
//    public Task<D> Update(D model, P parent);
}