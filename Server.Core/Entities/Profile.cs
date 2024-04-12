using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Core.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }

        
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
