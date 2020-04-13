using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class OperationProductEntry
    {
        [Key]
        public int idOperationEntry {get;set;}
        public DateTime dateOperation {get;set;}

        [ForeignKey("product")]
        public int idProducto {set; get;}

        public int quantity {get;set;}
        public float unitValue {get;set;}

        [ForeignKey("provider")]
        public int? idProvider {set; get;}

        [JsonIgnore]
        public Providerr provider {get;set;}

        [JsonIgnore]
        public Product product {get;set;}
    }
}