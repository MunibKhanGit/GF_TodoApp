using GF_TodoApp.Data;
using GF_TodoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GF_TodoApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTodo(TodoItem todo)
        {
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TodoItem> GetTodoById(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodosTasks()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<bool> UpdateTodo(TodoItem todo)
        {
            _context.TodoItems.Update(todo); 
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
