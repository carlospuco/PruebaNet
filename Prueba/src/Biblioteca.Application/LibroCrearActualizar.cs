using System.ComponentModel.DataAnnotations;
using Biblioteca.Domain;

namespace Biblioteca.Application;

public class LibroCrearActualizarDto
{
    [Required]
    public string Nombre {get;set;}  
}