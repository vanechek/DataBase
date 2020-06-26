using System;
using System.Windows.Controls;

namespace DataBase.Service
{
    public class PageService
    {
        public event Action<Page> PageChanged;

        public void OnPageChanged(Page page)
        {
            PageChanged?.Invoke(page);
        }
    }
}
