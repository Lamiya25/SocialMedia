using Microsoft.AspNetCore.Identity;


namespace SocialMedia.Domain.Entities.Identity
{
    public class User : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilImage { get; set; }
        public string? About { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime Date { get; set; }
    }
}
