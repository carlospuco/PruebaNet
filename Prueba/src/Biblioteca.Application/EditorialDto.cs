using System.ComponentModel.DataAnnotations;
using Biblioteca.Domain;

namespace Biblioteca.Application;

 
public class EditorialDto
{
    [Required]
    public int Id {get;set;}

    [Required]
    public string Nombre {get;set;}
}

 