using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class UserRole
    {
        public UserRole()
        {
            this.state = true;
        }

        [Key]
        public int idUserRole { get; set; }

        [ForeignKey("user")]
        public int idUser {set; get;}

        [ForeignKey("role")]
        public int idRole {set; get;}

        public bool state { get; set; }

        [JsonIgnore]
        public User user {get; set;}

        [JsonIgnore]
        public Role role {get; set;}
    }
}