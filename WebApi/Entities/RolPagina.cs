using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class RolPagina
    {
        [Key]
        public int IdRolPagina { get; set; }

        [ForeignKey("rol")]
        public int IdRol {set; get;}
        
        [ForeignKey("pagina")]
        public int IdPagina {set; get;}

        public bool estado { get; set; }

        [JsonIgnore]
        public Rol rol {get; set;}

        [JsonIgnore]
        public Pagina pagina {get; set;}
    }
}