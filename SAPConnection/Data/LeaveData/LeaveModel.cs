using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPConnection.Data.LeaveData
{
    public class LeaveModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Reason is required")]
        public string Reason { get; set; }
        public string? ReasonForCancellation { get; set; }
        [Required(ErrorMessage = "Request Date is required")]
        public DateTime RequestDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "To Date is required")]
        public DateTime ToDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "From Date is required")]
        public DateTime FromDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Leave Type is required")]
        public LeaveTypeModel LeaveType { get; set; }
        public int RouteId { get; set; }
        public string LeaveOwnerPno { get; set; }
        public byte[]? Attachment { get; set; }
        public ApprovalStatus approvalStatus { get; set; } = ApprovalStatus.Draft;
        public int? TotalStages { get; set; }
        public string? CurrentActioner { get; set; }
        public int? CurrentStage { get; set; }
        public string? Key { get; set; }
        public int? LeaveBalance { get; set; }
        public int? AvailedDays { get; set; }
        public int? PreviousLeaveId { get; set; }
        public LeaveModel Clone()
        {
            return (LeaveModel)MemberwiseClone();
        }
        public PostedToSap postedToSap { get; set; } = PostedToSap.No;
        public int GetLeaveCode(string employeeGroup)
        {
            switch (LeaveType)
            {
                case LeaveTypeModel.Casual:
                    return 3000;
                case LeaveTypeModel.Sick:
                    return 4000;
                case LeaveTypeModel.Annual:
                    switch (employeeGroup)
                    {
                        case "M":
                        case "J":
                            return 1001;
                        default:
                            return 2001;
                    }
                case LeaveTypeModel.Special_Leave_General_With_Pay:
                case LeaveTypeModel.Special_Leave_Medical_With_Pay:
                    return 5000;
                case LeaveTypeModel.Special_Leave_General_Without_Pay:
                case LeaveTypeModel.Special_Leave_Medical_Without_Pay:
                    return 9900;
                case LeaveTypeModel.Maternity:
                    return 7000;
                case LeaveTypeModel.Paternity:
                    return 7010;
                case LeaveTypeModel.Sabbatical:
                    return 9901;
                default:
                    return 0;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            LeaveModel other = (LeaveModel)obj;

            return Reason == other.Reason &&
                   ToDate == other.ToDate &&
                   FromDate == other.FromDate &&
                   Equals(LeaveType, other.LeaveType) &&
                   EqualityComparer<byte[]>.Default.Equals(Attachment, other.Attachment);
        }

        public bool ShouldPostOnSAP()
        {
            if (LeaveType == LeaveTypeModel.Casual || LeaveType == LeaveTypeModel.Sick || LeaveType == LeaveTypeModel.Annual)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

public enum LeaveTypeModel
{
    Uninitialized,
    Casual, Sick, Annual, Special_Leave_General_With_Pay,
    Special_Leave_Medical_With_Pay, Special_Leave_General_Without_Pay,
    Special_Leave_Medical_Without_Pay, Maternity, Paternity, Sabbatical
}



public enum ApprovalStatus
{
    Draft, Pending, Approved, Returned, Cancelled, Payment, Marked, Replied, Shared
}

public enum PostedToSap
{
    Yes = 1, No = 0
}