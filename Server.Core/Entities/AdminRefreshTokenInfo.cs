namespace Server.Core.Entities
{
    public class AdminRefreshTokenInfo
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public int UserId { get; set; }
    }
}
