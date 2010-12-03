using System.Web.UI;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class SimpleWebView<ViewModel> : Page, WebView<ViewModel>
    {
        public ViewModel model { get; set; }
    }
}