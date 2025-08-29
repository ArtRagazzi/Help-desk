using System.ComponentModel.DataAnnotations;
using api.Entities.Enuns;

namespace api.DTO;

public class TicketUpdateDto
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    
    public Severity Severity { get; set; }  
    
    [Required]
    public StatusTicket Status { get; set; } 
    
    [Required]
    public int OwnerId { get; set; }
}