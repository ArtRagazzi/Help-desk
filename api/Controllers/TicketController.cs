using api.DTO;
using api.Entities;
using api.Entities.Enuns;
using api.Mappers;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


[ApiController]
[Route("api/v1/ticket")]
public class TicketController : ControllerBase
{
    
    private readonly ITicketService _ticketService;
    private readonly IUserService _userService;
    
    public TicketController(ITicketService ticketService, IUserService userService)
    {
        _ticketService = ticketService;
        _userService = userService;
    }
    
    [HttpPost("create")]
    [Authorize(Policy = "User")]
    public async Task<IActionResult> Create([FromBody] TicketCreateDto dto)
    {
        if (dto == null)
            return BadRequest("Dados inválidos");
        
        var ticket = new Ticket(
            title: dto.Title,
            description: dto.Description,
            severity: (Severity)dto.Severity,
            status: (StatusTicket)dto.Status,
            ownerId: dto.OwnerId
        );

        await _ticketService.Insert(ticket);
        return CreatedAtAction(nameof(Create), new { id = ticket.Id }, ticket);
    }
    
    [HttpGet]
    [Authorize(Policy = "User")]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _ticketService.GetAllWithOwner();
        var ticketsDto = tickets.Select(TicketMapper.ToWithOwnerDto).ToList();
        return Ok(ticketsDto);
    }
}