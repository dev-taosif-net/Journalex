namespace Submission.API.Endpoints;

public static class XEndpointRegistration
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/api");
        api.MapArticle();
        
        return endpoints;
    }
}