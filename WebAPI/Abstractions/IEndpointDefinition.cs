namespace WebAPI.Abstractions;

public interface IEndpointDefinition
{
    void RegisterEndpoints(WebApplication app);
}
