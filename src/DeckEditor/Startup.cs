using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeckEditor.Startup))]
namespace DeckEditor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
