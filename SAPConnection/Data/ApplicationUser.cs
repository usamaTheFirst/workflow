using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SAPConnection.Data
{
    public class ApplicationUser
    {
        [Key]
        public int Uid { get; set; }

        public string Pno { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public string DepartmentId { get; set; }
        public string SectionId { get; set; }
        public string DesignationId { get; set; }
        public bool Acting { get; set; } = false;
        public string? ActingPno { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
        public string EmployeeGroup { get; set; }
        public string ShiftGroup { get; set; }







    }
}
