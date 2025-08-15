using System.ComponentModel.DataAnnotations.Schema;
using api.Entities.Enuns;

namespace api.Entities;


[Table("tb_users")]
public class User : EntityBase
{
    private IList<Ticket> _tickets;
    
    
    public User(string firstName, string lastName, string email, string password, string phone, string address, UserRole role)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Phone = phone;
        Address = address;
        Role = role;
        _tickets = new List<Ticket>();
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }
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
        user.FirstName = FirstName;
        user.LastName = LastName;
        user.Email = Email;
        user.Password = Password;
        user.Phone = Phone;
        user.Address = Address;
        user.Role = Role;
    }
    
}