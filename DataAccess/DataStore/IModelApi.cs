using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;


public interface IModelApi<D> where D : SMARTBaseClass
{
    public Task<D> Create(string name);
    public Task<ICollection<D>> Get();
    //public async Task Delete(D model);
    //public async Task<D> Update(D model);
}