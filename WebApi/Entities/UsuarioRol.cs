using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class UsuarioRol 
    {
        [Key]
        public int IdUsuarioRol { get; set; }

        [ForeignKey("usuario")]
        public int IdUsuario {set; get;}
        
        [ForeignKey("rol")]
        public int IdRol {set; get;}

        public bool estado { get; set; }

        [JsonIgnore]
        public Usuario usuario {get; set;}

        [JsonIgnore]
        public Rol rol {get; set;}
    }
}