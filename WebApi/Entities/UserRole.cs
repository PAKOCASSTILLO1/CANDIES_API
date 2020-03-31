using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class UserRole
    {
        [Key]
        public int IdUserRole { get; set; }

        [ForeignKey("user")]
        public int IdUser {set; get;}
        
        [ForeignKey("role")]
        public int IdRole {set; get;}

        public bool state { get; set; }

        [JsonIgnore]
        public User user {get; set;}

        [JsonIgnore]
        public Role role {get; set;}
    }
}