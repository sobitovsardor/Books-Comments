using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.Dtos.Accounts;

public class AccountLoginDto
{
    [Required(ErrorMessage = "Email kiriting")]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;

    [Required(ErrorMessage = "Parol kiriting")]
    //[StrongPassword]
    public string Password { get; set; } = String.Empty;
}
