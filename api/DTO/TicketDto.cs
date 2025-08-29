namespace api.DTO;

public class TicketDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Severity { get; set; }
    public string Status { get; set; }
    public DateTime LastUpdated { get; set; }
    public DateTime CreationDate { get; set; }
}