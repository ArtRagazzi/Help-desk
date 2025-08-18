
using api.Data;
using api.Entities;
using api.Entities.Enuns;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class TicketService: ITicketService
{
    
    private readonly AppDbContext _context;

    public TicketService(AppDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<IEnumerable<Ticket>> GetAll()
    {
        try
        {
            return await _context.Tickets.AsNoTracking().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Enumerable.Empty<Ticket>();
        }
    }

    public async Task<Ticket> GetById(int id)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        if (ticket != null)
        {
            return ticket;
        }
        throw new Exception("Ticket not found");
    }

    public async Task<IEnumerable<Ticket>> FindByTitle(string title)
    {
        IEnumerable<Ticket> tickets;
        if (!string.IsNullOrEmpty(title))
        {
            tickets = await _context.Tickets.Where(x => x.Title == title).ToListAsync();
        }
        else
        {
            tickets = await GetAll();
        }
        return tickets;
        
    }

    public async Task<IEnumerable<Ticket>> FindBySeverity(Severity severity)
    {
        IEnumerable<Ticket> tickets;
        if (!string.IsNullOrEmpty(severity.ToString()))
        {
            tickets = await _context.Tickets.Where(x => x.Severity == severity).ToListAsync();
        }
        else
        {
            tickets = await GetAll();
        }
        return tickets;
    }

    public async Task<IEnumerable<Ticket>> FindByStatus(StatusTicket status)
    {
        IEnumerable<Ticket> tickets;
        if (!string.IsNullOrEmpty(status.ToString()))
        {
            tickets = await _context.Tickets.Where(x => x.Status == status).ToListAsync();
        }
        else
        {
            tickets = await GetAll();
        }
        return tickets;
    }

    public async Task Insert(Ticket ticket)
    {
        try
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public async Task Update(Ticket ticket, int id)
    {
        var existingTicket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        if (existingTicket == null)
        {
            throw new Exception("Ticket not found");
        }
        existingTicket.EditTicket(ticket);
        _context.Tickets.Update(existingTicket);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        if (ticket == null)
        {
            throw new Exception("Ticket not found");
        }
        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
    }
}