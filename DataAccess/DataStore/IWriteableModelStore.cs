using AutoMapper;
using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public interface IWriteableModelStore<D, V> 
    where D : SMARTBaseClass
    where V : SMARTBaseClass 
{
    Task<V> Create(V view);
    Task Delete(string id);
    Task Update(V view);
}