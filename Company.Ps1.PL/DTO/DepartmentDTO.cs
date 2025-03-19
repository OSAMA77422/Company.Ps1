using System.ComponentModel.DataAnnotations;

namespace Company.Ps1.PL.DTO
{
    public class DepartmentDTO
    {

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Code is required.")]
        public string Code { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "datetime is required.")]
        public DateTime dateTime { get; set; }

    }
}
