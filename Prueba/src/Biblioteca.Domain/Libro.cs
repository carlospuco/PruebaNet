using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain;

public class Libro{

    [Required]
    [Key]
    public int IdLibro {get; set;}
    public string NombreLibro {get; set;}
    public int PrecioLibro {get; set;}
    [Required]
    public int IdEditorial {get; set;}
    public virtual Editorial EditorialLibro {get; set;}
    [Required]
    public int IdAutor {get; set;}
    public virtual Autor AutorLibro {get; set;}

}
