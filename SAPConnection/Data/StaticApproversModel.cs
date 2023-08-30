using System.ComponentModel.DataAnnotations;

namespace SAPConnection.Data
{
    public class StaticApproversModel
    {
        [Key]
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Pno { get; set; }
    }
}
