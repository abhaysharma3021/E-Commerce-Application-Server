namespace Server.Core.Responses
{
    public record GeneralResponse(bool Status, string Message = null!);
}
