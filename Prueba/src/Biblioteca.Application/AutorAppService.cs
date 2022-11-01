
using System.ComponentModel.DataAnnotations;
using Biblioteca.Application;
using Biblioteca.Domain;

namespace Biblioteca.Application;

public class AutorAppService : IAutorAppService
{
    private readonly IAutorRepository repository;
    //private readonly IUnitOfWork unitOfWork;

    public AutorAppService(IAutorRepository repository)
    {
        this.repository = repository;
        //this.unitOfWork = unitOfWork;
    }

    public async Task<AutorDto> CreateAsync(AutorCrearActualizarDto autorDto)
    {

        //Reglas Validaciones... 
        var existeNombreMarca = await repository.ExisteNombre(autorDto.Nombre);
        if (existeNombreMarca == true )
        {
            throw new ArgumentException($"Ya existe un autor con el nombre {autorDto.Nombre}");
        }
        //Mapeo Dto => Entidad
        var autor = new Autor();
        autor.NombreAutor = autorDto.Nombre;
        //Persistencia objeto
        autor = await repository.AddAsync(autor);
        //await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var autorCreada = new AutorDto();
        autorCreada.Nombre = autor.NombreAutor;
        autorCreada.Id = autor.IdAutor;

        //TODO: Enviar un correo electronica... 

        return autorCreada;
    }

    public async Task UpdateAsync(int id, AutorCrearActualizarDto autorDto)
    {
        var autor = await repository.GetByIdAsync(id);
        if (autor == null)
        {
            throw new ArgumentException($"La autor con el id: {id}, no existe");
        }

        var existeNombreMarca = await repository.ExisteNombre(autorDto.Nombre, id);
        if (existeNombreMarca)
        {
            throw new ArgumentException($"Ya existe una marca con el nombre {autorDto.Nombre}");
        }

        //Mapeo Dto => Entidad
        autor.NombreAutor = autorDto.Nombre;

        //Persistencia objeto
        await repository.UpdateAsync(autor);
        //await unitOfWork.SaveChangesAsync();

        return;
    }

    public async Task<bool> DeleteAsync(int autorId)
    {
        //Reglas Validaciones... 
        var autor = await repository.GetByIdAsync(autorId);
        if (autor == null)
        {
            throw new ArgumentException($"El autor con el id: {autorId}, no existe");
        }

        repository.Delete(autor);
        //await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<AutorDto> GetAll()
    {
        var autorList = repository.GetAll();

        var autorListDto = from m in autorList
                        select new AutorDto()
                        {
                            Id = m.IdAutor,
                            Nombre = m.NombreAutor
                        };

        return autorListDto.ToList();
    }


}