using api.Entities.Enuns;

namespace api.Entities;

public class Ticket : EntityBase
{
    private Ticket() { }
    public Ticket(string title, string description, Severity severity, StatusTicket status, User owner)
    {
        Title = title;
        Description = description;
        Severity = severity;
        Status = status;
        Owner = owner;
        OwnerId = owner.Id;
        CreationDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public Severity Severity { get; private set; }
    public StatusTicket Status { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public int OwnerId { get; private set; }
    public User Owner { get; private set; }
    
    
    public void ChangeStatus(StatusTicket status)
    {
        this.Status = status;
        this.LastUpdateDate = DateTime.Now;
    }

    public void EditTicket(Ticket ticket)
    {
        this.Title = ticket.Title;
        this.Description = ticket.Description;
        this.Severity = ticket.Severity;
        this.Status = ticket.Status;
        this.CreationDate = DateTime.Now;
        this.LastUpdateDate = DateTime.Now;
    }

    public void ChangeOwner(User user)
    {
        this.Owner = user;
        this.LastUpdateDate = DateTime.Now;
    }
    
}