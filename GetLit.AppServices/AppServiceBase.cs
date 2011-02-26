using System;
using System.Windows;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using GetLit.RIA.Core;
using GetLit.RIA;
using GetLit.RIA.Server.Web;


namespace GetLit.AppServices
{
    [Export(typeof(IApplicationService))]
    public abstract class ServiceBase<T> : IServiceRepository<T>, IApplicationService where T : Entity
    {
        private static ServiceBase<T> _Current = null;
        public static ServiceBase<T> Current
        {
            get { return _Current; }
        }

        public virtual void StartService(ApplicationServiceContext context)
        {
            _Current = this;
            Load(true);
        }

        public virtual void StopService()
        {

        }

        public abstract void Load(bool clearList);
        public abstract void Save();
        public abstract void Delete(T entity);
        public abstract T Add();
        public abstract System.Collections.Generic.IEnumerable<T> Items { get; set; }
        public abstract EntityQuery<T> GetQuery();

        public bool IsBusy { get; set; }

        public void Load(EntityQuery<T> query, bool clearList)
        {
            OnOperationStarted(new OperationStartedEventArgs());
            if (clearList)
                LibraryContext.Current.EntityContainer.GetEntitySet<T>().Clear();

            LibraryContext.Current.Load<T>(query, LoadBehavior.MergeIntoCurrent, (l) => { OnOperationCompleted(new OperationCompletedEventArgs()); }, null);
        }

        public event EventHandler<OperationStartedEventArgs> OperationStarted = (o, e) => { };
        public event EventHandler<OperationCompletedEventArgs> OperationCompleted = (o, e) => { };

        #region OnOperationStarted
        /// <summary>
        /// Triggers the OperationStarted event.
        /// </summary>
        public virtual void OnOperationStarted(OperationStartedEventArgs ea)
        {
            IsBusy = true;
            OperationStarted(this, ea);
        }
        #endregion
        #region OnOperationCompleted
        /// <summary>
        /// Triggers the OperationCompleted event.
        /// </summary>
        public virtual void OnOperationCompleted(OperationCompletedEventArgs ea)
        {
            IsBusy = false;
            OperationCompleted(this, ea);
        }
        #endregion

    }
}
