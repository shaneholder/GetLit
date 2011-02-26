using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GetLit.Netflix;
using GetLit.RIA.Server.Web;
using System.Data.Services.Client;

namespace GetLit
{
    public partial class MainPage : UserControl
    {
        private DataServiceCollection<Title> _titles;

        public MainPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LibraryContext context = new LibraryContext();
            context.Load(context.LibrariesQuery());

            NetflixCatalog catalog = new Netflix.NetflixCatalog(new Uri("http://odata.netflix.com/catalog", UriKind.Absolute));
            _titles = new DataServiceCollection<Title>(catalog);
            string searchTerm = "goon";
            _titles.LoadAsync(new Uri(String.Format("/Titles?$filter=Rating eq 'PG' and substringof('{0}',Name) eq true&$orderby=AverageRating desc&$top=20", searchTerm), UriKind.Relative));
            _titles.LoadCompleted += new EventHandler<LoadCompletedEventArgs>(titles_LoadCompleted);
        }

        void titles_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Netflix Error", MessageBoxButton.OK);
            }
        }

        private void libraryDomainDataSource_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
    }
}
