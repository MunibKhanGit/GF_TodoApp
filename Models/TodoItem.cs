namespace GF_TodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }   
        public required string Description { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
