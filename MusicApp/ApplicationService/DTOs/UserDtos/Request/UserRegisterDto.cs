namespace MusicApp.ApplicationService.DTOs.UserDtos.Request;

public record UserRegisterDto(
    string Name,
    DateTime JoinedDate);