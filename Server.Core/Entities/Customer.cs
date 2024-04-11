using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
