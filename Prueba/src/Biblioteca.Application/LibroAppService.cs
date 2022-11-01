
using System.ComponentModel.DataAnnotations;
using Biblioteca.Application;
using Biblioteca.Domain;

namespace Biblioteca.Application;

public class LibroAppService : ILibroAppService
{
    private readonly ILibroRepository repository;
    //private readonly IUnitOfWork unitOfWork;

    public LibroAppService(ILibroRepository repository)
    {
        this.repository = repository;
        //this.unitOfWork = unitOfWork;
    }

    public async Task<LibroDto> CreateAsync(LibroCrearActualizarDto libroDto)
    {

        //Reglas Validaciones... 
        var existeNombreMarca = await repository.ExisteNombre(libroDto.Nombre);
        if (existeNombreMarca)
        {
            throw new ArgumentException($"Ya existe una marca con el nombre {libroDto.Nombre}");
        }
        //Mapeo Dto => Entidad
        var libro = new Libro();
        libro.NombreLibro = libroDto.Nombre;
        //Persistencia objeto
        libro = await repository.AddAsync(libro);
        //await unitOfWork.SaveChangesAsync();
        //Mapeo Entidad => Dto
        var libroCreada = new LibroDto();
        libroCreada.Nombre = libro.NombreLibro;
        libroCreada.Id = libro.IdLibro;
        //TODO: Enviar un correo electronica... 
        return libroCreada;
    }

    public async Task UpdateAsync(int id, LibroCrearActualizarDto libroDto)
    {
        var libro = await repository.GetByIdAsync(id);
        if (libro == null)
        {
            throw new ArgumentException($"La editorial con el id: {id}, no existe");
        }

        var existeNombreLibro = await repository.ExisteNombre(libroDto.Nombre, id);
        if (existeNombreLibro)
        {
            throw new ArgumentException($"Ya existe una marca con el nombre {libroDto.Nombre}");
        }

        //Mapeo Dto => Entidad
        libroDto.Nombre = libroDto.Nombre;

        //Persistencia objeto
        await repository.UpdateAsync(libro);
        //await unitOfWork.SaveChangesAsync();

        return;
    }

    public async Task<bool> DeleteAsync(int libroId)
    {
        //Reglas Validaciones... 
        var libro = await repository.GetByIdAsync(libroId);
        if (libro == null)
        {
            throw new ArgumentException($"El libro con el id: {libroId}, no existe");
        }

        repository.Delete(libro);
        //await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<LibroDto> GetAll()
    {
        var libroList = repository.GetAll();

        var libroListDto = from m in libroList
                        select new LibroDto()
                        {
                            Id = m.IdLibro,
                            Nombre = m.NombreLibro,
                        };

        return libroListDto.ToList();
    }
}

