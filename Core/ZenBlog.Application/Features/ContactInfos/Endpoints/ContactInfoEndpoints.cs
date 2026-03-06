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
using ZenBlog.Application.Features.ContactInfos.Queries;

namespace ZenBlog.Application.Features.ContactInfos.Endpoints
{
    public static class ContactInfoEndpoints
    {
        public static void RegisterContactInfoEndpoints(this IEndpointRouteBuilder app)
        {
            var contactInfos = app.MapGroup("/contactInfos").WithTags("ContactInfos");
            contactInfos.MapGet("", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetContactInfosQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfos.MapPost("",
                async (CreateContactInfoCommand command, IMediator _mediator) =>
                {
                    var response = await _mediator.Send(command);
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });
            contactInfos.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetContactInfoByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfos.MapPut("", async (UpdateContactInfoCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfos.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveContactInfoCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
