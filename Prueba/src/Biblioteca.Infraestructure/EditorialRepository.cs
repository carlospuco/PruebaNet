using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infraestructure;

public class EditorialRepository : EfRepository<Editorial>, IEditorialRepository
{
    public EditorialRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteNombre(string nombre)
    {

        var resultado = await this._context.Set<Editorial>()
                    .AnyAsync(x => x.NombreEditorial.ToUpper() == nombre.ToUpper());

        return resultado;
    }

    public async Task<bool> ExisteNombre(string nombre, int idExcluir)
    {

        var query = this._context.Set<Editorial>()
                    .Where(x => x.IdEditorial != idExcluir)
                    .Where(x => x.NombreEditorial.ToUpper() == nombre.ToUpper())
                    ;

        var resultado = await query.AnyAsync();

        return resultado;
    }


}