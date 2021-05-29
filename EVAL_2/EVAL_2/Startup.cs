using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EVAL_2.Startup))]
namespace EVAL_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
