using System.ComponentModel.DataAnnotations;

namespace SAPConnection.Data
{
    public class ShiftInchargeModel
    {
        [Key]
        public int Id { get; set; }

   
        public string ApproversId { get; set; }

      
        public string ShiftInchargePno { get; set; }
        public string ShiftType { get; set; }
    }
}
