using AutoMapper;
using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public interface IWriteableModelStore<D, V> {
    Task<V> Create(V view);
    Task Delete(V view);
    Task<V> Update(V view);
}