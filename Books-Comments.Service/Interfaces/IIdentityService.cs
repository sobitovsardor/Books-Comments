using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.Interfaces;

public interface IIdentityService
{
    public long? Id { get; }

    public string UserName { get; }

    public string Email { get; }

    public string ImagePath { get; }
}
