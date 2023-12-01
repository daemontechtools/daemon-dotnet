using AutoMapper;
using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public class BaseReadableModelStore<D, V> : IReadableModelStore<V>    
    where D : SMARTBaseClass 
    where V : SMARTBaseClass 
{
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
        if(forceRefresh || _storage.Models.Count == 0) {
            views = await FetchModels();
        } else {
            views = _storage.Views;
        }

        if (predicate != null) {
            views = views.Where(m => predicate(m));
        }
        return views;
    }

    private async Task<IQueryable<V>> FetchModels() {
        ICollection<D> models = await _api.Get();
        ICollection<V> views = _mapper.Map<ICollection<V>>(models);
        _storage.Models = views;
        _storage.StateChanged();
        return _storage.Views;
    }

    public async Task<V> GetById(
        string id,
        bool forceRefresh = false
    ) {
        IQueryable<V> views;
        if(forceRefresh || _storage.Models.Count == 0) {
            views = await FetchModels();
        } else {
            views = _storage.Views;
        }
        V? view = views.FirstOrDefault(m => m.LinkID == id);
        if(view is null) {
            throw new Exception("Could not find view");
        }
        return view;
    }
}
