using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(EventSystem.Areas.Identity.IdentityHostingStartup))]
namespace EventSystem.Areas.Identity
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