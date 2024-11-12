using System;

namespace API.Entities;

public class AppUser
{
    // add [Key] if the id is not called ID in table.
    public int Id { get; set; }
    public required string UserName { get; set; }

}
