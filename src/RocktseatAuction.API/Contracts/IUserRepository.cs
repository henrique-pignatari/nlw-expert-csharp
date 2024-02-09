using RocktseatAuction.API.Entities;
using RocktseatAuction.API.Repositories;

namespace RocktseatAuction.API.Contracts;

public interface IUserRepository
{
    public bool ExistUserWithEmail(string email);
    public User GetUserByEmail(string email);
}
