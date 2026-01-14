using MediatR;
using Submission.Application.Features.CreateArticle;

namespace Submission.API.Endpoints;

public static class ArticleEndpoints
{
    public static IEndpointRouteBuilder MapArticle(this IEndpointRouteBuilder endpoints)
    {
        var app = endpoints.MapGroup("/articles");
        
        app.MapPost("", async (CreateArticleCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);
                return Results.Created($"/api/articles/{response.Id}", response);
            })
            .RequireAuthorization(policy => policy.RequireRole("AUT"))
            .WithName("CreateArticle")
            .WithTags("Articles")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest);

        return endpoints;
    }
    
}