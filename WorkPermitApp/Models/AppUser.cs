namespace WorkPermitApp.Models
{
    public class AppUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        // Navigation property
        public List<WorkPermit> WorkPermits { get; set; }
    }
    public enum Role
    {
        Applicant,
        Approver,
        SiteChecker
    }

}
