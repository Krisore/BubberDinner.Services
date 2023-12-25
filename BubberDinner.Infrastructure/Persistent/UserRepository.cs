using BubberDinner.Application.Common.Interface.Persistent;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Infrastructure.Persistent;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmailAsync(string email)
    {
        var user = _users.FirstOrDefault(appUser => appUser.Email == email);
        return user;
    }
}