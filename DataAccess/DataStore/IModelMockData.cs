using SMART.Common.Base;

namespace Daemon.DataAccess.DataStore;

public interface IModelMockData<D> where D : SMARTBaseClass {
    public IList<D> MockModels { get; set; }
}