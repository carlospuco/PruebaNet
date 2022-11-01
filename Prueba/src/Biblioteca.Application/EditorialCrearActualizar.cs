using System.ComponentModel.DataAnnotations;
using Biblioteca.Domain;

namespace Biblioteca.Application;

public class EditorialCrearActualizarDto
{
    [Required]
    public string Nombre {get;set;}  
}