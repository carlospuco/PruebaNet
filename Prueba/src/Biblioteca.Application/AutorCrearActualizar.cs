using System.ComponentModel.DataAnnotations;
using Biblioteca.Domain;

namespace Biblioteca.Application;

public class AutorCrearActualizarDto
{
    [Required]
    public string Nombre {get;set;}
   
}