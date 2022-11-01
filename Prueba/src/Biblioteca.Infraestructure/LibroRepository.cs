using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infraestructure;

public class LibroRepository : EfRepository<Libro>, ILibroRepository
{
    public LibroRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteNombre(string nombre)
    {

        var resultado = await this._context.Set<Libro>()
                    .AnyAsync(x => x.NombreLibro.ToUpper() == nombre.ToUpper());

        return resultado;
    }

    public async Task<bool> ExisteNombre(string nombre, int idExcluir)
    {

        var query = this._context.Set<Libro>()
                    .Where(x => x.IdLibro != idExcluir)
                    .Where(x => x.NombreLibro.ToUpper() == nombre.ToUpper())
                    ;

        var resultado = await query.AnyAsync();

        return resultado;
    }


}