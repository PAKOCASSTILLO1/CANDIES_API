using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities{
    public class Pagina {
        [Key]
        public int IdPagina { get; set; }

        [StringLength (50)]
        public string Description { get; set; }
        public bool estado { get; set; }
    }
}