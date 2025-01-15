using Microsoft.AspNetCore.Mvc;
using MusicApp.ApplicationService.DTOs.UserDtos.Request;
using MusicApp.ApplicationService.Services.Interfaces;
using MusicApp.Domain.Handler.Notification;

namespace MusicApp.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UserController(
    IUserCommandService userCommandService)
{
    [HttpPost("register_user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<NotificationEntity>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(IEnumerable<NotificationEntity>))]
    public Task<bool> Register([FromBody] UserRegisterDto registerDto) =>
        userCommandService.RegisterAsync(registerDto);
}