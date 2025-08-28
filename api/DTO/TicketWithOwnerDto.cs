namespace api.DTO;

public class TicketWithOwnerDto
{
    
    public string Title { get; set; }
    public string Description { get; set; }
    public string Severity { get; set; }
    public DateTime CreationDate { get; set; }
    
    public string OwnerName { get; set; }
    public string OwnerEmail { get; set; }
    public int OwnerRole { get; set; }
}