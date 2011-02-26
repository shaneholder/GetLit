using System;
using System.Windows;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace GetLit.RIA.Server.Web
{
    [Export(typeof(IApplicationService))]
    [Export(typeof(LibraryContext))]
    public partial class LibraryContext : IApplicationService
    {
        private static LibraryContext _Current;
        public static LibraryContext Current
        {
            get
            {
                return _Current;
            }
            set
            {
                _Current = value;
            }
        }

        public void StartService(ApplicationServiceContext context)
        {
            Debug.WriteLine("LibraryContext StartSErvice");
            _Current = this;            
        }

        public void StopService()
        {
            
        }
    }
}
