using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class PurchaseDetail
    {
        [Key]
        public int idPurchaseDetail {get;set;}

        [ForeignKey("product")]
        public int idProduct {get;set;}

        [ForeignKey("purchaseOrder")]
        public int? idPurchaseOrder {get;set;}

        [JsonIgnore]
        public Product product {get;set;}

        [JsonIgnore]
        public PurchaseOrder purchaseOrderFK {get;set;}
    }
}