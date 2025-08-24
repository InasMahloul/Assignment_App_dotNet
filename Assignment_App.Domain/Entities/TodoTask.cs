namespace Assignment_App.Domain.Entities
{
    public class TodoTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }
}
