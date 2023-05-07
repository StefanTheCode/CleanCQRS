using CQRS.Common;

namespace CQRS.Handlers.Queries;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
{
    public GetUserByIdQueryHandler() { }

    public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        //Call Repository
        return new User();
    }
}

public class User
{
}