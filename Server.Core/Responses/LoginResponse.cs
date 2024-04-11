namespace Server.Core.Responses
{
    public record LoginResponse(bool Status, string Message = null!, string Token = null!, string RefreshToken = null!);
}
