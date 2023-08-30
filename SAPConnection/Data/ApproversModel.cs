using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SAPConnection.Data
{
    public class ApproversModel
    {
       

        [Key]
        public int Id { get; set; }
        public string SapId { get; set; }
        public string DepartmentId { get; set; }
        public string SectionId { get; set; }
        public string SectionHeadId { get; set; }
        public string UnitManagerId { get; set; }
        public string DepartmentHeadId { get; set; }
        public string FunctionalHeadId { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }

        public ApproversModel(string sapId, string departmentId, string sectionId, string sectionHeadId,
                  string unitManagerId, string departmentHeadId, string functionalHeadId,
                  string departmentName, string sectionName)
        {
            SapId = sapId;
            DepartmentId = departmentId;
            SectionId = sectionId;
            SectionHeadId = sectionHeadId;
            UnitManagerId = unitManagerId;
            DepartmentHeadId = departmentHeadId;
            FunctionalHeadId = functionalHeadId;
            DepartmentName = departmentName;
            SectionName = sectionName;
        }

        public ApproversModel()
        {
        }
    }



}
