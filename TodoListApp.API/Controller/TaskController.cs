using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.API.Services.Validators;
using TodoListApp.Business.Interfaces;
using TodoListApp.Entities.DbSet;
using TodoListApp.Entities.Dtos;
using TaskStatus = TodoListApp.Entities.DbSet.TaskStatus;

namespace TodoListApp.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class TaskController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ITodoService _todoService ;
    private readonly IMapper _mapper;
    
    private readonly IValidator<CreateTaskRequest> _createTaskRequestValidator;
    
    public TaskController(
        IMapper mapper,
        IValidator<CreateTaskRequest> createTaskRequestValidator,
        ITodoService todoService)
    {
        _mapper = mapper;
        _createTaskRequestValidator = createTaskRequestValidator;
        _todoService = todoService;
    }
    
    [HttpGet]
    public  async Task<ActionResult> GetAllTodo()
    {
        var items = await _todoService.GetAll();
        return Ok(items);
    }
    
    [HttpGet("getById")]
    public  async Task<ActionResult> GetById(Guid id)
    {
        var item = await _todoService.GetByIdAsync(id);
        return Ok(item);
    }
    
    [HttpGet("getTaskByStatus")]
    public async Task<IActionResult> GetTasksByStatus(TaskStatus status)
    {
        var items = await _todoService.GetAllByStatus(status);
        return Ok(items);
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddTask([FromBody] CreateTaskRequest taskRequest)
    {
        ValidationResult result = _createTaskRequestValidator.Validate(taskRequest);
        
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        
        var task = _mapper.Map<Todo>(taskRequest);
        await _todoService.AddAsync(task);
        return Ok();
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequest taskRequest)
    {
        var validator = new UpdateTaskRequestValidator();
        ValidationResult result = validator.Validate(taskRequest);
    
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        
        var task = _mapper.Map<Todo>(taskRequest);
         
        await _todoService.UpdateAsync(task);
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        await _todoService.DeleteAsync(id);
        return Ok();
    }
}