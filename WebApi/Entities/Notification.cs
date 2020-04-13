using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class Notification
    {
        [Key]
        public int idNotification {get;set;}

        [ForeignKey("client")]
        public int idClient {get;set;}

        [ForeignKey("user")]
        public int idUser {get;set;}
        public DateTime date {get;set;}

        [ForeignKey("statusMachine")]
        public int idStatusMachine {get;set;}
        public float totalSales {get;set;}

        [JsonIgnore]
        public Client client {get;set;}

        [JsonIgnore]
        public User user {get;set;}

        [JsonIgnore]
        public StatusMachine statusMachine {get;set;}

    }
}