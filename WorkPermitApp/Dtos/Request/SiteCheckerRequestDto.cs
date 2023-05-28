namespace WorkPermitApp.Dtos.Request
{
    public class SiteCheckerRequestDto
    {
        public bool IsIsolated { get; set; }
        public bool IsCriticalByPassed { get; set; }
        public DateTime ByPassedDateTime { get; set; }
        public string ByPassedTagNo { get; set; }
        public string ByPassedReason { get; set; }
        public bool IsProvideAccess { get; set; }
        public bool IsRestrictAccess { get; set; }
        public bool IsCriticalLift { get; set; }
        public bool IsSpecialiLightning { get; set; }
        public bool IsJsaReviewed { get; set; }
        public string OtherSpecialRequirement { get; set; }
        public bool IsGastested { get; set; }
        public string GasTesterName { get; set; }
        public DateTime SiteTestingTime { get; set; }
        public string LELPercentage { get; set; }
        public string WorkPermitId { get; set; }
    }
}
