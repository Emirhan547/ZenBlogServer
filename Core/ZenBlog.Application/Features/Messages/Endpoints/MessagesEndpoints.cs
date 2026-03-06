using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Socials.Commands;

namespace ZenBlog.Application.Features.Messages.Endpoints
{
    public static class MessagesEndpoints
    {
        public static void RegisterMessagesEndpoints(this IEndpointRouteBuilder app)
        {
            var contactInfos = app.MapGroup("/messages").WithTags("Messages");
            contactInfos.MapGet("", async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetMessagesQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfos.MapPost("",
                async (CreateMessageCommand command, IMediator _mediator) =>
                {
                    var response = await _mediator.Send(command);
                    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
                });
            contactInfos.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetMessageByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfos.MapPut("", async (UpdateMessageCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfos.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveMessageCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
