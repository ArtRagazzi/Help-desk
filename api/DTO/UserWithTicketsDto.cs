namespace api.DTO;

public class UserWithTicketsDto
{
    public string FirstName { get; set; }
    public string Email { get; set; }
    public int Role { get; set; }
    public List<TicketDto> Tickets { get; set; } = new List<TicketDto>();
}