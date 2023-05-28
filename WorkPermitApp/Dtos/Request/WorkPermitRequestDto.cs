using WorkPermitApp.Models;

namespace WorkPermitApp.Dtos.Request
{
    public class WorkPermitRequestDto
    {
        public string ApplicantName { get; set; }
        public string ProjectName { get; set; }
        public string WorkLocation { get; set; }
        public string EquipmentDescription { get; set; }
        public string CompanyName { get; set; }
        public string JsaNo { get; set; }
        public string WorkDescription { get; set; }
        public string Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsTermAndCondition { get; set; }
        public PermitStatus PermitStatus { get; set; }
        public string AppUserId { get; set; }
    }
}
