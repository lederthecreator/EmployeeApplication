using Domain.AggregationModels.EmployeeAggregate;
using EmployeeApi.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("/api/v1/[controller]/{action}")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public ActionResult<EmployeeDto> Create(CreateEmployeeDto dto)
    {
        
    }

    [HttpPut]
    public ActionResult<EmployeeDto> Update(UpdateEmployeeDto dto)
    {
        
    }

    [HttpDelete]
    public IActionResult Delete(DeleteEmployeeDto dto)
    {
        
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<ListDto>> List (ListDto dto)
    {
        
    }

    [HttpGet]
    public ActionResult<Employee> Get(GetDto dto)
    {
        
    }
}