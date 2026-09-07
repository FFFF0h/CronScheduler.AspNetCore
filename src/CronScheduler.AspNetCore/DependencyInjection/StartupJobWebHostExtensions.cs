using System.Threading;
using System.Threading.Tasks;

using CronScheduler.Extensions.StartupInitializer;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.AspNetCore.Hosting;

public static class StartupJobWebHostExtensions
{
    /// <summary>
    /// Runs async all of the registered <see cref="IStartupJob"/> jobs.
    /// </summary>
    /// <param name="host"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
#if NET10_0_OR_GREATER
    public static async Task RunStartupJobsAsync(this IHost host, CancellationToken cancellationToken = default)
#else
    public static async Task RunStartupJobsAsync(this IWebHost host, CancellationToken cancellationToken = default)
#endif
    {
        using var scope = host.Services.CreateScope();
        var jobInitializer = scope.ServiceProvider.GetRequiredService<StartupJobInitializer>();
        await jobInitializer.StartJobsAsync(cancellationToken);
    }
}
