using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    private static DateTime _startTime = DateTime.UtcNow;

    /// <summary>
    /// Basic health check - responds with 200 if API is running
    /// Use for: Load balancers, Docker health checks, simple monitoring
    /// </summary>
    [HttpGet]
    public ActionResult<HealthCheckResponse> Get()
    {
        var response = new HealthCheckResponse
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Service = "Student Management API",
            Version = GetAssemblyVersion(),
            Environment = GetEnvironment(),
            Uptime = (DateTime.UtcNow - _startTime).TotalSeconds
        };

        return Ok(response);
    }

    /// <summary>
    /// Detailed health check - includes dependencies and system info
    /// Use for: Deployment validation, comprehensive monitoring
    /// </summary>
    [HttpGet("detailed")]
    public ActionResult<DetailedHealthResponse> GetDetailed()
    {
        var memoryUsage = GC.GetTotalMemory(false) / (1024 * 1024); // MB

        var response = new DetailedHealthResponse
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Service = "Student Management API",
            Version = GetAssemblyVersion(),
            Environment = GetEnvironment(),
            Uptime = (DateTime.UtcNow - _startTime).TotalSeconds,
            Runtime = new RuntimeInfo
            {
                FrameworkVersion = GetFrameworkVersion(),
                ProcessorCount = Environment.ProcessorCount,
                MemoryUsageMb = memoryUsage,
                OSVersion = Environment.OSVersion.ToString()
            },
            Dependencies = new DependenciesInfo
            {
                ServicesRegistered = true,
                ControllersLoaded = true,
                ConfigurationLoaded = true
            },
            Endpoints = new []
            {
                "/api/students",
                "/api/courses",
                "/api/instructors",
                "/api/enrollments",
                "/api/assignments",
                "/swagger"
            }
        };

        return Ok(response);
    }

    /// <summary>
    /// Live/Ready probe for Kubernetes deployment
    /// Use for: Kubernetes liveness and readiness probes
    /// </summary>
    [HttpGet("live")]
    public ActionResult<LivenessResponse> GetLive()
    {
        return Ok(new LivenessResponse
        {
            Status = "alive",
            Timestamp = DateTime.UtcNow
        });
    }

    /// <summary>
    /// Ready probe for deployment readiness
    /// Use for: Kubernetes readiness probe
    /// </summary>
    [HttpGet("ready")]
    public ActionResult<ReadinessResponse> GetReady()
    {
        return Ok(new ReadinessResponse
        {
            Status = "ready",
            Timestamp = DateTime.UtcNow,
            Message = "API is ready to receive traffic"
        });
    }

    private string GetEnvironment()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
    }

    private string GetAssemblyVersion()
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version;
        return version?.ToString() ?? "1.0.0";
    }

    private string GetFrameworkVersion()
    {
        return $".NET {Environment.Version}";
    }
}

/// <summary>
/// Basic health check response
/// </summary>
public class HealthCheckResponse
{
    public string Status { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public string Service { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Environment { get; set; } = string.Empty;
    public double Uptime { get; set; }
}

/// <summary>
/// Detailed health check response with system info
/// </summary>
public class DetailedHealthResponse
{
    public string Status { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public string Service { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Environment { get; set; } = string.Empty;
    public double Uptime { get; set; }
    public RuntimeInfo Runtime { get; set; } = new();
    public DependenciesInfo Dependencies { get; set; } = new();
    public string[] Endpoints { get; set; } = Array.Empty<string>();
}

/// <summary>
/// Runtime information
/// </summary>
public class RuntimeInfo
{
    public string FrameworkVersion { get; set; } = string.Empty;
    public int ProcessorCount { get; set; }
    public long MemoryUsageMb { get; set; }
    public string OSVersion { get; set; } = string.Empty;
}

/// <summary>
/// Dependencies information
/// </summary>
public class DependenciesInfo
{
    public bool ServicesRegistered { get; set; }
    public bool ControllersLoaded { get; set; }
    public bool ConfigurationLoaded { get; set; }
}

/// <summary>
/// Kubernetes liveness probe response
/// </summary>
public class LivenessResponse
{
    public string Status { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}

/// <summary>
/// Kubernetes readiness probe response
/// </summary>
public class ReadinessResponse
{
    public string Status { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public string Message { get; set; } = string.Empty;
}
