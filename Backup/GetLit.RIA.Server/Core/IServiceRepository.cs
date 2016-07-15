using System;
using System.ServiceModel.DomainServices.Client;
using System.Collections.Generic;

namespace GetLit.RIA.Core
{
    public interface IServiceRepository<T> where T : Entity
    {
        EntityQuery<T> GetQuery();
        void Load(bool clearList);
        void Load(EntityQuery<T> query, bool clearList);
        void Save();
        void Delete(T entity);
        T Add();
        bool IsBusy { get; set; }
        IEnumerable<T> Items { get; set; }

        event EventHandler<OperationStartedEventArgs> OperationStarted;
        event EventHandler<OperationCompletedEventArgs> OperationCompleted;
    }

    public class OperationStartedEventArgs : EventArgs
    {

    }
    public class OperationCompletedEventArgs : EventArgs
    {
        public bool HasError { get; set; }
        public Exception Error { get; set; }
    }
}
