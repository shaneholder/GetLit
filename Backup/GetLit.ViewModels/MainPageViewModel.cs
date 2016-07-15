using System;
using System.Windows.Data;
using GetLit.AppServices;
using System.Diagnostics;

namespace GetLit.ViewModels
{
    public class MainPageViewModel
    {
        private PagedCollectionView _Titles;
        public PagedCollectionView Titles
        {
            get {
                if (_Titles == null)
                {
                    Debug.WriteLine("PCV Titles");
                    _Titles = new PagedCollectionView(LibraryAppService.Current.Items);
                }
                return _Titles; 
            }
        }
    }
}
