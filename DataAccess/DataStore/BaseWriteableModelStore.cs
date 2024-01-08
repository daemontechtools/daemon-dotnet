using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public class BaseWriteableModelStore<D, V> : IWriteableModelStore<D, V> {
    protected IMapper _mapper { get; }
    protected IModelStorage<V> _storage { get; }
    protected IModelApi<D> _api { get; }

    public BaseWriteableModelStore(
        IMapper mapper,
        IModelStorage<V> storage,
        IModelApi<D> api
    ) {
        _storage = storage;
        _mapper = mapper;
        _api = api;
    }

    public virtual async Task<V> Create(V view) {  
        D newModel = await _api.Create(_mapper.Map<D>(view));
        V newView = _mapper.Map<V>(newModel);
        _storage.Models.Add(newView);
        _storage.StateChanged();
        return newView;
    }

    public virtual async Task Delete(V view) {
        D removedModel = _mapper.Map<D>(view);
        await _api.Delete(removedModel);
        _storage.Models.Remove(view);
        _storage.StateChanged();
    }

    public virtual async Task<V> Update(V view) {
        D model = _mapper.Map<D>(view);
        D newModel = await _api.Update(model);
        V newView = _mapper.Map<V>(newModel);
        int index = _storage.Models.IndexOf(view);
        _storage.Models[index] = newView;
        _storage.StateChanged();
        return newView;
    }
}
