using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class ClientMachine
    {
        [Key]
        public int idClientMachine {get;set;}

        [ForeignKey("client")]
        public int idClient {get;set;}

        [ForeignKey("machine")]
        public int idMachine {get;set;}
        public DateTime dateAssignment {get;set;}
        public bool state {get;set;}

        [JsonIgnore]
        public Client client {get;set;}

        [JsonIgnore]
        public Machine machine {get;set;}
    }
}