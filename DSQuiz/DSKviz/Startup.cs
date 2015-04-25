using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSKviz.Startup))]
namespace DSKviz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
