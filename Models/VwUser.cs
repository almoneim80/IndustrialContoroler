namespace IndustrialContoroler.Models
{
    public class VwUser
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public bool ActiveUser { get; set; }
        public string? ImageUser { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
