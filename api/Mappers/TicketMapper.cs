using api.DTO;
using api.Entities;

namespace api.Mappers;

public class TicketMapper
{
    public static TicketDto ToDto(Ticket ticket)
    {
        return new TicketDto
        {
            Title = ticket.Title,
            Description = ticket.Description,
            Severity = ticket.Severity.ToString(),
            Status = ticket.Status.ToString(),
            LastUpdated = ticket.LastUpdateDate,
            CreationDate = ticket.CreationDate
        };
    }

    public static TicketWithOwnerDto ToWithOwnerDto(Ticket ticket)
    {
        return new TicketWithOwnerDto
        {
            Title = ticket.Title,
            Description = ticket.Description,
            Severity = ticket.Severity.ToString(),
            CreationDate = ticket.CreationDate,
            OwnerName = ticket.Owner.FirstName,
            OwnerEmail = ticket.Owner.Email,
            OwnerRole = (Int32)ticket.Owner.Role
        };
    }
}