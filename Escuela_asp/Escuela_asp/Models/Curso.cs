using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escuela_asp.Models
{
    public class Curso : ObjetoEscuelaBase
    {

        public TiposJornada Jornada { get; set; }

        [ValidateNever] // Usar Validate never para evitar que el Modelo valide estos atributos dentro del Controller Create action.
        public List<Asignatura> Asignaturas{ get; set; }
        [ValidateNever]
        public List<Alumno> Alumnos{ get; set; }

        public string Dirección { get; set; }
        [ValidateNever]
        public string EscuelaId { get; set; }
        [ValidateNever]
        public Escuela Escuela { get; set; }

        [Required]
        public override string Nombre { set; get; }
        //public string Id { get; set; }


    }
}