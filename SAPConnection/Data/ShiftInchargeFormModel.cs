using System.ComponentModel.DataAnnotations;

namespace SAPConnection.Data
{
    public class ShiftInchargeFormModel
    {

        [Required(ErrorMessage = "Please select a Department.")]
        public string SelectedDepartment { get; set; }

        [Required(ErrorMessage = "Please select a Section.")]
        public string SelectedSection { get; set; }

        [Required(ErrorMessage = "Please select a Shift Type.")]
        public string SelectedShift { get; set; }

        [Required(ErrorMessage = "Please enter Incharge PNo.")]
        [PNoValidation(ErrorMessage = "Incharge PNo must be 8 digits.")]
        public string InchargePNo { get; set; }

    }
    public class PNoValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string pno && pno.Length == 8 && int.TryParse(pno, out _))
            {
                return true;
            }

            return false;
        }
    }
}
