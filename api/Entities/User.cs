using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Entities.Enuns;

namespace api.Entities;

public class User : EntityBase
{
    private IList<Ticket> _tickets;
    
    
    public User(string firstName, string lastName, string email, string password, string? phone, string? address, UserRole role = UserRole.User)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Phone = phone;
        Address = address;
        Role = role;
        _tickets = new List<Ticket>();


        if (role != UserRole.Admin && role != UserRole.User)
        {
            this.Role = UserRole.User;
        }
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    [EmailAddress]
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string? Phone { get; private set; }
    public string? Address { get; private set; }
    public UserRole Role { get; private set; }

    public IReadOnlyCollection<Ticket> Tickets
    {
        get
        {
            return _tickets.ToArray();
        }
    }


    public void AddTicket(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    public void RemoveTicket(int ticketId)
    {
        _tickets.RemoveAt(ticketId);
    }
    
    public void EditUser(User user)
    {
        this.FirstName = user.FirstName;
        this.LastName = user.LastName;
        this.Email = user.Email;
        this.Password = user.Password;
        this.Phone = user.Phone;
        this.Address = user.Address;
        this.Role = user.Role;
        
        if (user.Role != UserRole.Admin && user.Role != UserRole.User)
        {
            this.Role = UserRole.User;
        }
    }
    
    public void ChangePassword(string password)
    {
        this.Password = password;
    }
    
}