using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Procat.SharedKernel;

namespace Procat.UsersModule.Features.Users.ListUsers;

public sealed class ListUsersEndpoint(IMediator mediator) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("api/users");

        // TODO: This should not be public
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var page = Query<int>("page");
        var pageSize = Query<int>("pageSize");

        var res = await mediator.Send(new ListUsersCommand(page, pageSize), ct);

        await res.Match(
            users => Send.OkAsync(users, ct),
            err => Send.ResultAsync(TypedResults.Problem(err.ToProblemDetails(HttpContext)))
        );
    }
}
