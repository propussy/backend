using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Procat.SharedKernel.Paginations;
using Procat.UsersModule.Persistence;

namespace Procat.UsersModule.Features.Users.ListUsers;

public sealed class ListUsersCommandHandler(UsersDbContext context)
    : IRequestHandler<ListUsersCommand, Fin<PagedResponse<UserDto>>>
{
    public async Task<Fin<PagedResponse<UserDto>>> Handle(
        ListUsersCommand request,
        CancellationToken cancellationToken
    )
    {
        var pageRequest = new PageRequest
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
        };

        var users = await context
            .Users.AsNoTracking()
            .ToDto()
            .ToPagedResponseAsync(pageRequest, cancellationToken: cancellationToken);

        return users;
    }
}
