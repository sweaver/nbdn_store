using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public delegate HttpContext CurrentContextResolver();
    public delegate object PageFactory(string path,Type page_base_type);
}