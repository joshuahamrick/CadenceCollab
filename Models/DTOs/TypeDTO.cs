using System.ComponentModel.DataAnnotations;

public class TypeDTO
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}