using Buttler.Domain.Model;
using Buttler.Logic.DTOs;
using Buttler.Logic.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Buttler.webAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserLogic  _userLogic;

    public UserController(IUserLogic userLogic)
    {
        _userLogic = userLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> CreateReport(UserCreationDTO dto)
    {
        try
        {
            User created = await _userLogic.CreateUserAsync(dto);
            return Created($"/api/user/{created.UserID}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IEnumerable<User>> getUsers()
    {
        return await _userLogic.GetAllUsersAsync();
    }
}