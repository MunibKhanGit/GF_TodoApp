using GF_TodoApp.Models;

namespace GF_TodoApp.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllTodosTasks();
        Task<TodoItem> GetTodoById(int id);
        Task AddTodo(TodoItem todo);
        Task<bool> UpdateTodo(TodoItem todo);
        Task DeleteTodo(int id);
    }
}
