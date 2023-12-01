using AutoMapper;
using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public interface IReadableModelStore<V> where V : SMARTBaseClass {
    Task<V> GetById(
        string id,
        bool forceRefresh = false
    );
    Task<IQueryable<V>> Get(
        bool forceRefresh = false, 
        Func<V, bool>? predicate = null
    );
}