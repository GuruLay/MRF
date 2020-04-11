using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MRF.Web.Areas.Identity.IdentityHostingStartup))]
namespace MRF.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}