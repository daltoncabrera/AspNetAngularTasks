using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetTestProject.Startup))]
namespace AspNetTestProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
