using BubberDinner.Domain.Models;
using BubberDinner.Domain.User.ValueObjects;

namespace BubberDinner.Domain.User;


public sealed class User : AggreagateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public User(UserId id,
                string firstName,
                string lastName,
                string email,
                string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    public DateTime CreatedDateTime { get; set; }
    public DateTime DeletedDateTime { get; set; }
}
