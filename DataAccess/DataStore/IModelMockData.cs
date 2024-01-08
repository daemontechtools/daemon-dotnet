using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public interface IModelMockData<D> {
    public IList<D> MockModels { get; set; }
}