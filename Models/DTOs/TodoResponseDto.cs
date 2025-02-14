namespace GF_TodoApp.Models.DTOs
{
    public class TodoResponseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
