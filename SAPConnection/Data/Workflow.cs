using System.ComponentModel.DataAnnotations;

namespace SAPConnection.Data
{
    public class WorkflowItem
    {
        [Key]
        public int Id { get; set; }
        public string App { get; set; }
        public string? Key { get; set; }

        public AssignedTask AssignedTask { get; set; }
        public int Level { get; set; }
        public ApproverRole? ApproverRole { get; set; }
        public string? StaticApproverRole { get; set; }
        public ApproverType? ApproverType { get; set; }
        public string? WF_Type { get; set; }
        public string? Location { get; set; }
        public string? SubType { get; set; }
        public string? specific_id { get; set; }
    }
}


public enum AssignedTask
{
    Review, Approve, Payment, Submitted
}




public enum ApproverRole
{
   Incharge = 090,  SectionHead = 61, UnitManager = 60, DepartmentHead = 40, FunctionalHead = 30, 
}

public enum ApproverType
{
    ByUser, ByRole
}
public class WorkflowApproverDetails
{
    public string ApproverEmail { get; set; }
    public string Pno { get; set; }
    public AssignedTask AssignedTask { get; set; }
    public string Name { get; set; }
}