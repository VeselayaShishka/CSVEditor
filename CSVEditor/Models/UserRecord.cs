namespace CSVEditor.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserRecord
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(60)]
    [RegularExpression(@"^[a-zA-Z\-\. ]+$",
        ErrorMessage = "English characters only in Name field")]
    public string FullName { get; set; }
    
    public DateOnly Birthday { get; set; }
    
    public bool Married { get; set; }
    
    [Required]
    [RegularExpression(@"^(\+380)\d{9}$",
        ErrorMessage = "Phone number must be in +380*********")]
    public string Phone { get; set; }
    
    [Range(0, 10000000,
        ErrorMessage = "Number must be between 0 and 10000000")]
    public decimal Salary { get; set; }
}