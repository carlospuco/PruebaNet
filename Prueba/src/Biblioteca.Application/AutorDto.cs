using System.ComponentModel.DataAnnotations;
using Biblioteca.Domain;

namespace Biblioteca.Application;

public class AutorDto
{
    [Required]
    public int Id {get;set;}

    [Required]
    public string Nombre {get;set;}
}
