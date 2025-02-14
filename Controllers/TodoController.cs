using AutoMapper;
using GF_TodoApp.Models;
using GF_TodoApp.Models.DTOs;
using GF_TodoApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GF_TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoController(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _todoRepository.GetAllTodosTasks();
            return Ok(_mapper.Map<IEnumerable<TodoResponseDto>>(todos));
        }

        //[Authorize]
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetTodo(int id)
        {
            var todo = await _todoRepository.GetTodoById(id);
            if (todo == null)
                return NotFound(new { message = "TODO Task not found" });

            return Ok(_mapper.Map<TodoResponseDto>(todo));
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateTodo([FromBody] TodoDto todoDto)
        {
            var todo = _mapper.Map<TodoItem>(todoDto);
            await _todoRepository.AddTodo(todo);
            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, _mapper.Map<TodoDto>(todo));
        }

        [Authorize]
        [HttpPut("{id}", Name = "Update")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoDto todoDto)
        {
            var existingTodo = await _todoRepository.GetTodoById(id);
            if (existingTodo == null)
                return NotFound(new { message = "TODO Task not found" });

            _mapper.Map(todoDto, existingTodo);

            bool updated = await _todoRepository.UpdateTodo(existingTodo);

            if (!updated)
                return BadRequest(new { message = "Failed to update TODO Task" });

            return Ok(new { message = "TODO Task updated successfully" });
        }

        [Authorize]
        [HttpDelete("{id}", Name = "Delete")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var existingTodo = await _todoRepository.GetTodoById(id);

            if (existingTodo == null)
                return NotFound(new { message = "TODO Task not found" });

            await _todoRepository.DeleteTodo(id);
            return Ok(new { message = "TODO Task deleted successfully" });
        }
    }
}