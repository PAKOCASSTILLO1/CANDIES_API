using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class PurchaseOrder
    {
        [Key]
        public int idPurchaseOrder {get;set;}

        [StringLength (50)]
        public string orderTitle {get;set;}
        public DateTime datePurchaseOrder {get;set;}
        public float purchaseOrderAmount {get;set;}
        public bool statusOrder {get;set;}

        [ForeignKey("provider")]
        public int idProvider {set; get;}

        [JsonIgnore]
        public Provider provider {get;set;}

    }
}