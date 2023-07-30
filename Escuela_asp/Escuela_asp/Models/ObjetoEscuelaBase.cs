using System;
using System.ComponentModel.DataAnnotations;

namespace Escuela_asp.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }
        
        public virtual string Nombre { get; set; }
        // virtual, puede ser redescrito por las clases hijo.

        public ObjetoEscuelaBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}