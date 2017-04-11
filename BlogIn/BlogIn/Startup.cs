using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogIn.Startup))]
namespace BlogIn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
