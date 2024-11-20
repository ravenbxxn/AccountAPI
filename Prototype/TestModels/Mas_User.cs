using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}
