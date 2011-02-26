using System;
using System.Windows;
using System.ComponentModel.Composition;
using GetLit.RIA.Server.Web;

namespace GetLit.AppServices
{
    [Export(typeof(IApplicationService))]
    public class LibraryAppService : IApplicationService
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
        

        public void StartService(ApplicationServiceContext context)
        {
            
        }

        public void StopService()
        {
            
        }
    }
}
