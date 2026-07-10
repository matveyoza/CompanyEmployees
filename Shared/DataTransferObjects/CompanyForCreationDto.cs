using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CompanyForCreationDto
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Name is 40 characters.")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Adress is a required field.")]
        public string? Address { get; init; }
        [Required(ErrorMessage = "Country is a required field.")]
        public string? Country { get; init; }
        public IEnumerable <EmployeeForCreationDto>? Employees { get; init; }
    }
}
