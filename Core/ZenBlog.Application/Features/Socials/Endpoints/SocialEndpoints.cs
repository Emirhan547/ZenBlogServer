using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Queries;

namespace ZenBlog.Application.Features.Socials.Endpoints
{
    public static class SocialEndpoints
    {
        public static void RegisterSocialEndpoints(this IEndpointRouteBuilder app)
        {
            var contactInfos = app.MapGroup("/socials").WithTags("Socials");
            contactInfos.MapGet("", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSocialsQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfos.MapPost("",
                async (CreateSocialCommand command, IMediator _mediator) =>
                {
                    var response = await _mediator.Send(command);
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });
            contactInfos.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetSocialByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfos.MapPut("", async (UpdateSocialCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfos.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveSocialCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
