using Books_Comments.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.Interfaces;

public interface IAuthService
{
    public string GenerationToken(User user);
}
