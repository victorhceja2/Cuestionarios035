using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class CargaFormulario
    {
        public static void Initialize(IServiceProvider serviceProvider, int id)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                //if (context.Formulario.Any())
                //{
                //    return;   // DB has been seeded
                //}

                context.Formulario.AddRange(
                    new Formulario
                    {
                        Id_Campana = id, //Pasarlo Dinamicamente
                        FechaAlta = DateTime.Now, // DateTime.Parse("1989-2-12"),
                        Nombre =  "Victor Ceja", //"Romantic Comedy",
                        CorreoElectronico = "victorhceja@gmail.com",
                        Descripcion = "Formulario prueba",
                        Pregunta = "Nombre Completo",
                        Respuesta = "",
                        Comentarios = ""
                    },

                    new Formulario
                    {
                        Id_Campana = id, //Pasarlo Dinamicamente
                        FechaAlta = DateTime.Now, // DateTime.Parse("1989-2-12"),
                        Nombre =  "Victor Ceja", //"Romantic Comedy",
                        CorreoElectronico = "victorhceja@gmail.com",
                        Descripcion = "Formulario prueba",
                        Pregunta = "Como es el clima laboral?",
                        Respuesta = "",
                        Comentarios = ""
                    },

                    new Formulario
                    {
                        Id_Campana = id, //Pasarlo Dinamicamente
                        FechaAlta = DateTime.Now, // DateTime.Parse("1989-2-12"),
                        Nombre =  "Victor Ceja", //"Romantic Comedy",
                        CorreoElectronico = "victorhceja@gmail.com",
                        Descripcion = "Formulario prueba",
                        Pregunta = "Que le gustaría Cambiar de su trabajo?",
                        Respuesta = "",
                        Comentarios = ""
                    }

                );
                context.SaveChanges();
            }
    }
    }
}