using CQRS.Common;
using CQRS.Handlers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public UsersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery { UserId = id };
        var user = await _queryDispatcher.Dispatch<GetUserByIdQuery, User>(query, cancellationToken);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}