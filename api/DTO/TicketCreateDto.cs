namespace api.DTO;

public class TicketCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Severity { get; set; }
    public int Status { get; set; }
    public int OwnerId { get; set; }
}