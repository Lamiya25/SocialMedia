using Microsoft.AspNetCore.Identity;


namespace SocialMedia.Domain.Entities.Identity
{
    public class User : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? About { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime Date { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public ProfileImage? ProfileImage { get; set; }
        public string? ProfileImageId { get; set; }
    }
}
