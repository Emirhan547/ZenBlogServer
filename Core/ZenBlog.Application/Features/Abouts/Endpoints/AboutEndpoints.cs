using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Abouts.Commands;
using ZenBlog.Application.Features.Abouts.Queries;
using ZenBlog.Application.Features.Socials.Commands;

namespace ZenBlog.Application.Features.Abouts.Endpoints
{
    public static class AboutEndpoints
    {
        public static void RegisterAboutEndpoints(this IEndpointRouteBuilder app)
        {
            var socials = app.MapGroup("/abouts").WithTags("Abouts");

            socials.MapPost("/", async (CreateAboutCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();

            socials.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAboutsQuery());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            }).AllowAnonymous();

            socials.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAboutByIdQuery(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            socials.MapPut("/", async (UpdateAboutCommand command, IMediator mediator) =>
            {

                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            socials.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new RemoveAboutCommand(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

        }
    }
}
