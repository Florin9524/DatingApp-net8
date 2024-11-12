using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class UsersController(DataContext context) : ControllerBase
{
    //Old school C#
    // private readonly DataContext _context;
    // public UsersController(DataContext context)
    // {
    //     _context = context;
    // }

    //New school use the primary construction public class UsersController(DataContext context) : ControllerBase


     // => /api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return Ok(users);

        //we can use: return BadRequest, return users
    }

 // => /api/users/2
    [HttpGet("{id:int}")]  
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user==null)
            return NotFound();
            
        return Ok(user);
    }
}
