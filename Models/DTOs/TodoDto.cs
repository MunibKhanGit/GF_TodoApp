using System.Text.Json.Serialization;

namespace GF_TodoApp.Models.DTOs
{
    public class TodoDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
