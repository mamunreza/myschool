using System.Net;
using Api.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Api.Features.Employees.CreateEmployee;
using static Api.Features.Employees.GetEmployee;

namespace Api.Features.Employees;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
  private readonly ISender _sender;

  public EmployeesController(ISender sender)
  {
    _sender = sender;
  }

  /// <remarks>
  ///   Get product classes returns product classes for case owners country.
  /// </remarks>
  [HttpGet("{id}")]
  [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GetEmployee.Result))]
  [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiError))]
  [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiError))]
  [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ApiError))]
  [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ApiError))]
  [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable, Type = typeof(ApiError))]
  public async Task<ActionResult<GetEmployee.Result>> GetSingleEmployeeAsync(
    [FromQuery] Query query,
    CancellationToken cancellationToken)
  {
    return Ok(await _sender.Send(query, cancellationToken));
  }

  /// <remarks>
  ///   Get product classes returns product classes for case owners country.
  /// </remarks>
  [HttpPost]
  [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CreateEmployee.Result))]
  [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiError))]
  [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiError))]
  [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ApiError))]
  [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ApiError))]
  [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable, Type = typeof(ApiError))]
  public async Task<ActionResult<CreateEmployee.Result>>CreateEmployeeAsync(
    Command command,
    CancellationToken cancellationToken)
  {
    return Ok(await _sender.Send(command, cancellationToken));
  }
}
