using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; } = default!;

        public DbSet<MvcMovie.Models.Usuario> Usuario { get; set; } = default!;

        public DbSet<MvcMovie.Models.Pregunta> Pregunta { get; set; } = default!;

        public DbSet<MvcMovie.Models.CuesH> CuesH { get; set; } = default!;

        public DbSet<MvcMovie.Models.CuesD> CuesD { get; set; } = default!;
    }
