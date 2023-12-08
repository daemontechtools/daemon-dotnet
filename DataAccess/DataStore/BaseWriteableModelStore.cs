using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public class BaseWriteableModelStore<D, V> : IWriteableModelStore<D, V>
    where D : SMARTBaseClass
    where V : SMARTBaseClass
{
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

    public virtual Task<V> Create(V view)
    {
        _storage.Models.Add(view);
        _storage.StateChanged();
        V? newView = _storage.Views.Where(
            v => v.LinkID == view.LinkID
        ).FirstOrDefault();
        if(newView is null) {
            throw new Exception("Could not find new view");
        }
        return Task.FromResult(newView);
    }

    public virtual Task Delete(V view)
    {
        _storage.Models.Remove(view);
        _storage.StateChanged();
        return Task.CompletedTask;
    }

    public virtual Task Update(V view)
    {
        return Task.CompletedTask;
        //D newModel = Mapper.Map<D>(viewModel);
        // int index = _storage.Models.FindIndex(m => m.ID == view.ID);
        // if (index >= 0) {
        //     _storage.Models[index] = newModel;
        //     _storage.StateChanged();
        // }
        // return Task.CompletedTask;
    }
}
