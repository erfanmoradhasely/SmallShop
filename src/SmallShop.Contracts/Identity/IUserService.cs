using SmallShop.Contracts.Identity.Models;

namespace SmallShop.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(string userId);
        public string UserId { get; }
    }
}
