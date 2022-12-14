// <auto-generated />
using Biblioteca.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca.Infraestructure.Migrations
{
    [DbContext(typeof(BibliotecaDbContext))]
    [Migration("20221031184650_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Biblioteca.Domain.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EdadAutor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreAutor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdAutor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Biblioteca.Domain.Editorial", b =>
                {
                    b.Property<int>("IdEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MatrizEditorial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreEditorial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdEditorial");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("Biblioteca.Domain.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AutorLibroIdAutor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EditorialLibroIdEditorial")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdAutor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdEditorial")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreLibro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PrecioLibro")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdLibro");

                    b.HasIndex("AutorLibroIdAutor");

                    b.HasIndex("EditorialLibroIdEditorial");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Biblioteca.Domain.Libro", b =>
                {
                    b.HasOne("Biblioteca.Domain.Autor", "AutorLibro")
                        .WithMany()
                        .HasForeignKey("AutorLibroIdAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Editorial", "EditorialLibro")
                        .WithMany()
                        .HasForeignKey("EditorialLibroIdEditorial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutorLibro");

                    b.Navigation("EditorialLibro");
                });
#pragma warning restore 612, 618
        }
    }
}
