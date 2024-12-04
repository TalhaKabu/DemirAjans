using Kab.DemirAjans.Entities.ExtraProperties;
using System;

namespace Kab.DemirAjans.Entities.Users;

public class UserDto : AggregateRoot
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
}