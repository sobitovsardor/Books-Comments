using Books_Comments.Domain.Entities.Users;
using Books_Comments.Service.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.Dtos.Accounts;

public class AccountRegisterDto : AccountLoginDto
{
    [Required(ErrorMessage ="Username kiriting")] 
    public string UserName { get; set; } = string.Empty;

    public static implicit operator User(AccountRegisterDto accountRegisterDto)
    {
        return new User()
        {
            UserName = accountRegisterDto.UserName,
            Email = accountRegisterDto.Email,
            CreateTime = TimeHelper.GetCurrentServerTime(),
        };
    }
}
