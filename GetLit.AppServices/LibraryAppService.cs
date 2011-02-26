using System;
using System.Windows;
using System.ComponentModel.Composition;
using GetLit.RIA.Server.Web;
using GetLit.RIA.Server.Data;
using System.ServiceModel.DomainServices.Client;
using System.Diagnostics;

namespace GetLit.AppServices
{
    [Export(typeof(IApplicationService))]
    public class LibraryAppService : AppServiceBase<Library>
    {
        private LibraryContext _LibraryContext;
        [Import(typeof(LibraryContext))]
        public LibraryContext LibraryContext
        {
            get { return _LibraryContext; }
            set
            {
                _LibraryContext = value;
            }
        }

        public override void StartService(ApplicationServiceContext context)
        {
            base.StartService(context);
        }
        public override void Load(bool clearList)
        {
            LibraryContext.Current.Load<Library>(this.GetQuery(), LoadBehavior.MergeIntoCurrent, true);
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Delete(Library entity)
        {
            throw new NotImplementedException();
        }

        public override Library Add()
        {
            throw new NotImplementedException();
        }

        public override System.Collections.Generic.IEnumerable<Library> Items
        {
            get
            {
                return LibraryContext.Current.Libraries;
            }
            set
            {
                
            }
        }

        public override System.ServiceModel.DomainServices.Client.EntityQuery<Library> GetQuery()
        {
            return LibraryContext.Current.LibrariesQuery();            
        }
    }
}
