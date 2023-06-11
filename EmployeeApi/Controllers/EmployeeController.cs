using System.Globalization;
using Application.Commands.CreateEmployee;
using Application.Commands.DeleteEmployee;
using Application.Commands.UpdateEmployee;
using Application.Queries.GetByIdQuery;
using Application.Queries.ListQuery;
using EmployeeApi.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("/api/v1/[controller]/{action}")]
public class EmployeeController : ControllerBase
{
    // TODO: Mapper
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Создать запись.
    /// </summary>
    /// <param name="dto">DTO</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Create(CreateEmployeeDto dto)
    {
        var result = await _mediator.Send(new CreateEmployeeCommand
        {
            DepartmentFullName = dto.DepartmentName,
            DepartmentCode = dto.DepartmentCode,
            Surname = dto.Surname,
            FirstName = dto.FirstName,
            PatronymicName = dto.PatronymicName ?? string.Empty,
            BirthDate = dto.BirthDate,
            DateOfEmployment = dto.DateOfEmployee,
            Salary = dto.Salary
        });
    
        return CreatedAtAction("Get", new GetDto { Id = result });
    }

    /// <summary>
    /// Редактировать запись.
    /// </summary>
    /// <param name="dto">DTO</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateEmployeeDto dto)
    {
        if (dto.Id == default)
        {
            return BadRequest("Не удалось получить идентификатор");
        }

        await _mediator.Send(new UpdateEmployeeCommand
        {
            Id = dto.Id,
            DepartmentFullName = dto.DepartmentName,
            DepartmentCode = dto.DepartmentCode,
            Surname = dto.Surname,
            FirstName = dto.FirstName,
            PatronymicName = dto.PatronymicName ?? string.Empty,
            BirthDate = dto.BirthDate,
            DateOfEmployment = dto.DateOfEmployee,
            Salary = dto.Salary
        });

        return Ok();
    }
    
    /// <summary>
    /// Удалить запись.
    /// </summary>
    /// <param name="dto">DTO</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteEmployeeDto dto)
    {
        if (dto.Id == default)
        {
            return BadRequest("Не удалось получить идентификатор");
        }

        await _mediator.Send(new DeleteEmployeeCommand { Id = dto.Id });
        return Ok();
    }
    
    /// <summary>
    /// Получить список всех записей.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/list")]
    public async Task<ActionResult<IEnumerable<ListDto>>> List ()
    {
        var baseQuery = await _mediator.Send(new GetAllQuery());

        var query = baseQuery.Select(x => new ListDto
        {
            Id = x.Id,
            DepartmentName = x.Department.FullName,
            Surname = x.FullName.Surname,
            FirstName = x.FullName.FirstName,
            PatronymicName = x.FullName.PatronymicName ?? string.Empty,
            BirthDate = x.BirthDate.Value.ToString(),
            DateOfEmployee = x.DateOfEmployment.Value.ToString(),
            Salary = x.Salary.Value.ToString(CultureInfo.CurrentCulture)
        });

        return Ok(query);
    }

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    /// <param name="dto">DTO с идентификатором</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<EmployeeDto>> Get([FromQuery]GetDto dto)
    {
        if (dto.Id == default)
        {
            return BadRequest("Не удалось получить идентификатор");
        }
        
        var entity = await _mediator.Send(new GetEmployeeByIdQuery {Id = dto.Id});
        return new EmployeeDto
        {
            Id = entity.Id,
            DepartmentName = entity.Department.FullName,
            DepartmentCode = entity.Department.Code,
            Surname = entity.FullName.Surname,
            FirstName = entity.FullName.FirstName,
            PatronymicName = entity.FullName.PatronymicName ?? string.Empty,
            BirthDate = entity.BirthDate.Value.ToString(),
            DateOfEmployee = entity.DateOfEmployment.Value.ToString(),
            Salary = entity.Salary.Value.ToString(CultureInfo.CurrentCulture)
        };
    }
}