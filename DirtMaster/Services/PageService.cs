using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TM.Services
{
    public class PageService
    {
        public async Task PushASync(Page page)
        {
            return await MainPage.Navigation.PushAsync(page);
        }

    }
}
