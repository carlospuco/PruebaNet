using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain;

public class Editorial{

    [Required]
    [Key]
    public int IdEditorial{get; set;}
    public string NombreEditorial {get; set;}
    public string? MatrizEditorial {get; set;}

}
