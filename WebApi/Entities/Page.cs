using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities{
    public class Page {
        [Key]
        public int IdPage { get; set; }

        [StringLength (50)]
        public string Description { get; set; }
        public bool state { get; set; }
    }
}