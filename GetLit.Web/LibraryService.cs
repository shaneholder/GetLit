
namespace GetLit.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using GetLit.Web.Data;


    // Implements application logic using the LibraryModelContainer context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class LibraryService : LinqToEntitiesDomainService<LibraryModelContainer>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Libraries' query.
        public IQueryable<Library> Libraries()
        {
            return this.ObjectContext.Libraries;
        }

        public IQueryable<Title> TilesByLibrary(int libraryId)
        {
            return this.ObjectContext.Titles.Where(title => title.LibraryId == libraryId);
        }
    }
}


