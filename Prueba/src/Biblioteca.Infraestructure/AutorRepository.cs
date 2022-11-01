
using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infraestructure;

public class AutorRepository : EfRepository<Autor>, IAutorRepository
{
    public AutorRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteNombre(string nombre)
    {

        var resultado = await this._context.Set<Autor>()
                    .AnyAsync(x => x.NombreAutor.ToUpper() == nombre.ToUpper());

        return resultado;
    }

    public async Task<bool> ExisteNombre(string nombre, int idExcluir)
    {

        var query = this._context.Set<Autor>()
                    .Where(x => x.IdAutor != idExcluir)
                    .Where(x => x.NombreAutor.ToUpper() == nombre.ToUpper())
                    ;

        var resultado = await query.AnyAsync();

        return resultado;
    }


}