using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class RolePage
    {
        [Key]
        public int IdRolePage { get; set; }

        [ForeignKey("role")]
        public int IdRole {set; get;}
        
        [ForeignKey("page")]
        public int IdPage {set; get;}

        public bool state { get; set; }

        [JsonIgnore]
        public Role role {get; set;}

        [JsonIgnore]
        public Page page {get; set;}
    }
}