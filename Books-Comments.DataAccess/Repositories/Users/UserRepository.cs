using Books_Comments.DataAccess.DbContexts;
using Books_Comments.DataAccess.Interfaces.Users;
using Books_Comments.Domain.Entities.Users;

namespace Books_Comments.DataAccess.Repositories.Users;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
