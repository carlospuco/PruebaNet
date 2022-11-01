using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Biblioteca.Infraestructure;

public class BibliotecaDbContext:DbContext, IUnitOfWork
{

    //Agregar sus entidades
    public DbSet<Libro> Libros {get;set;}

    public DbSet<Autor> Autores {get;set;}

    public DbSet<Editorial> Editoriales {get;set;}

    public string DbPath { get; set; }

    public BibliotecaDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "curso.comercio-electronico.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

} 



