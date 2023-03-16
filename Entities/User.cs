using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? UserFname { get; set; }

    public string? UserLname { get; set; }
    [StringLength(maximumLength: 12, ErrorMessage = "too long password")]
    public string UserPassword { get; set; } = null!;
    [EmailAddress(ErrorMessage = "Email not valid")]
    public string UserEmail { get; set; } = null!;
}
