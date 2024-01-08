using AutoMapper;
using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public interface IReadableModelStore<V> {
    // Task<V> GetById(
    //     string id,
    //     bool forceRefresh = false
    // );
    Task<V?> GetOne(
        Func<V, bool>? predicate = null,
        bool forceRefresh = false
    );
    Task<IQueryable<V>> Get(
        bool forceRefresh = false, 
        Func<V, bool>? predicate = null
    );

    bool Any();
}