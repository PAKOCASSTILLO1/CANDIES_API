using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class OperationProductOutput
    {
        [Key]
        public int idOperationOutput {get;set;}
        public DateTime dateOperation {get;set;}

        [ForeignKey("product")]
        public int idProducto {set; get;}

        public int quantity {get;set;}
        public float unitValue {get;set;}

        [ForeignKey("client")]
        public int idClient {set; get;}

        [ForeignKey("notification")]
        public int? idNotification {set; get;}

        [JsonIgnore]
        public Product product {get;set;}

        [JsonIgnore]
        public Client client {get;set;}

        [JsonIgnore]
        public Notification notification {get;set;}

    }
}