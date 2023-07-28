using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace Escuela_asp.Models
{
    public class EscuelaContext: DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext (DbContextOptions<EscuelaContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var escuela = new Escuela();
            escuela.AñoDeCreación = 1972;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "ESTI No. 3";
            escuela.Ciudad = "Xalapa";
            escuela.Pais = "México";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Dirección = "Avila Camacho 502";

            //Cargar Cursos de la escuela

            var cursos = CargarCursos(escuela);

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            //x cada curso cargar alumnos
            var alumnos =  CargarAlumnos(cursos);

            //x cargar evaluaciones - tarea

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }

            return listaAlumnos;
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                List<Asignatura> tmplist = new List<Asignatura> //warning var tmplist
                {
                    new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre= "Matemáticas"},
                    new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre= "Educacion Fisica"},
                    new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre= "Castellano"},
                    new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre= "Ciencias naturales"},
                    new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre= "Programacion"},
                };
                listaCompleta.AddRange(tmplist);
                //curso.Asignaturas = tmplist;
            }
            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>()
            {
                new Curso(){
                    Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso(){
                    Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso(){
                    Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana },
                new Curso(){
                    Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso(){
                    Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Mañana }
            };
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { CursoId = curso.Id,  Nombre = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }
    }
}
