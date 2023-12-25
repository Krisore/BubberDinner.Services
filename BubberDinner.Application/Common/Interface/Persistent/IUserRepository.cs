using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Common.Interface.Persistent;


public interface IUserRepository
{
    User? GetUserByEmailAsync(string email);
    void Add(User user);

}