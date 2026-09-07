# CronScheduler.AspNetCore

![master workflow](https://github.com/github/docs/actions/workflows/master.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/CronScheduler.AspNetCore.svg)](https://www.nuget.org/packages?q=CronScheduler.AspNetCore)
![Nuget](https://img.shields.io/nuget/dt/CronScheduler.AspNetCore)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/cronscheduler-aspnetcore/shield/CronScheduler.AspNetCore/latest)](https://f.feedz.io/kdcllc/cronscheduler-aspnetcore/packages/CronScheduler.AspNetCore/latest/download)

*Note: Pre-release packages are distributed via [feedz.io](https://f.feedz.io/kdcllc/cronscheduler-aspnetcore/nuget/index.json).*

![I Stand With Israel](./img/IStandWithIsrael.png)

## Summary

**Unlock the Power of Simplified Cron Scheduling in Your .NET Core Apps**

Introducing **CronScheduler**, a lightweight and easy-to-use library designed for modern .NET `IHost` applications.

Built with the KISS principle in mind, CronScheduler is a simplified alternative to Quartz Scheduler and its alternatives. With CronScheduler, you can easily schedule tasks using cron syntax and operate within any .NET Core GenericHost `IHost`, making setup and configuration a breeze.

But that's not all! We've also introduced **IStartupJob**, allowing for async initialization of critical processes before the host is ready to start. This means you can ensure your application is properly initialized and running smoothly, even in complex Kubernetes environments.

**Benefits:**

* Lightweight and easy-to-use library
* Simplified scheduling with cron syntax
* Operates within the .NET Generic Host (`IHost`)
* Async initialization support for critical processes with `IStartupJob`
* Deterministic schedule jitter to distribute load across jobs and instances
* Previous-occurrence lookup for schedule inspection and diagnostics

**Join the CronScheduler community today and start simplifying your application's scheduling needs!**

>
> **Please refer to [Migration Guide](./Migration.md) for the upgrade.**
>
[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Installation

- Install package for `AspNetCore` hosting .NET CLI

```bash
dotnet add package CronScheduler.AspNetCore --version 3.3.0
```

- For Worker Services and other Generic Host applications:

```bash
dotnet add package CronScheduler.Extensions --version 3.3.0
```

## Cron schedules

CronScheduler uses [Cronos 0.13.0](https://github.com/HangfireIO/Cronos) to parse schedules and calculate occurrences. It supports standard five-field expressions, six-field expressions with seconds, macros, time zones, reversed ranges, `L`, `W`, `#`, and deterministic jitter with `H`.

Existing five-field and six-field schedules remain compatible. Use [crontab-generator.org](https://crontab-generator.org/) to generate basic expressions, and consult the [Cronos format reference](https://github.com/HangfireIO/Cronos#cron-format) for extended syntax.

### Cron format

Cron expression is a mask to define fixed times, dates and intervals. The mask consists of second (optional), minute, hour, day-of-month, month and day-of-week fields. All of the fields allow you to specify multiple values, and any given date/time will satisfy the specified Cron expression, if all the fields contain a matching value.

                                           Allowed values    Allowed special characters   Comment

    ┌───────────── second (optional)       0-59              * , - / H
    │ ┌───────────── minute                0-59              * , - / H
    │ │ ┌───────────── hour                0-23              * , - / H
    │ │ │ ┌───────────── day of month      1-31              * , - / H L W ?
    │ │ │ │ ┌───────────── month           1-12 or JAN-DEC   * , - / H
    │ │ │ │ │ ┌───────────── day of week   0-6 or SUN-SAT    * , - / H # L ?              Both 0 and 7 mean SUN
    │ │ │ │ │ │
    * * * * * *

Cronos also supports macros: `@every_second`, `@every_minute`, `@hourly`, `@daily`, `@midnight`, `@weekly`, `@monthly`, `@yearly`, and `@annually`.

### Deterministic schedule jitter

Cronos 0.13.0 supports the `H` character to deterministically distribute execution times. Configure `CronJitterSeed` whenever an expression contains `H`. The same expression and seed always produce the same schedule, making it suitable for spreading load without random behavior on restart.

```json
{
  "SchedulerJobs": {
    "TelemetryJob": {
      "CronSchedule": "H H * * * *",
      "CronJitterSeed": 1207,
      "CronTimeZone": "UTC",
      "RunImmediately": false
    }
  }
}
```

The seed also adds jitter to supported macros. For example, `@hourly` with a seed runs once per hour at deterministic minute and second offsets. Using `H` without `CronJitterSeed` is invalid and Cronos throws `CronFormatException` during registration.

### Previous occurrences

Cronos 0.13.0 can calculate occurrences in reverse. Registered jobs expose this through `SchedulerTaskWrapper.GetPreviousOccurrence`:

```csharp
var registration = services.GetRequiredService<ISchedulerRegistration>();
var job = registration.Jobs[nameof(TelemetryJob)];
var previousRun = job.GetPreviousOccurrence(DateTimeOffset.UtcNow);
```

The calculation uses the job's configured time zone and does not change scheduler state.

## Demo Applications

- [CronSchedulerWorker](./src/CronSchedulerWorker/) demonstrates `CronScheduler` in a .NET Worker Service.
- [CronSchedulerApp](./src/CronSchedulerApp/) demonstrates `CronScheduler` in an ASP.NET Core Razor Pages application.

Jobs can be registered by type or with a factory.

1. Register a job by type. By convention, the job name and its configuration section name are the type name.

```csharp
builder.Services.AddScheduler(scheduler =>
{
    scheduler.AddJob<TestJob>();
});
```

2. Use factories and explicit names to register the same job type with different options.

```csharp
builder.Services.AddScheduler(scheduler =>
{
    const string jobName1 = "TestJob1";

    scheduler.AddJob(
        sp =>
        {
            var options = sp.GetRequiredService<IOptionsMonitor<SchedulerOptions>>().Get(jobName1);
            var logger = sp.GetRequiredService<ILogger<TestJobDup>>();
            return new TestJobDup(options, logger);
        },
        options =>
        {
            options.CronSchedule = "*/5 * * * * *";
            options.RunImmediately = true;
        },
        jobName: jobName1);
});
```

## Sample code for Singleton Schedule Job and its dependencies

```csharp
    public class TorahQuoteJob : IScheduledJob
    {
        private readonly TorahQuoteJobOptions _options;
        private readonly TorahVerses _torahVerses;
        private readonly TorahService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TorahQuoteJob"/> class.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="service"></param>
        /// <param name="torahVerses"></param>
        public TorahQuoteJob(
            IOptionsMonitor<TorahQuoteJobOptions> options,
            TorahService service,
            TorahVerses torahVerses)
        {
            _options = options.Get(Name);
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _torahVerses = torahVerses ?? throw new ArgumentNullException(nameof(torahVerses));
        }

        // job name and options name must match.
        public string Name { get; } = nameof(TorahQuoteJob);

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var index = new Random().Next(_options.Verses.Length);
            var exp = _options.Verses[index];

            _torahVerses.Current = await _service.GetVersesAsync(exp, cancellationToken);
        }
    }
```

Then register this service within the `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScheduler(builder =>
{
    builder.Services.AddSingleton<TorahVerses>();
    builder.Services
        .AddHttpClient<TorahService>()
        .AddTransientHttpErrorPolicy(p => p.RetryAsync());

    builder.AddJob<TorahQuoteJob, TorahQuoteJobOptions>();
    builder.Services.AddScoped<UserService>();
    builder.AddJob<UserJob, UserJobOptions>();

    builder.AddUnobservedTaskExceptionHandler(sp =>
    {
        var logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger("CronJobs");
        return (sender, args) =>
        {
            logger?.LogError(args.Exception?.Message);
            args.SetObserved();
        };
    });
});

builder.Services.AddBackgroundQueuedService(applicationOnStopWaitForTasksToComplete: true);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddStartupJob<SeedDatabaseStartupJob>();
builder.Services.AddStartupJob<TestStartupJob>();

builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseRouting();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.RunStartupJobsAsync();
await app.RunAsync();
```


## `IStartupJob` for asynchronous initialization

Startup jobs run against the modern `IHost` abstraction. A common use case is ensuring a database is created and migrated before the application begins serving requests.
This library makes it possible by simply doing the following:

- In the `Program.cs` file add the following:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddStartupJob<SeedDatabaseStartupJob>();
builder.Services.AddStartupJob<TestStartupJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.
await app.RunStartupJobsAsync();
await app.RunAsync();
```

## Background Queues

Use the background task queue when work must be queued for asynchronous execution. Register it in `Program.cs`:

```csharp
builder.Services.AddBackgroundQueuedService();
```

Inject `IBackgroundTaskQueue` and enqueue asynchronous work for the hosted service:

```csharp
public sealed class MyService
{
    private readonly IBackgroundTaskQueue _taskQueue;

    public MyService(IBackgroundTaskQueue taskQueue)
    {
        _taskQueue = taskQueue;
    }

    public void RunTask()
    {
        _taskQueue.QueueBackgroundWorkItem(async cancellationToken =>
        {
            // Run queued work.
            await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
        });
    }
}
```

## License

[MIT License](./LICENSE)
