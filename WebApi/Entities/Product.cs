using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class Product
    {
        [Key]
        public int idProduct {get;set;}

        [StringLength (50)]
        public string name {get;set;}
        public float cost {get;set;}
        public float precio {get;set;}

        [ForeignKey("provider")]
        public int idProvider {set; get;}
        public int existence {get; set;}

        [ForeignKey("productType")]
        public int idProductType {set; get;}
        public bool state {get;set;}

        [JsonIgnore]
        public Provider provider {get;set;}

        [JsonIgnore]
        public ProductType productType {get;set;}
    }
}