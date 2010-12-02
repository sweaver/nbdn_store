using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface WebView<ViewModel> : IHttpHandler
    {
        ViewModel model { get; set; }
    }
}