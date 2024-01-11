using AutoMapper;
using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public class BaseReadableModelStore<D, V> : IReadableModelStore<V> {
    private IMapper _mapper { get; }
    private IModelStorage<V> _storage { get; }
    private IModelApi<D> _api { get; }

    public BaseReadableModelStore(
        IMapper mapper,
        IModelStorage<V> storage,
        IModelApi<D> api
    ) {
        _mapper = mapper;
        _storage = storage;
        _api = api;
    }

    public async Task<IQueryable<V>> Get(
        bool forceRefresh = false,
        Func<V, bool>? predicate = null
    ) {
        IQueryable<V> views;
        if(forceRefresh) {
            views = await FetchModels();
        } else {
            views = _storage.Views;
        }

        if (predicate != null) {
            views = views.Where(m => predicate(m));
        }
        return views;
    }

    public async Task<V?> GetOne(
        Func<V, bool>? predicate = null,
        bool forceRefresh = false
    ) {
        IQueryable<V> views;
        if(forceRefresh) {
            views = await FetchModels();
        } else {
            views = _storage.Views;
        }

        if (predicate != null) {
            views = views.Where(m => predicate(m));
        }
        return views.FirstOrDefault();
    }

    public async Task<IQueryable<V>> FetchModels() {
        IList<D> models = await _api.Get();
        IList<V> views = _mapper.Map<IList<V>>(models);
        _storage.Models = views;
        _storage.StateChanged();
        return _storage.Views;
    }

    // public async Task<V> GetById(
    //     string id,
    //     bool forceRefresh = false
    // ) {
    //     IQueryable<V> views;
    //     if(forceRefresh || _storage.Models.Count == 0) {
    //         views = await FetchModels();
    //     } else {
    //         views = _storage.Views;
    //     }
    //     V? view = views.FirstOrDefault(m => m.LinkID == id);
    //     if(view is null) {
    //         throw new Exception("Could not find view");
    //     }
    //     return view;
    // }

    public bool Any() {
        return _storage.Models.Any();
    }
}
