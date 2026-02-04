using LanguageExt;
using MediatR;
using Procat.SharedKernel.Paginations;

namespace Procat.UsersModule.Features.Users.ListUsers;

public sealed class ListUsersCommand(int pageNumber, int pageSize)
    : IRequest<Fin<PagedResponse<UserDto>>>
{
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
}
