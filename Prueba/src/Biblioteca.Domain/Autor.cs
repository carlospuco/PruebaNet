using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain;

public class Autor{

    [Required]
    [Key]
    public int IdAutor {get; set;}
    public string NombreAutor {get; set;}
    public int EdadAutor {get; set;}


}
