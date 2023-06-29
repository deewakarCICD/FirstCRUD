using System.ComponentModel.DataAnnotations;
namespace FirstCRUD.Models;

public class Employee
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Age is required")]
    [Range(18, 70, ErrorMessage = "Age must be between 18 and 70")]
    public int Age { get; set; }

    [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid, enter like # or #.##")]
    public decimal Salary { get; set; }
    public string? Department { get; set; }
    [RegularExpression(@"^[MF]$", ErrorMessage = "Invalid, possible values are 'M' and 'F'")]
    public char Sex { get; set; }

}