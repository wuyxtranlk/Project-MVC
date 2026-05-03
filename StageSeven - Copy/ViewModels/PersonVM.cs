using System.ComponentModel.DataAnnotations;

namespace StageSeven.ViewModels;

public record PersonVM
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = string.Empty;
    [Range(0, 150, ErrorMessage = "Age must be between 0 and 150!")]
    public int Age { get; set; } = 0;
}
